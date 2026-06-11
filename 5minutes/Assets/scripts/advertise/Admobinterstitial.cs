using GoogleMobileAds.Api;
using System;
using UnityEngine;
public class Admobinterstitial : MonoBehaviour
{
    private InterstitialAd interstitial;
    int num;
    public void Start()
    {
        this.RequestInterstitial();
    }
    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-6938175141790143/3392561548";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpening;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
        
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
        //                    + args.Message);
    }

    public void HandleOnAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpening event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        switch (num){
            case 1:
                fadeinout.fadeinoutinstance.Resetgame("PlayScene");
                break;
            case 2:
                Datasave.Instance.Initialization();
                Datasave.Instance.savedata.dataexist = true;
                fadeinout.fadeinoutinstance.Resetgame("PlayScene");
                break;
            case 3:
                fadeinout.fadeinoutinstance.Resetgame("Titlescene");
                break;
        }
    }
    public void ShowAdandToplayscene()
    {
        if (this.interstitial.IsLoaded())
        {
            Debug.Log("show interstitial");
            this.interstitial.Show();
            num = 1;
        }
        else
        {
            Debug.Log("failed to load interstitial");
            fadeinout.fadeinoutinstance.Resetgame("PlayScene");
        }
       
    }
    public void ShowAdandToNEWplayscene()
    {
        if (this.interstitial.IsLoaded())
        {
            Debug.Log("show interstitial");
            this.interstitial.Show();
            num = 2;
        }
        else
        {
            Debug.Log("failed to load interstitial");
            Datasave.Instance.Initialization();
            fadeinout.fadeinoutinstance.Resetgame("PlayScene");
        }

    }
   
    public void ShowAdandTotitleScene()
    {
        if (this.interstitial.IsLoaded())
        {
            Debug.Log("show interstitial");
            this.interstitial.Show();
            num = 3;
        }
        else
        {
            Debug.Log("failed to load interstitial");
            fadeinout.fadeinoutinstance.Resetgame("Titlescene");
        }

    }
    public void ShowAd()
    {
        if (this.interstitial.IsLoaded())
        {

            Debug.Log("show interstitial");
            this.interstitial.Show();
        }
        else
        {
            Debug.Log("failed to load interstitial");
        }

    }
}