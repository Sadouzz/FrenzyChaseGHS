using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{

	public AudioSource coinSound;

    private void OnTriggerEnter(Collider collision)
    {
    	if(collision.CompareTag("Player"))
    	{
    		StartCoroutine(CoinPicked());
    	}
    }

    IEnumerator CoinPicked()
    {
        GetComponent<AudioSource>().Play(0);
        yield return new WaitForSecondsRealtime(0.1f);
        
        Destroy(gameObject);
    }

    private void Update()
    {

    	Quaternion newRotation = new Quaternion(transform.rotation.x,transform.rotation.y,transform.rotation.z,transform.rotation.w);
        newRotation *= Quaternion.Euler(0, 90, 0); // this add a 90 degrees Y rotation
        transform.rotation= Quaternion.Slerp(transform.rotation, newRotation,2.5f * Time.deltaTime);
    }
}
