using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGround : MonoBehaviour
{
	public Renderer groundRenderer;
	public float parralexSpeed = 10;

	private GameObject player;
	float offsetX, offsetY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
        	player = GameObject.FindGameObjectWithTag("Player");
        }

        if(player != null)
        {
        	ScrollBackground(player.GetComponent<PlayerController>().speed, groundRenderer);
        }
    }

    void FixedUpdate()
    {
    	if(player == null)
    	{
    		return;
    	}
    	Movement();
    }

    void Movement()
    {
    	float posX = player.transform.position.x;
    	float posZ = player.transform.position.z;

    	transform.position = new Vector3(posX, transform.position.y, posZ);
    }

    private void ScrollBackground(float scrollSpeed, Renderer rend)
    {
    	offsetX = transform.position.x / parralexSpeed;
    	offsetY = transform.position.z / parralexSpeed;

    	rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }
}
