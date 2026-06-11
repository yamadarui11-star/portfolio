using GoogleMobileAds.Api;
using UnityEngine;

public class InterstitialAD : MonoBehaviour
{
    public static InterstitialAD instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

    }
    private void Start()
    {
        LoadInterstitialAd();
    }
    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
  private string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
    private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
  private string _adUnitId = "unused";
#endif

    private InterstitialAd interstitialAd;

    /// <summary>
    /// Loads the interstitial ad.
    /// </summary>
    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest.Builder()
                .AddKeyword("unity-admob-sample")
                .Build();

        // send the request to load the ad.
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;
            });
    }
    public void ShowAdandStartGame()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            ResisterStartGameAfterWatchInterstitial();
            interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
            Director.instance.StartGame();
        }
    }

    public void ShowAdandRestartGame()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            ResisterRestartGameAfterWatchInterstitial();
            interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
            Director.instance.RestartGame();
        }
    }

    private void ResisterRestartGameAfterWatchInterstitial()
    {
        interstitialAd.OnAdFullScreenContentOpened += () =>
        {
            AudioBGM.instance.MuteBGM();
        };
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            SavedateInstance.instance.savedate.interstitialGauge = 0;

            AudioBGM.instance.NotMuteBGM();
            Director.instance.RestartGame();
            LoadInterstitialAd();

        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            AudioBGM.instance.NotMuteBGM();
            Director.instance.RestartGame();

            LoadInterstitialAd();
        };
    }
    private void ResisterStartGameAfterWatchInterstitial()
    {
        interstitialAd.OnAdFullScreenContentOpened += () =>
        {
            AudioBGM.instance.MuteBGM();
        };
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            SavedateInstance.instance.savedate.interstitialGauge = 0;

            AudioBGM.instance.NotMuteBGM();
            Director.instance.StartGame();
            LoadInterstitialAd();

        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            AudioBGM.instance.NotMuteBGM();
            Director.instance.StartGame();

            LoadInterstitialAd();
        };
    }
}
