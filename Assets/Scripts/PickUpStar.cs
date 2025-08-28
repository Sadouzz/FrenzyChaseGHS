using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStar : MonoBehaviour
{
    public AudioSource picked;
    void Start()
    {
        transform.position = new Vector3(transform.position.x, .5f, transform.position.z);
        picked = GameObject.FindGameObjectWithTag("EventSystemStar").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        newRotation *= Quaternion.Euler(0, 90, 0); // this add a 90 degrees Y rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 2.5f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("done");
            StarPicked();
        }
    }

    void StarPicked()
    {
        InventoryScript.instance.starsPicked += 1;
        picked.Play();
        Destroy(gameObject);
    }
}
