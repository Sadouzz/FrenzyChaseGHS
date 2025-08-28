using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float angleSpeed;
	Rigidbody rb;
	public int life = 3;
	private int currentAngle;

	public bool invincible = false, turbo;
	public GameObject inGamePanel, intruc, turboFx, fxParent;

	public Light flash;
    public GameObject playCam;
    public GameObject lifeHeart0, lifeHeart1, lifeHeart2;

    public static PlayerController instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'un inventaire");
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    	StartCoroutine(HideInstructions());
    	intruc = GameObject.FindGameObjectWithTag("Instructions");
        rb =  GetComponent<Rigidbody>();
        inGamePanel = GameObject.FindGameObjectWithTag("InGamePanel");
        flash = GameObject.FindGameObjectWithTag("Flash").GetComponent<Light>();
    }

    void Update()
    {
        playCam = GameObject.FindGameObjectWithTag("PlayCam");
        if(turbo)
        {
            speed = 25;
            StartCoroutine(DisTurbo());
        }
        
    	if(Input.GetMouseButton(0))
    	{
    		
    		float x = Input.mousePosition.x;
    		if(x < Screen.width / 2 && x > 0)
    		{
    			MoveLeft();
    		}

    		if(x > Screen.width / 2 && x < Screen.width)
    		{
    			MoveRight();
    		}
    	}
        ActualizeLife();
        playCam.transform.SetParent(this.transform);
    }

    void ActualizeLife()
    {
        lifeHeart0 = GameObject.FindGameObjectWithTag("life0");
        lifeHeart1 = GameObject.FindGameObjectWithTag("life1");
        lifeHeart2 = GameObject.FindGameObjectWithTag("life2");
        if(life == 2)
        {
            lifeHeart2.SetActive(false);
            lifeHeart1.SetActive(true);
            lifeHeart0.SetActive(true);
        }
        if(life == 1)
        {
            lifeHeart1.SetActive(false);
            lifeHeart2.SetActive(false);
            lifeHeart0.SetActive(true);
        }
        if(life == 0)
        {
            
        }
        if(life == 3)
        {
            lifeHeart0.SetActive(true);
            lifeHeart1.SetActive(true);
            lifeHeart2.SetActive(true);
        }
        
    }

    IEnumerator HideInstructions()
    {
    	yield return new WaitForSeconds(.5f);
    	intruc.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(life == 0)
        {
            playCam.transform.SetParent(null);
        	gameObject.SetActive(false);
        	Manager.instance.crashPanel.SetActive(true);
        	Inventory.instance.isPlaying = false;
            Inventory.instance.explode = true;
        	inGamePanel.SetActive(false);
        	Inventory.instance.SaveData();
        }
    }

    public void MoveLeft()
    {
    	transform.Rotate(-Vector3.up * angleSpeed * Time.deltaTime);
    }

    public void MoveRight()
    {
    	transform.Rotate(Vector3.up * angleSpeed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision coll)
    {
    	if(coll.collider.CompareTag("Police"))
    	{
    		if(!invincible)
    		{
    			life--;
    			StartCoroutine(Flash());
    		}
    	}
        if(coll.collider.CompareTag("Vide"))
        {
            life = 0;
        }
    }


    IEnumerator Flash()
    {
    	invincible = true;
    	flash.enabled = true;
    	yield return new WaitForSeconds(.4f);
    	flash.enabled = false;
    	yield return new WaitForSeconds(.4f);
    	flash.enabled = true;
    	yield return new WaitForSeconds(.4f);
    	flash.enabled = false;
    	yield return new WaitForSeconds(.4f);
        flash.enabled = true;
        yield return new WaitForSeconds(.4f);
        flash.enabled = false;
    	invincible = false;
    }

    IEnumerator DisTurbo()
    {
        fxParent.SetActive(true);
        turboFx.SetActive(true);
        yield return new WaitForSeconds(8);
        speed = 17;
        turboFx.SetActive(false);
        fxParent.SetActive(false);
    }
}