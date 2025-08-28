using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesProviderScript : MonoBehaviour
{
    public GameObject minesPrefab;
    public ParticleSystem mineParticle;
    // Start is called before the first frame update
    void Start()
    {
        InventoryScript.instance.power[4] = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        /*ParticleSystem.Particle[] particles = new ParticleSystem.Particle[mineParticle.particleCount];
        int numParticlesAlive = mineParticle.GetParticles(particles);

        for (int i = 0; i < numParticlesAlive; i++)
        {
            Vector3 particlePosition = particles[i].position;
            Vector3 worldPosition = mineParticle.transform.TransformPoint(particles[i].position);

            Debug.LogWarning($"Particle {i} position: {worldPosition}");
        }*/
    }

    public void OnParticleCollision(GameObject other)
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[mineParticle.particleCount];

        // Number of particles alive after collision
        int numParticlesAlive = mineParticle.GetParticles(particles);

        for (int i = 0; i < numParticlesAlive; i++)
        {
            Vector3 particlePosition = particles[i].position;
            Vector3 worldPosition = mineParticle.transform.TransformPoint(particles[i].position);
            Debug.Log($"Particle {i} collided with: {other.name} at {worldPosition}");
            Instantiate(minesPrefab, worldPosition, Quaternion.identity);
            /*Vector3 pos = collisionEvent.intersection; // the point of intersection between the particle and the enemy
            Debug.Log(pos);
            Instantiate(minesPrefab, pos, Quaternion.identity);*/
            // GameObject vfx = Instantiate(enemyHitVFX, pos, Quaternion.identity); // creating the explosion effect.
            // vfx.transform.parent = parentGameobject.transform; // this makes the new gameobjects children to my “VFX Parent” gameObject in my Hierarchy, for organizarion purposes
        }
        //Destroy(gameObject);

    }

}
