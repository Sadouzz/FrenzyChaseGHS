using UnityEngine.Advertisements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    public static AdsInitializer instance; // Singleton

    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    [SerializeField] RewardedAdsButton adsButton;
    [SerializeField] BannerAds banner;

    void Awake()
    {
        // Singleton pattern pour garder l'instance
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeAds();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Cherche automatiquement le RewardedAdsButton dans la scène
        RewardedAdsButton button = FindObjectOfType<RewardedAdsButton>();
        if (button != null)
        {
            button.LoadAd(); // recharge la pub
            Debug.Log("RewardedAdsButton détecté et LoadAd appelé automatiquement !");
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void InitializeAds()
    {
#if UNITY_IOS
        _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
        _gameId = _androidGameId; // Pour tester dans l'éditeur
#endif

        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);

            MetaData childDirected = new MetaData("gdpr");
            childDirected.Set("gdpr", "child");
            Advertisement.SetMetaData(childDirected);
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        if (adsButton != null)
            adsButton.LoadAd();
        // if (banner != null) banner.LoadBanner();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
