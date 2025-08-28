using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestabilizerBulletScript : MonoBehaviour
{
    public GameObject target;
    public Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.LookAt(target.transform);
            rb.velocity = transform.forward * speed;
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSecondsRealtime(5);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Police") || coll.collider.CompareTag("VanPolice") || coll.collider.CompareTag("Obstacle"))
        {
            if (coll.gameObject != null)
            {
                coll.gameObject.GetComponent<PoliceScript>().target = GameObject.FindGameObjectWithTag("Police");
                if(coll.gameObject.GetComponent<PoliceScript>().target == null)
                {
                    coll.gameObject.GetComponent<PoliceScript>().target = GameObject.FindGameObjectWithTag("VanPolice");
                }
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        if (coll.collider.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Police") || collision.CompareTag("VanPolice") || collision.CompareTag("Obstacle"))
        {
            if (collision.gameObject != null)
            {
                collision.gameObject.GetComponent<PoliceScript>().target = GameObject.FindGameObjectWithTag("Police");
                if (collision.gameObject.GetComponent<PoliceScript>().target == null)
                {
                    collision.gameObject.GetComponent<PoliceScript>().target = GameObject.FindGameObjectWithTag("VanPolice");
                }
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
