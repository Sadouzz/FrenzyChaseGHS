using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsLoot : MonoBehaviour
{
	public GameObject player;
	public Rigidbody rb;
	public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(player==null)
    	{
    		player = GameObject.FindGameObjectWithTag("Player");
    	}
    	else{
    		transform.LookAt(player.transform.position);
        	rb.velocity = transform.forward * speed; 
    	}
    }

    private void OnTriggerEnter(Collider collision)
    {
    	if(collision.CompareTag("Player"))
    	{
    		CoinPicked();
    	}
    }

    void CoinPicked()
    {
        InventoryScript.instance.coins += 5;
        Destroy(gameObject);
    }
}
