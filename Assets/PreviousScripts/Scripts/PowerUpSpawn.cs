using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
	public Transform[] spawnPos;
	public GameObject[] powerUp;
	int lastPowerUp, lastSpawnPos;
	float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 15)
        {
        	Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
    	int p = Random.Range(0, powerUp.Length);
    	int r = Random.Range(0, spawnPos.Length);

    	while(lastSpawnPos == r)
    	{
    		r = Random.Range(0, spawnPos.Length);
    	}

    	while(lastSpawnPos == p)
    	{
    		p = Random.Range(0, spawnPos.Length);
    	}

    	Instantiate(powerUp[p], new Vector3(spawnPos[r].position.x, 1.25f, spawnPos[r].position.z), Quaternion.identity);

    	lastSpawnPos = r;
    	lastPowerUp = p;
    }
}
