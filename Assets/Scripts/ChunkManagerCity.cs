using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManagerCity : MonoBehaviour
{
    public ChunkManagerCity chunkManagerCity;
    public GameObject changeDecorEffect;

    public const float maxViewDist = 50;
    public Transform player;

    public static Vector2 playerPos;
    int chunkSize, chunksVisibleInViewDist;
    public int chunks;

    public GameObject[] chunksBeach;
    public GameObject[] chunksCity;

    public GameObject[] chunksAvailable;

    Dictionary<Vector2, TerrainChunkCity> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunkCity>();
    List<TerrainChunkCity> terrainChunksVisibleLastUpdate = new List<TerrainChunkCity>();

    public static ChunkManagerCity instance;
    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'un inventaire");
            return;
        }
        instance = this;
    }
    void Start()
    {
        chunkSize = 50;
        chunksVisibleInViewDist = Mathf.RoundToInt(maxViewDist / chunkSize);
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
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

        for (int yOffset = -chunksVisibleInViewDist; yOffset <= chunksVisibleInViewDist; yOffset++)
        {
            for (int xOffset = -chunksVisibleInViewDist; xOffset <= chunksVisibleInViewDist; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);
                if (terrainChunkDictionary.ContainsKey(viewedChunkCoord))
                {
                    terrainChunkDictionary[viewedChunkCoord].UpdateTerrainChunk();
                    if (terrainChunkDictionary[viewedChunkCoord].IsVisible())
                    {
                        terrainChunksVisibleLastUpdate.Add(terrainChunkDictionary[viewedChunkCoord]);
                    }
                }
                else
                {
                    terrainChunkDictionary.Add(viewedChunkCoord, new TerrainChunkCity(viewedChunkCoord, chunkSize, transform));
                }
            }
        }
    }

    public class TerrainChunkCity
    {
        GameObject meshObject;
        Vector2 position;
        Bounds bounds;

        public TerrainChunkCity(Vector2 coord, int size, Transform parent)
        {
            position = coord * size;
            bounds = new Bounds(position, Vector2.one * size);
            Vector3 positionV3 = new Vector3(position.x, 0, position.y);

            meshObject = Instantiate(ChunkManagerCity.instance.chunksAvailable[0], new Vector3(0, 0, 0), Quaternion.identity);
            meshObject.transform.position = positionV3;
            meshObject.transform.localScale = Vector3.one * size;
            meshObject.transform.parent = parent;
            ChunkManagerBeach.instance.chunks += 1;
            SetVisible(false);

            /*if (positionV3 == new Vector3(0, 0, 0))
            {
                meshObject = Instantiate(ChunkManagerBeach.instance.chunksAvailable[0], new Vector3(0, 0, 0), Quaternion.identity);
                meshObject.transform.position = positionV3;
                meshObject.transform.localScale = Vector3.one * size;
                meshObject.transform.parent = parent;
                ChunkManagerBeach.instance.chunks += 1;
            }
            else
            {
                int r = Random.Range(0, ChunkManagerBeach.instance.chunksAvailable.Length);
                meshObject = Instantiate(ChunkManagerBeach.instance.chunksAvailable[r], new Vector3(0, 0, 0), Quaternion.identity);
                meshObject.transform.position = positionV3;
                meshObject.transform.localScale = Vector3.one * size;
                meshObject.transform.parent = parent;
                ChunkManagerBeach.instance.chunks += 1;
                SetVisible(false);
            }*/
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
}
