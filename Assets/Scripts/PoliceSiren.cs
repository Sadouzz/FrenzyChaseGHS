using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSiren : MonoBehaviour
{
	void Update () {
        Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        newRotation *= Quaternion.Euler(0, 90, 0); // this add a 90 degrees Y rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 2.5f * Time.deltaTime);
    }
}
