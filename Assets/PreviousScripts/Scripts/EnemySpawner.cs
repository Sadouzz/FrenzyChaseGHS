using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public Transform[] spawnPos;

	public int scoreMilestone;
	public int milestoneIncreaser;

	public int lastSpawnPos;
    float timer;

	public int policeCarRequired;

	public int currentPoliceCar, destroyedCars;
	public GameObject target;
	public GameObject[] policeCar;

	public static EnemySpawner instance;

    string chal2;

    private void Awake()
    {
    	if(instance != null)
    	{
    		Debug.LogWarning("Il y a plus d'un inventaire");
    		return;
    	}
    	instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPoliceCar();
        SpawnPoliceCar();
        SpawnPoliceCar();
        SpawnPoliceCar();
        destroyedCars = 10;
    }

    // Update is called once per frame
    void Update()
    {
        chal2 = PlayerPrefs.GetString("Challenge2", "no");
        if(target == null)
        {
        	target = GameObject.FindGameObjectWithTag("Player");
        	return;
        }

        MilestoneIncreaser();

        if(destroyedCars >= 10  && chal2 == "no")
        {
            PlayerPrefs.SetString("Challenge2", "done");
        }

        timer += Time.deltaTime;
            if(timer >= 10 && 15 > currentPoliceCar)
            {
                SpawnPoliceCar();
                timer = 0;
            }
    }

    void SpawnPoliceCar()
    {
    	int p = Random.Range(0, policeCar.Length);
    	int r = Random.Range(0, spawnPos.Length);

    	Instantiate(policeCar[p], new Vector3(spawnPos[r].position.x, 0, spawnPos[r].position.z), Quaternion.identity);

    	lastSpawnPos = r;
    	currentPoliceCar++;
    }

    void MilestoneIncreaser()
    {
    	if(Inventory.instance.score >= scoreMilestone)
    	{
    		scoreMilestone += milestoneIncreaser;

    		if(policeCarRequired < 12)
    		   policeCarRequired++;
    	}
    }
}
