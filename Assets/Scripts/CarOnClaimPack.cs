using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarOnClaimPack : MonoBehaviour
{
    public float speed;
    public float drag, angleSpeed, traction;
    public Vector3 moveForce;
    bool drift;
    public static CarOnClaimPack instance;
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
        
    }

    IEnumerator PlayAnim()
    {
        drift = true;
        yield return new WaitForSeconds(2.1f);
        drift = false;
    }

    public void Drift()
    {
        StartCoroutine(PlayAnim());
    }

    // Update is called once per frame
    void Update()
    {
        if (drift)
        {
            moveForce += transform.forward * speed * Time.deltaTime;
            transform.position += moveForce * Time.deltaTime;
            moveForce *= drag;
            moveForce = Vector3.ClampMagnitude(moveForce, speed / 3);
            moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, traction * Time.deltaTime) * moveForce.magnitude;

            transform.Rotate(-Vector3.up * moveForce.magnitude * angleSpeed * Time.deltaTime);
        }
    }
}
