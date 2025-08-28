using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TrailerCamActivatorScript : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public GameObject cam, follow;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.42f);
        AssignTarget();
    }

    void AssignTarget()
    {
        virtualCamera.Priority = 11;
        virtualCamera.LookAt = GameObject.FindGameObjectWithTag("Player").transform;
        virtualCamera.Follow = follow.transform;
        cam.AddComponent<CinemachineBrain>();
    }
    /*private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            virtualCamera.Priority = 11;
            virtualCamera.LookAt = GameObject.FindGameObjectWithTag("Player").transform;
            virtualCamera.Follow = transform;
            cam.AddComponent<CinemachineBrain>();
            //virtualCamera.LookAt = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }*/
}
