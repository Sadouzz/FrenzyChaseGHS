using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorSpawner : MonoBehaviour
{
    public GameObject[] objectToSpawn;
    public Transform[] spawnPos;
    float timer;
    // Start is called before the first frame update
    void Start()
    {

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
    }

    void SpawnRandomObject()
    {
        int r = Random.Range(0, spawnPos.Length);
        int p = Random.Range(0, objectToSpawn.Length);
        Instantiate(objectToSpawn[p], new Vector3(spawnPos[r].position.x, 0, spawnPos[r].position.z), spawnPos[r].rotation);
    }
}
