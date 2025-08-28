using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboPowerUp : MonoBehaviour
{
	public int angleSpeed;
	public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * angleSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider coll)
    {
    	if(coll.CompareTag("Player"))
    	{
    		StartCoroutine(Touched());
    	}
    }

    IEnumerator Touched()
    {
    	PlayerController.instance.turbo = true;
    	audio.Play(0);
    	yield return new WaitForSeconds(.5f);
    	Destroy(gameObject);
    }
}
