using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMenuUpdgradeRotation : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        newRotation *= Quaternion.Euler(0, 0, 90); // this add a 90 degrees Y rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed * Time.deltaTime);
    }
}
