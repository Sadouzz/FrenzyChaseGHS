using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    float time;
    public Light light;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 0.5f)
        {
            time = 0;
            if(light.enabled)
            {
                light.enabled = false;
            }
            else
            {
                light.enabled = true;
            }            
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Police"))
        {
            collision.gameObject.GetComponent<DamagePoliceCar>().Die();
            Destroy(gameObject);
        }
        if (collision.CompareTag("VanPolice"))
        {
            collision.gameObject.GetComponent<DamageFourgon>().Die();
            Destroy(gameObject);
        }
        
    }
}
