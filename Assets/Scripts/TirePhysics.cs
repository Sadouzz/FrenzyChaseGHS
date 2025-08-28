using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirePhysics : MonoBehaviour
{
    public Rigidbody carRigidbody;
    private Transform tireTransform;
    public Transform carTransform, wheelVisual; // Référence au mesh de la roue
    public float suspensionRestDist, springStrength, springDamper, tireMass, tireGripFactor, carTopSpeed;

    public float maxSteerAngle; // Angle maximum de braquage
    public bool isFrontWheel = false; // Détermine si la roue est une roue avant
    public float steerInput, accelInput;
    public AnimationCurve powerCurve;

    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        tireTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //accelInput = 1;// Input.GetAxis("Vertical");
        if (Input.GetMouseButton(0))
        {
            float x = Input.mousePosition.x;
            if (x < Screen.width / 2 && x > 0)
            {
                if(steerInput > 0)
                {
                    steerInput = 0;
                }
                if(steerInput > -1)
                {
                    steerInput -= 1f * Time.deltaTime;
                }
                //PlayerMovement.instance.MoveLeft();
            }

            if (x > Screen.width / 2 && x < Screen.width)
            {
                if (steerInput < 0)
                {
                    steerInput = 0;
                }
                if (steerInput < 1)
                {
                    steerInput += 1f * Time.deltaTime;
                }
                //PlayerMovement.instance.MoveRight();
            }
            PlayerMovement.instance.sliderTimer += 1 * Time.deltaTime;
        }
        else
        {
            steerInput = 0;
            //PlayerMovement.instance.leftSteerSmoke.Stop();
            //PlayerMovement.instance.rightSteerSmoke.Stop();
            //PlayerMovement.instance.rightSmokeBool = false;
            //PlayerMovement.instance.leftSmokeBool = false;
            PlayerMovement.instance.sliderTimer = 0;
        }
        //steerInput = Input.GetAxis("Horizontal");
        Vector3 accel = Acceleration();
        Vector3 suspension = Suspension();
        Vector3 steer = Steering();
        WheelVisual();
        AntiRoll();

        Debug.DrawRay(tireTransform.position, accel + suspension + steer, Color.yellow);
        
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
            float rotationSpeed = carRigidbody.velocity.magnitude / (2 * Mathf.PI * wheelRadius) * Mathf.Rad2Deg;

            // Déterminer si le véhicule avance ou recule
            float direction = Vector3.Dot(carRigidbody.velocity, transform.forward) >= 0 ? 1f : -1f;

            // Appliquer la rotation dans le bon sens
            wheelVisual.Rotate(Vector3.right, direction * rotationSpeed * 2 * Time.deltaTime);
        }
    }

    void AntiRoll()
    {
        RaycastHit hitLeft, hitRight;
        float leftCompression = 0f, rightCompression = 0f;

        Vector3 leftWheelPos = tireTransform.position + transform.right * -0.5f; // Ajustez en fonction de la largeur de la voiture
        Vector3 rightWheelPos = tireTransform.position + transform.right * 0.5f;

        // Vérifiez la compression de la roue gauche
        if (Physics.Raycast(leftWheelPos, -transform.up, out hitLeft, suspensionRestDist, groundLayer))
        {
            leftCompression = suspensionRestDist - hitLeft.distance; // Compression de la roue gauche
        }

        // Vérifiez la compression de la roue droite
        if (Physics.Raycast(rightWheelPos, -transform.up, out hitRight, suspensionRestDist, groundLayer))
        {
            rightCompression = suspensionRestDist - hitRight.distance; // Compression de la roue droite
        }

        // Calculez la force d'anti-roulis
        float antiRollForce = (leftCompression - rightCompression) * springStrength;

        // Appliquez la force d'anti-roulis uniquement si la voiture est en mouvement
        if (carRigidbody.velocity.magnitude > 0.1f) // Seuil pour éviter les mouvements indésirables à l'arrêt
        {
            carRigidbody.AddForceAtPosition(transform.up * antiRollForce, leftWheelPos);
            carRigidbody.AddForceAtPosition(-transform.up * antiRollForce, rightWheelPos);
        }
    }


    Vector3 Acceleration()
    {
        RaycastHit tireRay;
        Vector3 accelDir = tireTransform.forward;
        if (Physics.Raycast(tireTransform.position, -tireTransform.up, out tireRay, suspensionRestDist, groundLayer))
        {
            float carSpeed = Vector3.Dot(carTransform.forward, carRigidbody.velocity);

            float normalizedSpeed = Mathf.Clamp01(Mathf.Abs(carSpeed) / carTopSpeed);

            float availableTorque = powerCurve.Evaluate(normalizedSpeed) * accelInput;

            carRigidbody.AddForceAtPosition(accelDir * availableTorque, tireTransform.position);
            
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
            //springDir = tireTransform.up;

            Vector3 tireWorldVel = carRigidbody.GetPointVelocity(tireTransform.position);

            float offset = suspensionRestDist - tireRay.distance;

            float vel = Vector3.Dot(springDir, tireWorldVel);

            float force = (offset * springStrength) - (vel * springDamper);

            carRigidbody.AddForceAtPosition(springDir * force, tireTransform.position);
            Debug.DrawRay(tireTransform.position, springDir * force, Color.red);
            return springDir * force;
        }
        return Vector3.zero;
    }

    Vector3 Steering()
    {
        if (isFrontWheel) // Appliquer la direction seulement aux roues avant
        {
            float steerAngle = maxSteerAngle/2 * steerInput;
            tireTransform.localRotation = Quaternion.Euler(0f, steerAngle, 0f);
        }
        RaycastHit tireRay;
        Vector3 steeringDir = tireTransform.right;
        if (Physics.Raycast(tireTransform.position, -tireTransform.up, out tireRay, suspensionRestDist, groundLayer))
        {
            //springDir = tireTransform.up;

            Vector3 tireWorldVel = carRigidbody.GetPointVelocity(tireTransform.position);

            float steeringVel = Vector3.Dot(steeringDir, tireWorldVel);

            float desiredVelChange = -steeringVel * tireGripFactor;

            float desiredAccel = desiredVelChange / Time.fixedDeltaTime;

            carRigidbody.AddForceAtPosition(steeringDir * tireMass * desiredAccel, tireTransform.position);
            Debug.DrawRay(tireTransform.position, steeringDir * desiredAccel * tireMass, Color.blue);
            return steeringDir * desiredAccel * tireMass;
        }
        return Vector3.zero;
    }
}
