using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalTowerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Police") || coll.collider.CompareTag("Player") || coll.collider.CompareTag("VanPolice") && PlayerMovement.instance.currentLife > 0)
        {
            Debug.LogError("Touched");
        }
    }
}
