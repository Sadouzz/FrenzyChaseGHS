using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class InventoryScript : MonoBehaviour
{
    public int score, usedPower;
    public int coins;
    public int starsPicked;
    public bool isPlaying;
    public float timer, speedTimer, totalSeconds = 1;
    public int scoreMultiplier = 1;
    public TextMeshProUGUI scoreText, timerText, destroyedCarsText, starText, powerUpdateText, lifeText;
    public TextMeshProUGUI finalScoreText, finalTimerText, finalDestroyedCarsText;
    public TextMeshProUGUI starsPolice, starsTime, starsScore, starsPickedText, starsPickedRightText, totalStarsText;
    public GameObject powerOn, psThermal, psSaw, psMines, minePrefab, canvasPower;
    public GameObject[] power;

    Transform player;
    //public RewardedAdsButton rab;


    public Image powerOnImage;
    public Sprite turrel, fireCircle, destabilizer, saws, mines, missionsSprite;

    public int totalStarsToAdd;

    public static InventoryScript instance;
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
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Time.timeScale = 1;
        score = 0;
        isPlaying = true;
        coins = PlayerPrefs.GetInt("stars", 0);
        //rab.LoadAd();

        psThermal = GameObject.FindGameObjectWithTag("ThermalCircleZone");
        power[1] = psThermal;
        psThermal.SetActive(false);

        //psSaw = GameObject.FindGameObjectWithTag("Saw");
        power[3] = psSaw;
        //psSaw.SetActive(false);

        canvasPower = GameObject.FindGameObjectWithTag("CanvasPower");
        canvasPower.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = PlayerMovement.instance.currentLife.ToString();
        if (isPlaying)
        {
            destroyedCarsText.text = PoliceSpawner.instance.destroyedCars.ToString();
            starText.text = starsPicked.ToString();
            
            totalSeconds += Time.deltaTime;
            TimeSpan ts = TimeSpan.FromSeconds(totalSeconds);
            timerText.text = ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds;
            if (ts.Hours == 0)
            {
                timerText.text = ts.Hours + "0:" + ts.Minutes + ":" + ts.Seconds;
                if (ts.Minutes < 10)
                {
                    timerText.text = "0" + ts.Hours + ":" + "0" + ts.Minutes + ":" + ts.Seconds;
                    if (ts.Seconds < 10)
                    {
                        timerText.text = "0" + ts.Hours + ":" + "0" + ts.Minutes + ":" + "0" + ts.Seconds;
                    }
                }
                else
                {
                    if (ts.Seconds < 10)
                    {
                        timerText.text = ts.Hours + "0:" + ts.Minutes + "0" + ts.Seconds;
                    }
                }
                
            }
            

            timer += Time.deltaTime;
            if (timer > .1f)
            {
                score += 1 * scoreMultiplier;
                scoreText.text = score.ToString();
                timer = 0;
            }
            speedTimer += Time.deltaTime;
            if (speedTimer > 5)
            {
                //PlayerMovement.instance.speed += .01f;
                if(PoliceSpawner.instance.policeSpeed < 13.5f)
                {
                    PoliceSpawner.instance.IncreasePoliceSpeed();
                }
                speedTimer = 0;
            }


            /*if(score >= 10 && !beach)
            {
                ChunkManager.instance.ChangeDecor("beach");
                beach = true;
            }

            if (score >= 500 && !city)
            {
                ChunkManagerBeach.instance.ChangeDecor("city");
                city = true;
            }*/
        }
    }

    public void PowerPicked(int _index)
    {
        powerOn = power[_index];
        canvasPower.SetActive(true);
        if (powerOn == power[0])
        {
            //Turret
            powerUpdateText.text = "TOURELLE";
            OpacityPowerOff(true);
            powerOnImage.sprite = turrel;
            StartCoroutine(UpdatePowerTextDisplay());
        }

        if (powerOn == power[1])
        {
            //ThermalCircleZone
            powerUpdateText.text = "CERCLE DE FEU";
            OpacityPowerOff(true);
            powerOnImage.sprite = fireCircle;
            StartCoroutine(UpdatePowerTextDisplay());
        }

        if (powerOn == power[2])
        {
            //Destabilizer
            powerUpdateText.text = "DESTABILISATEUR";
            OpacityPowerOff(true);
            powerOnImage.sprite = destabilizer;
            StartCoroutine(UpdatePowerTextDisplay());
        }

        if (_index == 3)
        {
            //Scie
            powerOn = psSaw;
            powerUpdateText.text = "SCIES";
            OpacityPowerOff(true);
            powerOnImage.sprite = saws;
            StartCoroutine(UpdatePowerTextDisplay());
        }

        if (_index == 4)
        {
            //Scie
            powerOn = GameObject.FindGameObjectWithTag("MinesProvider");
            powerUpdateText.text = "MINES";
            OpacityPowerOff(true);
            powerOnImage.sprite = mines;
            StartCoroutine(UpdatePowerTextDisplay());
        }
    }

    public void UsePower()
    {
        if (powerOn != null)
        {
            canvasPower.SetActive(false);
            if (powerOn == power[0])
            {
                //Turret
                Turret();
            }

            if (powerOn == power[1])
            {
                //ThermalCircleZone
                StartCoroutine(ThermalCircleZone(psThermal));
            }

            if (powerOn == power[2])
            {
                //Destabilizer
                Destabilizer();
            }

            if (powerOn == psSaw)
            {
                //ThermalCircleZone
                SawIE();
            }
            if (powerOn == power[4])
            {
                //Mines
                Mines();
            }
            usedPower++;
            OpacityPowerOff(false);
        }
    }

    void OpacityPowerOff(bool _bool)
    {
        if(!_bool)
        {
            powerOnImage.enabled = false;
            powerOn = null;
            powerOnImage.sprite = null;
        }
        else
        {
            powerOnImage.enabled = true;
        }
    }

    public void Turret()
    {
        GameObject turret = GameObject.FindGameObjectWithTag("Turret");
        turret.GetComponent<TurretScript>().Shoot();
    }

    public void Fire()
    {
        StartCoroutine(ThermalCircleZone(psThermal));
    }

    IEnumerator ThermalCircleZone(GameObject _ps)
    {
        //var shape = particleSystem.shape;
        _ps.SetActive(true);
        var shape = _ps.GetComponent<ParticleSystem>().shape;
        shape.radius = 4.5f + (0.5f * PlayerPrefs.GetInt("Cercle de feuLevel", 1));
        _ps.GetComponent<CapsuleCollider>().radius = shape.radius * 2;
        _ps.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(5);
        _ps.GetComponent<ParticleSystem>().Stop();
        _ps.SetActive(false);
    }

    public void Destabilizer()
    {
        GameObject destabilizer = GameObject.FindGameObjectWithTag("Destabilizer");
        destabilizer.GetComponent<DestabilizerScript>().Shoot();
    }

    public void Saw()
    {
        SawIE();
    }

    void SawIE()
    {
        /*_ps.SetActive(true);
        _ps.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(3);
        _ps.GetComponent<ParticleSystem>().Stop();
        _ps.SetActive(false);*/

        var saw = Instantiate(psSaw, new Vector3(player.position.x, .5f, player.position.z), Quaternion.Euler(-90, player.eulerAngles.y, 0));
        var ps = saw.GetComponent<ParticleSystem>();
        var mainPS = ps.main;
        mainPS.maxParticles = 2 + PlayerPrefs.GetInt("SciesLevel", 1);
        mainPS.startLifetime = mainPS.maxParticles;
        ps.Play();
        /*yield return new WaitForSeconds(3);
        Destroy( saw );*/
        Debug.Log("Saw");
    }

    public void Mines()
    {
        StartCoroutine(MinesIE());
    }

    IEnumerator MinesIE()
    {
        var mines = Instantiate(psMines, new Vector3(player.position.x, player.position.y + 2.5f, player.position.z), Quaternion.Euler(-90, player.eulerAngles.y, 0));
        var ps = mines.GetComponent<ParticleSystem>();
        var mainPS = ps.main;
        mainPS.maxParticles = 2 + PlayerPrefs.GetInt("MinesLevel", 1);
        mainPS.startLifetime = mainPS.maxParticles;
        ps.Play();
        yield return new WaitForSeconds(3);
        Destroy(mines);
        Debug.Log("Mines");
    }

    IEnumerator UpdatePowerTextDisplay()
    {
        powerUpdateText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        powerUpdateText.gameObject.SetActive(false);
    }

    public void SaveData()
    {
        isPlaying = false;
        finalDestroyedCarsText.text = destroyedCarsText.text;
        finalScoreText.text = scoreText.text;
        finalTimerText.text = timerText.text;
        starsPolice.text = finalDestroyedCarsText.text;
        starsTime.text = "0";
        starsScore.text = Mathf.RoundToInt(score / 10).ToString();
        int starsForScore, starsForTime, starsForPolice, totalStars;
        int.TryParse(starsScore.text, out starsForScore);
        int.TryParse(starsPolice.text, out starsForPolice);
        int.TryParse(starsTime.text, out starsForTime);
        starsPickedText.text = starsPicked.ToString();
        starsPickedRightText.text = starsPicked.ToString();
        totalStars = starsForPolice + starsForTime + starsForScore + starsPicked;
        totalStarsText.text = totalStars.ToString();
        totalStarsToAdd = totalStars;
        PlayerPrefs.SetInt("stars", coins + totalStars);
        PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore", 0) + score);
        PlayerPrefs.SetInt("totalDestroyedCars", PlayerPrefs.GetInt("totalDestroyedCars", 0) + PoliceSpawner.instance.destroyedCars);
        PlayerPrefs.SetInt("totalSecondsPlayed", PlayerPrefs.GetInt("totalSecondsPlayed", 0) + Mathf.FloorToInt(totalSeconds));  
        TimeSpan totalSecondsToOutput = TimeSpan.FromSeconds(PlayerPrefs.GetInt("totalSecondsPlayed", 0));
        PlayerPrefs.SetString("totalSecondsPlayedOutput", totalSecondsToOutput.Hours + "h" + totalSecondsToOutput.Minutes + "min" + totalSecondsToOutput.Seconds + "s");


        if (score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", score);
        }

        if(PoliceSpawner.instance.destroyedCars > PlayerPrefs.GetInt("highDestroyedCars", 0))
        {
            PlayerPrefs.SetInt("highDestroyedCars", PoliceSpawner.instance.destroyedCars);
        }
        if(totalSeconds > PlayerPrefs.GetInt("highTotalSeconds", 0))
        {
            TimeSpan ts = TimeSpan.FromSeconds(totalSeconds);
            PlayerPrefs.SetString("highTotalSecondsOutput", ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds);
            PlayerPrefs.SetInt("highTotalSeconds", Mathf.FloorToInt(totalSeconds));
        }
        
    }

    public void Retrying()
    {
        score = 0;
        isPlaying = true;
        Time.timeScale = 1;
    }
}
