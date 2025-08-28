using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int score, highScore, chrono, totalScore;
    public Text highScoreText;
    public Text scoreText;
    public float timer, speedTimer;
    public int scoreMultiplier = 1;
    public bool isPlaying;
    public Text crashScoreText;
    public GameObject crashText;
    int coinsTaker;
    public Transform player;
    public GameObject explosion;
    public bool explode = false;

    public Text finalScoreText, finalDestroyedCarsText, finalChronoText, totalScoreText;

    string chal1, chal2, chal3, chal4, chal5, chal6, chal7, chal8, chal9, chal10;

    void Start()
    {
        isPlaying = true;
        score = 0;
        scoreText.text = "" + score;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString();
    }

    public static Inventory instance;

    private void Awake()
    {
    	if(instance != null)
    	{
    		Debug.LogWarning("Il y a plus d'un inventaire");
    		return;
    	}
    	instance = this;
        coinsTaker = PlayerPrefs.GetInt("Coins", 0);
    }

    void Update()
    {

        chal1 = PlayerPrefs.GetString("Challenge1", "no");
        chal2 = PlayerPrefs.GetString("Challenge2", "no");
        chal3 = PlayerPrefs.GetString("Challenge3", "no");
        chal4 = PlayerPrefs.GetString("Challenge4", "no");
        chal5 = PlayerPrefs.GetString("Challenge5", "no");
        chal6 = PlayerPrefs.GetString("Challenge6", "no");
        chal7 = PlayerPrefs.GetString("Challenge7", "no");
        chal8 = PlayerPrefs.GetString("Challenge8", "no");
        chal9 = PlayerPrefs.GetString("Challenge9", "no");
        chal10 = PlayerPrefs.GetString("Challenge10", "no");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        if(isPlaying)
        {
            timer += Time.deltaTime;
            if(timer > 1)
            {
                score += 1 * scoreMultiplier;
                chrono += 1 * scoreMultiplier;
                scoreText.text = "" + score;
                timer = 0;
            }
            speedTimer+= Time.deltaTime;
            if(speedTimer>10 && 20>PlayerController.instance.speed)
            {
                PlayerController.instance.speed+=.5f;
                speedTimer=0;
            }
        }
        if(explode)
        {
            Instantiate(explosion, new Vector3(player.position.x, player.position.y, player.position.z), Quaternion.identity);
        } 

        if(score >= 150 && chal1 == "no")
        {
            PlayerPrefs.SetString("Challenge1", "done");
        }

        if(chrono >= 60 && chal3 == "no")
        {
            PlayerPrefs.SetString("Challenge3", "done");
        }

        if(score >= 30 && PlayerController.instance.life == 3 && chal4 == "no")
        {
            PlayerPrefs.SetString("Challenge4", "done");
        }
        if(chrono >= 15 && PlayerController.instance.life == 3 && chal5 == "no")
        {
            PlayerPrefs.SetString("Challenge5", "done");
        }
        if(score >= 450 && chal6 == "no")
        {
            PlayerPrefs.SetString("Challenge6", "done");
        }
        if(EnemySpawner.instance.destroyedCars >= 5 && PlayerController.instance.life == 3 && chal7 == "no")
        {
            PlayerPrefs.SetString("Challenge7", "done");
        }
        if(score >= 1000 && chal8 == "no")
        {
            PlayerPrefs.SetString("Challenge8", "done");
        }
        if(chal1 != "no" && chal2 != "no" && chal3 != "no" && chal4 != "no" && chal5 != "no" && chal6 != "no" && chal7 != "no" && chal8 != "no" && chal9 != "no")
        {
            PlayerPrefs.SetString("Challenge10", "done");
        }
        if(ShopManager.instance.chooseUpFlat == "yes" && ShopManager.instance.chooseBotfer == "yes" && ShopManager.instance.chooseHatch == "yes" && ShopManager.instance.chooseSedanMax == "yes" && ShopManager.instance.chooseGhost == "yes" && chal9 == "no")
        {
            PlayerPrefs.SetString("Challenge9", "done");
        }

        finalScoreText.text = score.ToString();
        finalDestroyedCarsText.text = EnemySpawner.instance.destroyedCars.ToString();
        finalChronoText.text = chrono.ToString();
        totalScore = score + EnemySpawner.instance.destroyedCars + chrono;
        totalScoreText.text = totalScore.ToString();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Coins", coinsTaker + totalScore);
        if(totalScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", totalScore);
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreText.text = highScore.ToString();
        }
    }
}
