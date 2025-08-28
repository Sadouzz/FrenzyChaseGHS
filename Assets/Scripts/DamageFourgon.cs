using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFourgon : MonoBehaviour
{
	public float invincibleTime;
	public int life;

	public GameObject smokeEffect, fireEffect, explosionEffect;
	public AudioSource burn, explosion;
    public GameObject[] componentsToHide;

	public int currentLife;
	public float currentInvincibleTime;

	bool isColliding;
    public Renderer renderer;

    public bool follow = true;
    public BoxCollider collider;

    public static DamageFourgon instance;

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
        currentLife = life;
        burn.enabled = false;
        explosion.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isColliding)
        {
        	currentInvincibleTime -= Time.deltaTime;
        	if(currentInvincibleTime <= 0)
        	{
        		ReduceLife();
        	}
        }
    }

    private void OnCollisionStay(Collision coll)
    {
    	if(coll.collider.CompareTag("Police") || coll.collider.CompareTag("Player") || coll.collider.CompareTag("VanPolice"))
    	{
    		isColliding = true;
    	}
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.CompareTag("Police") || coll.collider.CompareTag("Player") || coll.collider.CompareTag("VanPolice"))
        {
            isColliding = true;
        }

        if (coll.collider.CompareTag("Obstacle"))
        {
            StartCoroutine(Hide());
        }
    }

    private void OnCollisionExit(Collision coll)
    {
    	if(coll.collider.CompareTag("Police") || coll.collider.CompareTag("Player") || coll.collider.CompareTag("VanPolice"))
    	{
    		isColliding = false;
    	}
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("ThermalCircleZone"))
        {
            Die();
        }
    }


    public void ReduceLife()
    {
    	currentLife--;
    	currentInvincibleTime = invincibleTime;
        if(currentLife == 2)
        {
            smokeEffect.SetActive(true);
        }
    	else if(currentLife == 1)
    	{
    		fireEffect.SetActive(true);
    		burn.enabled = true;
    	}

    	else if(currentLife <= 0)
    	{
    		StartCoroutine(Hide());
    	}
    }

    public void Die()
    {
        StartCoroutine(Hide());
    }

    bool IsCarVisible()
    {
        if (renderer.isVisible)
            return true;
        return false;
    }

    IEnumerator Hide()
    {
        PoliceSpawner.instance.currentPoliceCar--;
        InventoryScript.instance.score += 15;
        burn.enabled = false;
        fireEffect.SetActive(false);
        smokeEffect.SetActive(false);
        explosionEffect.SetActive(true);
        explosion.enabled = true;
        if (IsCarVisible())
        {
            PoliceSpawner.instance.destroyedCars++;
        }
        for (int i = 0; i < componentsToHide.Length; i++)
        {
            componentsToHide[i].SetActive(false);
        }
        follow = false;
        

        collider.enabled = false;
        yield return new WaitForSeconds(2);
        DestabilizerScript.instance.RemovePoliceCarFromList(this.gameObject);
        Destroy(gameObject);
    }
}
