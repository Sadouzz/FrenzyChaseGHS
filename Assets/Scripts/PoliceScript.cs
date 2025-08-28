using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceScript : MonoBehaviour
{
    public float speed ;                     // Vitesse de base
    public float rotatingSpeed = 5f;              // Vitesse de rotation
    public float obstacleAvoidanceDistance = 6f;  // Distance de détection
    public float obstacleAvoidanceRadius = 1.5f;  // Rayon de détection (SphereCast)
    public float avoidanceStrength = 5f;          // Force d'esquive
    public float slowdownFactor = 0.5f;           // Facteur de ralentissement pendant esquive

    public GameObject target;
    public Rigidbody rb;
    public static PoliceScript instance;
    public AudioSource policeSiren;

    [Header("Optimisation")]
    [SerializeField] private float colliderActivationDistance = 100f;
    [SerializeField] private float checkInterval = 0.3f; // Pour éviter de checker chaque frame

    private Collider policeCollider;
    private float nextCheckTime;
    private float sqrActivationDistance;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;

        policeCollider = GetComponent<Collider>();
        sqrActivationDistance = colliderActivationDistance * colliderActivationDistance;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CheckColliderState();
    }

    void CheckColliderState()
    {
        if (target == null || policeCollider == null) return;

        // Utilisation de sqrMagnitude pour meilleure performance
        bool shouldBeActive = (target.transform.position - transform.position).sqrMagnitude <= sqrActivationDistance;

        if (policeCollider.enabled != shouldBeActive)
        {
            policeCollider.enabled = shouldBeActive;

            // Optionnel : désactive aussi le Rigidbody si très loin
            if (rb != null)
            {
                rb.isKinematic = !shouldBeActive;
            }
        }
    }

    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        Vector3 directionToTarget = (target.transform.position - transform.position).normalized;
        Vector3 finalDirection = directionToTarget;
        float currentSpeed = speed;

        // Détection d'obstacles via SphereCast
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, obstacleAvoidanceRadius, transform.forward, out hit, obstacleAvoidanceDistance))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                // Calcule une direction perpendiculaire à l'obstacle pour éviter
                Vector3 avoidDir = Vector3.Cross(hit.normal, Vector3.up).normalized;
                finalDirection = Vector3.Lerp(directionToTarget, avoidDir, avoidanceStrength * Time.deltaTime).normalized;

                // Ralentir pendant l’esquive
                currentSpeed *= slowdownFactor;
            }
        }

        // Calcul de rotation vers la direction finale
        Vector3 pointTarget = transform.position - (transform.position + finalDirection);
        float turnAmount = Vector3.Cross(pointTarget, transform.forward).y;

        rb.angularVelocity = rotatingSpeed * turnAmount * Vector3.up;
        rb.velocity = transform.forward * currentSpeed;
    }

    public void MuteVolume()
    {
        if (policeSiren != null)
            policeSiren.volume = 0;
    }

    private void OnDrawGizmos()
    {
        // Debug de la zone de détection
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward * obstacleAvoidanceDistance, obstacleAvoidanceRadius);
    }
}
