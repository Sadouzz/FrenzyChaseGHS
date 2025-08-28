using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float sliderTimer;
    public float speed, tempSpeed;
    public float drag, angleSpeed, traction, steerInput;
    public int currentLife;
    public bool isColliding, isInvincible, stopAll, leftSmokeBool, rightSmokeBool;
    public AudioSource turn;
    public GameObject car, fireEffect, explosionEffect, diePanel;
    public ParticleSystem leftSteerSmoke, rightSteerSmoke;
    //public AdsInitializer adsInitializer;
    public Vector3 moveForce;
    public AudioListener audioListener;

    public Rigidbody rb;
    public static PlayerMovement instance;
    bool calledDie;
    public GameObject invincibleImage;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'un inventaire");
            return;
        }
        instance = this;
        diePanel = GameObject.FindGameObjectWithTag("DiePanel");
        audioListener = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();
    }

    // Start is called before the first frame update
    void Start()
    {
        tempSpeed = speed;
        stopAll = false;
        leftSmokeBool = false;
        rightSmokeBool = false;
        Debug.Log(PlayerPrefs.GetString("ChosenCar"));
        Debug.Log("Level" + PlayerPrefs.GetInt(PlayerPrefs.GetString("ChosenCar") + "Level", 1));
        StartCoroutine(InvincibleTiming());


        //traction -= PlayerPrefs.GetInt(PlayerPrefs.GetString("ChosenCar") + "Level", 1) * 0.5f;
        Debug.Log(traction);

        /*sedanLevel.text = PlayerPrefs.GetInt("sedanLevel", 1).ToString();
        hatroLevel.text = PlayerPrefs.GetInt("hatroLevel", 1).ToString();
        taxiLevel.text = PlayerPrefs.GetInt("taxiLevel", 1).ToString();
        terzaLevel.text = PlayerPrefs.GetInt("terzaLevel", 1).ToString();
        macTLevel.text = PlayerPrefs.GetInt("mac-TLevel", 1).ToString();
        tRashLevel.text = PlayerPrefs.GetInt("t-RashLevel", 1).ToString();
        flatoLevel.text = PlayerPrefs.GetInt("flatoLevel", 1).ToString();
        sPeraLevel.text = PlayerPrefs.GetInt("s-PeraLevel", 1).ToString();
        ghostLevel.text = PlayerPrefs.GetInt("ghostLevel", 1).ToString();*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerPrefs.GetString("tutorial", "no") == "first")
        {
            PlayerPrefs.SetString("tutorial", "third");
        }
        steerInput = GetSteerInput();
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        moveForce += transform.forward * speed * Time.deltaTime;
        transform.position += moveForce * Time.deltaTime;
        moveForce *= drag;
        moveForce = Vector3.ClampMagnitude(moveForce, speed / 3);

        moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, traction * Time.deltaTime) * moveForce.magnitude;
        //MoveRight();
        if (InventoryScript.instance.isPlaying)
        {
            /*if (Input.GetMouseButton(0))
            {
                float x = Input.mousePosition.x;
                if (x < Screen.width / 2 && x > 0)
                {
                    MoveLeft();
                    sliderTimer += 1 * Time.deltaTime;
                }

                if (x > Screen.width / 2 && x < Screen.width)
                {
                    MoveRight();
                    sliderTimer += 1 * Time.deltaTime;
                }
            }*/
            if (steerInput != 0)
            {
                if (steerInput < 0)
                {
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }
            else
            {
                leftSteerSmoke.Stop();
                rightSteerSmoke.Stop();
                rightSmokeBool = false;
                leftSmokeBool = false;
                sliderTimer = 0;
            }

            if (isColliding)
            {
                isColliding = false;
                if (!isInvincible)
                {
                    isInvincible = true;
                    ReduceLife();
                }
                else
                {
                    return;
                }
            }
        }

        

        if (currentLife <= 0 && !calledDie)
        {
            calledDie = true;
            DieProcess();
        }
    }

    private float GetSteerInput()
    {
        float steer = Input.GetAxis("Horizontal"); // Clavier / manette / gyroscope

        if (Input.GetMouseButton(0))
        {
            float x = Input.mousePosition.x;

            if (x < Screen.width / 2f)
                steer = -1f;
            else if (x > Screen.width / 2f)
                steer = 1f;
        }

        return steer;
    }

    public void MoveLeft()
    {
        transform.Rotate(-Vector3.up * moveForce.magnitude * angleSpeed * Time.deltaTime);
        
        rightSmokeBool = false;
        if (!leftSmokeBool)
        {
            leftSmokeBool = true;

            leftSteerSmoke.Play();
            rightSteerSmoke.Stop();
        }
        if(sliderTimer >= .55f)
        {
            SliderOnScreenScript.instance.AddValue();
        }
        //leftSteerSmoke.Play(true);
        //rightSteerSmoke.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    public void MoveRight()
    {
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, turnInput * turnStrength * Time.deltaTime, 0));
        //transform.Rotate(Vector3.up * angleSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up * moveForce.magnitude * angleSpeed * Time.deltaTime);
        leftSmokeBool = false;
        if (sliderTimer >= .55f)
        {
            SliderOnScreenScript.instance.AddValue();
        }
        if (!rightSmokeBool)
        {
            rightSmokeBool = true;

            leftSteerSmoke.Stop();
            rightSteerSmoke.Play();
        }
        //rightSteerSmoke.Play(true);
        //leftSteerSmoke.Stop(true, ParticleSystemStopBehavior.StopEmitting);

    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Police") || coll.collider.CompareTag("VanPolice"))
        {
            isColliding = true;
        }

        if (coll.collider.CompareTag("Obstacle"))
        {
            Destroy(coll.gameObject);
            currentLife = 0;
        }
    }


    public void ReduceLife()
    {
        currentLife -= 1;
        if(currentLife > 0)
        {
            StartCoroutine(InvincibleTiming());
        }
        if (CarSpawnOnGame.instance.isPoidsLourd && currentLife == 1)
        {
            fireEffect.SetActive(true);
        }
    }

    IEnumerator InvincibleTiming()
    {
        isInvincible = true;
        invincibleImage.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        isInvincible = false;
        invincibleImage.SetActive(false);
    }

    public void RetryingProcess()
    {
        car.SetActive(true);
        currentLife = 1;
        diePanel.SetActive(false);
        Time.timeScale = 1;
        InventoryScript.instance.Retrying();
        isInvincible = false;
        stopAll = false;
        StartCoroutine(InvincibleTiming());
    }

    Coroutine dieCoroutine;

    public void AdsReward()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars", 0) - InventoryScript.instance.totalStarsToAdd);
        diePanel.GetComponent<Animator>().SetBool("out", false);
        StopCoroutine(dieCoroutine);
        stopAll = false ;
        isInvincible = true;
        InventoryScript.instance.isPlaying = true;
        StartCoroutine(InvincibleTiming());
        currentLife = 1;
        diePanel.SetActive(false);
        car.SetActive(true);
        speed = tempSpeed;
        calledDie = false;
        GameObject[] police = GameObject.FindGameObjectsWithTag("Police");
        GameObject[] vanPolice = GameObject.FindGameObjectsWithTag("VanPolice");
        foreach(GameObject p in police)
        {
            p.GetComponent<DamagePoliceCar>().Die();
        }
        foreach (GameObject p in vanPolice)
        {
            p.GetComponent<DamageFourgon>().Die();
        }
        //StabilizeRigidbody(rb);
    }

    void StabilizeRigidbody(Rigidbody rb)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void DieProcess()
    {
        Debug.Log("DieProcess Called");
        if(!stopAll)
        {
            InventoryScript.instance.SaveData();
            speed = 0;
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            dieCoroutine = StartCoroutine(ExplosionAnimation());
            stopAll = true;
        }
    }

    IEnumerator ExplosionAnimation()
    {
        car.SetActive(false);
        yield return new WaitForSecondsRealtime(.5f);
        diePanel.SetActive(true);
        diePanel.GetComponent<Animator>().SetBool("out", true);
        GameObject[] police = GameObject.FindGameObjectsWithTag("Enemy");
        //GameObject[] vanPolice = GameObject.FindGameObjectsWithTag("VanPolice");
        foreach (GameObject p in police)
        {
            p.GetComponent<PoliceScript>().MuteVolume();
        }
        /*foreach (GameObject p in vanPolice)
        {
            p.GetComponent<PoliceScript>().MuteVolume();
        }*/
        //audioListener.enabled = false;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
    }

    public void SpeedOnChangeDecor()
    {
        StartCoroutine(TimeSpeed());
    }

    IEnumerator TimeSpeed()
    {
        Time.timeScale = 0.6f;
        yield return new WaitForSecondsRealtime(2);
        speed = tempSpeed;
        Time.timeScale = 1;
    }
}

