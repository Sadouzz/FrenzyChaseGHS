using Michsky.UI.ModernUIPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(3);
        Destroy(gameObject);
    }
    public void OnParticleCollision(GameObject touched)
    {
        if (touched.tag == "Police")
        {
            touched.GetComponent<DamagePoliceCar>().Die();
        }
        if (touched.tag == "VanPolice")
        {
            touched.GetComponent<DamageFourgon>().Die();
        }
        if (touched.tag == "Obstacle")
        {
            ChunkManager.instance.DisableObstacle(touched);
        }
    }
}
