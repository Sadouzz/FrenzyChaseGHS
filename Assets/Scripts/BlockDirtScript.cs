using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDirtScript : MonoBehaviour
{
    public Transform car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, car.position.z);
    }
}
