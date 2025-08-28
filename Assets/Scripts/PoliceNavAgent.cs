using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceNavAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed, rotatingSpeed;

    public GameObject target;
    public Rigidbody rb;
    public static PoliceNavAgent instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'un inventaire");
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
        agent.velocity = transform.forward * speed;

        agent.SetDestination(pointTarget);

    }
}
