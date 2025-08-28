using UnityEngine;

public class ShowDistanceToPlayer : MonoBehaviour
{
    public Transform player;
    public bool showInConsole = true;
    public float distance;

    void Start()
    {
        if (player == null)
        {
            GameObject found = GameObject.FindGameObjectWithTag("Player");
            if (found != null) player = found.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        distance = Vector3.Distance(transform.position, player.position);

        if (showInConsole)
        {
            Debug.Log($"Distance entre {gameObject.name} et le joueur : {distance:F2} unités");
        }
    }
}