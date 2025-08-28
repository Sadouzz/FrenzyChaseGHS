using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDisappearing : MonoBehaviour
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
        if (coll.collider.CompareTag("Police") || coll.collider.CompareTag("VanPolice"))
        {
            ChunkManager.instance.DisableObstacle(this.gameObject);
        }

        

        if(coll.collider.CompareTag("Player"))
        {
            if (gameObject.transform.parent.gameObject.CompareTag("MetalTower"))
            {
                Debug.LogError("Metal");
            }
            Destroy(gameObject);
        }
    }
}
