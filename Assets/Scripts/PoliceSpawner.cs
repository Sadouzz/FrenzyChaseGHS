using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    public Transform[] spawnPos;

    public int scoreMilestone;
    public int milestoneIncreaser;

    public int lastSpawnPos;
    float timer;

    public int policeCarRequired;

    public int currentPoliceCar, destroyedCars;

    public float policeSpeed = 8;
    public GameObject target, policeNavMesh;
    public GameObject[] policeCar;
    public GameObject[] policeInGame;
    public float maxDistance = 50f;

    private float nextCheckTime;
    public float checkInterval = 0.5f;

    int map;

    public static PoliceSpawner instance;


    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelaySpawn());
    }

    public void RefreshSpawningPositions()
    {
        GameObject[] spawnPosGameObjects = GameObject.FindGameObjectsWithTag("SpawnPos");
        List<Transform> validSpawns = new List<Transform>();

        // Récupère le plan de la caméra pour le champ de vision
        Plane[] cameraFrustumPlanes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

        foreach (var spawnPos in spawnPosGameObjects)
        {
            float dist = Vector3.Distance(target.transform.position, spawnPos.transform.position);

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
        map = PlayerPrefs.GetInt("map", 0);
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        if(map == 2)
        {
            policeCar[0] = policeNavMesh;
        }

        MilestoneIncreaser();

        if (Time.time > nextCheckTime)
        {
            RefreshSpawningPositions();
            nextCheckTime = Time.time + checkInterval;
        }

        timer += Time.deltaTime;
        if(timer >= 4.5f && 20 > currentPoliceCar && !PlayerMovement.instance.stopAll)
        {
            SpawnPoliceCar();
            timer = 0;
        }

    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSecondsRealtime(1);
        SpawnPoliceCar();
    }

    void SpawnPoliceCar()
    {
        int r = Random.Range(0, spawnPos.Length);
        if (InventoryScript.instance.score < 300)
        {
            var spawnedCar = Instantiate(policeCar[0], new Vector3(spawnPos[r].position.x, 0, spawnPos[r].position.z), Quaternion.identity);
            spawnedCar.GetComponent<PoliceScript>().speed = policeSpeed;
            lastSpawnPos = r;
            currentPoliceCar++;
        }
        else
        {
            int p = Random.Range(0, policeCar.Length);

            var spawnedCar = Instantiate(policeCar[p], new Vector3(spawnPos[r].position.x, 0, spawnPos[r].position.z), Quaternion.identity);
            spawnedCar.GetComponent<PoliceScript>().speed = policeSpeed;
            lastSpawnPos = r;
            currentPoliceCar++;
        }


        if (currentPoliceCar < policeCarRequired)
        {
            SpawnPoliceCarAgain(r+1);
        }
        

    }

    void SpawnPoliceCarAgain(int pos)
    {
        if (InventoryScript.instance.score < 250)
        {
            var spawnedCar = Instantiate(policeCar[0], new Vector3(spawnPos[pos].position.x, 0, spawnPos[pos].position.z), Quaternion.identity);
            spawnedCar.GetComponent<PoliceScript>().speed = policeSpeed;
            currentPoliceCar++;
        }
        else
        {
            int p = Random.Range(0, policeCar.Length);

            var spawnedCar = Instantiate(policeCar[p], new Vector3(spawnPos[pos].position.x, 0, spawnPos[pos].position.z), Quaternion.identity);
            spawnedCar.GetComponent<PoliceScript>().speed = policeSpeed;
            currentPoliceCar++;
        }
    }

    public void IncreasePoliceSpeed()
    {
        policeSpeed += .075f;
    }

    void MilestoneIncreaser()
    {
        if(InventoryScript.instance.score >= scoreMilestone)
        {
            scoreMilestone += milestoneIncreaser;

            if(policeCarRequired < 20)
               policeCarRequired++;
        }
    }

    public void DestroyAllPolice()
    {
        policeInGame = GameObject.FindGameObjectsWithTag("Police");
        for(int i = 0; i < policeInGame.Length; i++)
        {
            Destroy(policeInGame[i]);
        }
    }
}
