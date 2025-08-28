using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirePhysicsPolice : MonoBehaviour
{
    public Rigidbody policeRigidbody;
    private Transform tireTransform;
    public Transform policeTransform, wheelVisual; // Référence au mesh de la roue
    public float suspensionRestDist, springStrength, springDamper, tireMass, tireGripFactor, policeTopSpeed;
    public bool isFrontWheel;
    public float maxSteerAngle; // Angle maximum de braquage
    public float steerInput, accelInput;
    public AnimationCurve powerCurve;

    public LayerMask groundLayer;

    public GameObject target; // Référence au joueur

    void Start()
    {
        tireTransform = gameObject.GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            // Calculer la direction vers le joueur
            Vector3 directionToTarget = target.transform.position - transform.parent.position;
            float distanceToTarget = directionToTarget.magnitude;

            // Normaliser la direction
            directionToTarget.Normalize();

            // Appliquer l'accélération
            /*if (distanceToTarget > 50f) // Ajustez cette distance selon vos besoins
            {
                accelInput = 1f; // Accélérer vers le joueur
            }
            else
            {
                accelInput = 0f; // Arrêter si trop proche
            }*/

            // Calculer la direction de braquage
            float angleToTarget = Vector3.SignedAngle(transform.parent.forward, directionToTarget, Vector3.up);
            steerInput = Mathf.Clamp(angleToTarget / maxSteerAngle, -1f, 1f);

            // Appliquer les forces
            Vector3 accel = Acceleration();
            Vector3 suspension = Suspension();
            Vector3 steer = Steering();
            WheelVisual();
        }
    }

    void WheelVisual()
    {
        if (wheelVisual != null)
        {
            RaycastHit hit;
            Vector3 startPos = tireTransform.position;
            Vector3 endPos = tireTransform.position - tireTransform.up * suspensionRestDist;

            // Vérifier si la roue touche le sol
            if (Physics.Raycast(startPos, -tireTransform.up, out hit, suspensionRestDist, groundLayer))
            {
                // Ajuster la hauteur de la roue en fonction du point de contact
                wheelVisual.position = hit.point + (tireTransform.up * 0.15f); // 0.1f pour éviter qu'elle ne s'enfonce
            }
            else
            {
                // Si la roue est en l'air, elle reste à sa position de repos
                wheelVisual.position = endPos;
            }

            // Calcul de la rotation de la roue
            float wheelRadius = wheelVisual.localScale.y / 2;
            float rotationSpeed = policeRigidbody.velocity.magnitude / (2 * Mathf.PI * wheelRadius) * Mathf.Rad2Deg;

            // Déterminer si le véhicule avance ou recule
            float direction = Vector3.Dot(policeRigidbody.velocity, transform.forward) >= 0 ? 1f : -1f;

            // Appliquer la rotation dans le bon sens
            wheelVisual.Rotate(Vector3.right, direction * rotationSpeed * 2 * Time.deltaTime);
        }
    }

    Vector3 Acceleration()
    {
        RaycastHit tireRay;
        Vector3 accelDir = tireTransform.forward;
        if (Physics.Raycast(tireTransform.position, -tireTransform.up, out tireRay, suspensionRestDist, groundLayer))
        {
            float carSpeed = Vector3.Dot(policeTransform.forward, policeRigidbody.velocity);

            float normalizedSpeed = Mathf.Clamp01(Mathf.Abs(carSpeed) / policeTopSpeed);

            float availableTorque = powerCurve.Evaluate(normalizedSpeed) * accelInput;

            policeRigidbody.AddForceAtPosition(accelDir * availableTorque, tireTransform.position);
            Debug.DrawRay(tireTransform.position, accelDir * availableTorque, Color.green);
            return accelDir * availableTorque;
        }
        return Vector3.zero;
    }

    Vector3 Suspension()
    {
        RaycastHit tireRay;
        Vector3 springDir = tireTransform.up;
        if (Physics.Raycast(tireTransform.position, -springDir, out tireRay, suspensionRestDist, groundLayer))
        {


            Vector3 tireWorldVel = policeRigidbody.GetPointVelocity(tireTransform.position);

            float offset = suspensionRestDist - tireRay.distance;

            float vel = Vector3.Dot(springDir, tireWorldVel);

            float force = (offset * springStrength) - (vel * springDamper);

            policeRigidbody.AddForceAtPosition(springDir * force, tireTransform.position);
            Debug.DrawRay(tireTransform.position, springDir * force, Color.red);
            return springDir * force;
        }
        return Vector3.zero;
    }

    Vector3 Steering()
    {
        if (isFrontWheel) // Appliquer la direction seulement aux roues avant
        {
            float steerAngle = maxSteerAngle / 2 * steerInput;
            tireTransform.localRotation = Quaternion.Euler(0f, steerAngle, 0f);
        }
        RaycastHit tireRay;
        Vector3 steeringDir = tireTransform.right;
        if (Physics.Raycast(tireTransform.position, -tireTransform.up, out tireRay, suspensionRestDist, groundLayer))
        {
            //springDir = tireTransform.up;

            Vector3 tireWorldVel = policeRigidbody.GetPointVelocity(tireTransform.position);

            float steeringVel = Vector3.Dot(steeringDir, tireWorldVel);

            float desiredVelChange = -steeringVel * tireGripFactor;

            float desiredAccel = desiredVelChange / Time.fixedDeltaTime;

            policeRigidbody.AddForceAtPosition(steeringDir * tireMass * desiredAccel, tireTransform.position);
            Debug.DrawRay(tireTransform.position, steeringDir * desiredAccel * tireMass, Color.blue);
            return steeringDir * desiredAccel * tireMass;
        }
        return Vector3.zero;
    }
}