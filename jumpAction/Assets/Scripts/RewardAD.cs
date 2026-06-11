using GoogleMobileAds.Api;
using UnityEngine;
public class RewardAD : MonoBehaviour

{
    public static RewardAD instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
        });
    }
    private void Start()
    {
        LoadRewardedAd();
    }
#if UNITY_ANDROID
  private string _adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
    private string _adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
  private string _adUnitId = "unused";
#endif

    private RewardedAd rewardedAd;
    
    /// <summary>
    /// Loads the rewarded ad.
    /// </summary>
    public void LoadRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest.Builder().Build();

        // send the request to load the ad.
        RewardedAd.Load(_adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                rewardedAd = ad;
            });

    }
    public void ShowRewardedAd()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            RegisterReloadHandler(rewardedAd);

            rewardedAd.Show((Reward reward) =>
            {
                Director.instance.SetSpawnPoint();
               
            });
        }
        else
        {
            Director.instance.BackToGame();
        }
    }
    private void RegisterReloadHandler(RewardedAd ad)
    {
        ad.OnAdFullScreenContentOpened += () =>
        {
            AudioBGM.instance.MuteBGM();
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
            Director.instance.BackToGame();
            AudioBGM.instance.NotMuteBGM();
            LoadRewardedAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
            Director.instance.BackToGame();
            AudioBGM.instance.NotMuteBGM();

            LoadRewardedAd();
        };
    }
}