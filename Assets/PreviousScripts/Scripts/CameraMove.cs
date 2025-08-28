using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public Transform Player;
	public float offset;

	void Start()
	{

	}

    void Update()
    {
    	Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = new Vector3(Player.position.x, Player.position.y + 35, Player.position.z + offset);
    }
}
