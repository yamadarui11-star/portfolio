using GoogleMobileAds.Api;
using UnityEngine;
using System;

public class RewardAd : MonoBehaviour
{
    public static RewardAd instance;
    private RewardedAd rewardedAd;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            InitSDK();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        RequestAd();
    }

    private void InitSDK()
    {
        MobileAds.Initialize(initStatus => { });
    }

    
    private void RequestAd()
    {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-6938175141790143/4426114958";
#else
            string adUnitId = "unexpected_platform";
#endif
        this.rewardedAd = new RewardedAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);

        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
    }
    public void CreateAndLoadRewardedAd()
    {
        RequestAd();
    }
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        SavedataInstance.instance.savedata.boostTime += 3;
        SavedataInstance.instance.Save();
        TitleDirector.instance.Invoke_UpdateUI();
    }
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        CreateAndLoadRewardedAd();
    }
    public void ShowRewardAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
    private void Update()
    {
        if (rewardedAd.IsLoaded())
        {
            TitleDirector.instance.canShowLevelBoostAd = true;
        }
        else
        {
            TitleDirector.instance.canShowLevelBoostAd = false;
        }
    }

}