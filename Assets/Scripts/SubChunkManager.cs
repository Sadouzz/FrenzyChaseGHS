using UnityEngine;

public class SubChunkManager : MonoBehaviour
{
    public Transform player;
    public float activationDistance = 60f;
    public float deactivationDistance = 75f;

    public Transform[] subChunks;

    public static SubChunkManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

    }

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        /*// Stocke tous les enfants comme sub-chunks
        int count = transform.childCount;
        subChunks = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            subChunks[i] = transform.GetChild(i);
        }*/
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            foreach (Transform subChunk in subChunks)
            {
                float dist = Vector3.Distance(player.position, subChunk.position);

                // Active ou désactive selon la distance
                if (dist <= activationDistance && !subChunk.gameObject.activeSelf)
                {
                    subChunk.gameObject.SetActive(true);
                }
                else if (dist > deactivationDistance && subChunk.gameObject.activeSelf)
                {
                    subChunk.gameObject.SetActive(false);
                }
            }
        }
    }
}
