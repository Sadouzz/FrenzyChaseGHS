using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
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
        if (coll.collider.CompareTag("Police"))
        {
            if(coll.gameObject != null)
            {
                coll.gameObject.GetComponent<DamagePoliceCar>().Die();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }            
        }

        if (coll.collider.CompareTag("VanPolice"))
        {
            if (coll.gameObject != null)
            {
                coll.gameObject.GetComponent<DamageFourgon>().Die();
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
}
