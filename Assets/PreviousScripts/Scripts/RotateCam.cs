using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
	public Vector3 playerVector;

	public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	playerVector = new Vector3(player.rotation.x, player.rotation.y, player.rotation.z);

        transform.Rotate(playerVector * Time.deltaTime);
    }
}
