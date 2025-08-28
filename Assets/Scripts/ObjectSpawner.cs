using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectToSpawn;
    public Transform[] spawnPos;
    float timer;
    public GameObject player;
    public float maxDistance = 50f;
    private float nextCheckTime;
    public float checkInterval = 0.5f;


    public static ObjectSpawner instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void RefreshSpawningPositions()
    {
        GameObject[] spawnPosGameObjects = GameObject.FindGameObjectsWithTag("SpawnPos");
        List<Transform> validSpawns = new List<Transform>();

        // Récupère le plan de la caméra pour le champ de vision
        Plane[] cameraFrustumPlanes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

        foreach (var spawnPos in spawnPosGameObjects)
        {
            float dist = Vector3.Distance(player.transform.position, spawnPos.transform.position);

            // Vérifie la distance ET si le point est hors du champ de vision
            if (dist < maxDistance && !IsInFieldOfView(spawnPos.transform.position))
            {
                validSpawns.Add(spawnPos.transform);
            }
        }

        spawnPos = validSpawns.ToArray();
    }

    private bool IsInFieldOfView(Vector3 worldPosition)
    {
        // Convertit la position mondiale en position sur l'écran
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(worldPosition);

        // Vérifie si le point est dans le champ de vision (entre 0 et 1 sur les axes x et y)
        bool onScreen = screenPoint.z > 0 &&
                       screenPoint.x > 0 && screenPoint.x < 1 &&
                       screenPoint.y > 0 && screenPoint.y < 1;

        return onScreen;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            SpawnRandomObject();
            timer = 0;
        }
        if (Time.time > nextCheckTime)
        {
            RefreshSpawningPositions();
            nextCheckTime = Time.time + checkInterval;
        }
    }

    void SpawnRandomObject()
    {
        if (spawnPos.Length == 0 || objectToSpawn.Length == 0)
            return;

        float checkRadius = 3f;
        int maxTries = spawnPos.Length; // Essayer autant de fois que de points
        int tries = 0;

        while (tries < maxTries)
        {
            int r = Random.Range(0, spawnPos.Length);
            int p = Random.Range(0, objectToSpawn.Length);
            Vector3 spawnPosition = new Vector3(spawnPos[r].position.x, 0, spawnPos[r].position.z);

            // Vérifie s’il y a des triggers autour
            Collider[] colliders = Physics.OverlapSphere(
                spawnPosition,
                checkRadius,
                ~0, // tout layer
                QueryTriggerInteraction.Collide // inclure les triggers
            );

            bool areaClear = true;

            foreach (var col in colliders)
            {
                if (col.CompareTag("Crate")) // ou toute autre logique
                {
                    areaClear = false;
                    break;
                }
            }

            if (areaClear)
            {
                GameObject spawned = Instantiate(objectToSpawn[p], spawnPosition, spawnPos[r].rotation);
                spawned.tag = "Crate"; // optionnel : tag pour vérification future
                return;
            }

            tries++;
        }

        Debug.Log("Aucun point de spawn disponible : tous sont occupés.");
    }

}
