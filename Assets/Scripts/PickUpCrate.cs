using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCrate : MonoBehaviour
{
    public int powerNum;
    public GameObject ps;
    public AudioSource picked;
    string[] powers;
    void Start()
    {
        picked = GameObject.FindGameObjectWithTag("EventSystemCrate").GetComponent<AudioSource>();
        powers = new string[] { "Tourelle", "Cercle de feu", "Déstabilisateur", "Scies", "Mines" };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            CrateCracked();
        }
    }

    void CrateCracked()
    {
        Instantiate(ps, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        int r = Random.Range(0, powerNum);
        InventoryScript.instance.PowerPicked(r);
        CardsManager.instance.AddCards(1, powers[r]);
        picked.Play();
        Destroy(gameObject);
    }
}
