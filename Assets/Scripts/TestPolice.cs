using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPolice : MonoBehaviour
{
    public float speed, rotatingSpeed;

    public GameObject target;
    public Rigidbody rb;
    public static TestPolice instance;
    public AudioSource policeSiren;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        Vector3 pointTarget = transform.position - target.transform.position;
        float value = Vector3.Cross(pointTarget, transform.forward).y;

        rb.angularVelocity = rotatingSpeed * value * new Vector3(0, 1, 0);
    }

    public void MuteVolume()
    {
        policeSiren.volume = 0;
    }
}
