using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.UI.Michsky.UI.ModernUIPack;

public class ChunkManager : MonoBehaviour
{
    public ChunkManagerBeach chunkManagerBeach;
    public GameObject changeDecorEffect;
    //public ParticleSystem[] tireSmokesPS = new ParticleSystem[2];

    public const float maxViewDist = 65;
    public Transform player;

    public static Vector2 playerPos;
    int chunkSize, chunksVisibleInViewDist;
    public int chunks;

    public GameObject[] chunksParking;
    public GameObject[] chunksBeach;
    public GameObject[] chunksCity;

    public GameObject[] chunksAvailable;
    public NavMeshSurface navSurf;

    Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();
    List<TerrainChunk> terrainChunksVisibleLastUpdate = new List<TerrainChunk>();

    public static ChunkManager instance;
    private void Awake()
    {
        Color colorSmoke;
        int _mapIndex = PlayerPrefs.GetInt("map", 0);
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (instance != null)
        {
            return;
        }
        instance = this;

        if(_mapIndex == 0)
        {
            chunksAvailable = chunksParking;
            ColorUtility.TryParseHtmlString("#565656", out colorSmoke);
            TireSmokeColor(colorSmoke);
        }
        if (_mapIndex == 1)
        {
            chunksAvailable = chunksBeach;
            ColorUtility.TryParseHtmlString("#BF9379", out colorSmoke);
            TireSmokeColor(colorSmoke);
        }
        if (_mapIndex == 2)
        {
            chunksAvailable = chunksCity;
            navSurf.enabled = true;
            ColorUtility.TryParseHtmlString("#565656", out colorSmoke);
            TireSmokeColor(colorSmoke);
        }
    }

    void TireSmokeColor(Color s)
    {
        Color endColor;
        ColorUtility.TryParseHtmlString("#AEAEAE", out endColor);
        GameObject[] tireSmokes = GameObject.FindGameObjectsWithTag("TireSmoke");
        ParticleSystem[] tireSmokesPS = new ParticleSystem[2];
        Debug.Log(tireSmokes.Length);
        for (int i = 0; i < tireSmokes.Length; i++)
        {
            tireSmokesPS[i] = tireSmokes[i].GetComponent<ParticleSystem>();
        }
        foreach (var item in tireSmokesPS)
        {
            var colorOverLifetime = item.colorOverLifetime;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] {
                    new GradientColorKey(s, 0.0f), // Couleur au début
                    new GradientColorKey(endColor, 1.0f)    // Couleur à la fin
                },
                new GradientAlphaKey[] {
                    new GradientAlphaKey(1.0f, 0.0f), // Opacité complète au début
                    new GradientAlphaKey(1.0f, 0.0f) // Transparence à la fin
                }
            );

            // Assignez le dégradé au Color over Lifetime
            colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);
        }
    }
    void Start()
    {
        chunkSize = 123;
        chunksVisibleInViewDist = Mathf.RoundToInt(maxViewDist / chunkSize);
    }

    void Update()
    {
        playerPos = new Vector2(player.position.x, player.position.z);
        UpdateVisibleChunks();
    }

    public void DisableObstacle(GameObject _gameObject)
    {
        StartCoroutine(DisablingObjects(_gameObject));
    }

    IEnumerator DisablingObjects(GameObject _gameObject)
    {
        _gameObject.SetActive(false);
        yield return new WaitForSeconds(.2f);
        _gameObject.SetActive(true);
        yield return new WaitForSeconds(.2f);
        _gameObject.SetActive(false);
        yield return new WaitForSeconds(.2f);
        _gameObject.SetActive(true);
        yield return new WaitForSeconds(.2f);
        _gameObject.SetActive(false);
    }

    void UpdateVisibleChunks()
    {
        for (int i = 0; i < terrainChunksVisibleLastUpdate.Count; i++)
        {
            terrainChunksVisibleLastUpdate[i].SetVisible(false);
        }
        terrainChunksVisibleLastUpdate.Clear();
        int currentChunkCoordX = Mathf.RoundToInt(playerPos.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(playerPos.y / chunkSize);

        for(int yOffset = -chunksVisibleInViewDist; yOffset <= chunksVisibleInViewDist; yOffset++)
        {
            for(int xOffset = -chunksVisibleInViewDist; xOffset <= chunksVisibleInViewDist; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);
                if(terrainChunkDictionary.ContainsKey(viewedChunkCoord))
                {
                    terrainChunkDictionary[viewedChunkCoord].UpdateTerrainChunk();
                    if (terrainChunkDictionary[viewedChunkCoord].IsVisible())
                    {
                        terrainChunksVisibleLastUpdate.Add(terrainChunkDictionary[viewedChunkCoord]);
                    }
                }
                else
                {
                    terrainChunkDictionary.Add(viewedChunkCoord, new TerrainChunk(viewedChunkCoord, chunkSize, transform));
                }
            }
        }
    }

    public class TerrainChunk
    {
        GameObject meshObject;
        Vector2 position;
        Bounds bounds;

        public TerrainChunk(Vector2 coord, int size, Transform parent)
        {
            position = coord * size;
            bounds = new Bounds(position, Vector2.one * size);
            Vector3 positionV3 = new Vector3(position.x, 0, position.y);

            if(positionV3 == new Vector3(0, 0, 0))
            {
                meshObject = Instantiate(ChunkManager.instance.chunksAvailable[0], new Vector3(0, 0, 0), Quaternion.identity);
                meshObject.transform.position = positionV3;
                meshObject.transform.localScale = Vector3.one * size;
                meshObject.transform.parent = parent;
                ChunkManager.instance.chunks += 1;
                //ChunkManager.instance.navSurf.BuildNavMesh();
            }
            else
            {
                int r = Random.Range(0, ChunkManager.instance.chunksAvailable.Length);
                meshObject = Instantiate(ChunkManager.instance.chunksAvailable[r], new Vector3(0, 0, 0), Quaternion.identity);
                meshObject.transform.position = positionV3;
                meshObject.transform.localScale = Vector3.one * size;
                meshObject.transform.parent = parent;
                ChunkManager.instance.chunks += 1;
                //ChunkManager.instance.navSurf.BuildNavMesh();
                SetVisible(false);
            }
        }

        public void UpdateTerrainChunk()
        {
            float viewerDistFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(playerPos));
            bool visible = viewerDistFromNearestEdge <= (maxViewDist);
            SetVisible(visible);
        }

        public void SetVisible(bool visible)
        {
            meshObject.SetActive(visible);
        }

        public bool IsVisible()
        {
            return meshObject.activeSelf;
        }

        
    }

    void DestroyAllChildren(GameObject parent)
    {
        // Loop through each child of the parent GameObject
        foreach (Transform child in parent.transform)
        {
            // Destroy the child GameObject
            child.gameObject.SetActive(false);
        }
        terrainChunksVisibleLastUpdate.Clear();
        terrainChunkDictionary.Clear();
    }

    public void ChangeDecor(string _decor)
    {
        if(_decor == "beach")
        {
            Instantiate(changeDecorEffect, player.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            player.GetComponent<PlayerMovement>().SpeedOnChangeDecor();
            chunkManagerBeach.enabled = true;
            DestroyAllChildren(this.gameObject);
            this.enabled = false;
            //chunksAvailable = chunksBeach;
            //player.position = new Vector3(0, 1, -6.75f);
        }

        if (_decor == "city")
        {
            chunksAvailable = chunksCity;
        }
    }
}
