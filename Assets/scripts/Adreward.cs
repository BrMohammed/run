using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
using System.Collections;


public class Adreward : MonoBehaviour
{
    private RewardBasedVideoAd adReward;
	GameplayController G;
    private string  idReward;

  //  private GameConterolerFromMenu GC;

    [SerializeField] public Button BtnReward;

    static int loadCount = 1;



    // Start is called before the first frame update
    void OnEnable()
    {
		BtnReward.interactable = false;
		idReward = "ca-app-pub-3940256099942544/5224354917";

		adReward = RewardBasedVideoAd.Instance;

        MobileAds.Initialize(initStatus => { });

        if (loadCount == 2)  // only show ad every third time
        {
            loadCount = 1;
            BtnReward.interactable = true;

        }
        else loadCount++;

    }
   
    #region Reward video methods ---------------------------------------------

    public void RequestRewardAd()
	{
		AdRequest request = AdRequestBuild();
		adReward.LoadAd(request, idReward);

		adReward.OnAdLoaded += this.HandleOnRewardedAdLoaded;
		adReward.OnAdRewarded += this.HandleOnAdRewarded;
		adReward.OnAdClosed += this.HandleOnRewardedAdClosed;
	}

	public void ShowRewardAd()
	{
		if (adReward.IsLoaded())
			adReward.Show();
	}
	//events
	public void HandleOnRewardedAdLoaded(object sender, EventArgs args)
	{
		//ad loaded
		ShowRewardAd();
	}

	public void HandleOnAdRewarded(object sender, EventArgs args)
	{
		//user finished watching ad
        G = GameObject.Find("Gameplay Controller").GetComponent<GameplayController>();
      //  G.contenuettime();
        
       // GC = GameObject.FindObjectOfType(typeof(GameConterolerFromMenu)) as GameConterolerFromMenu;
       // GC.continuethegame();
    }

	public void HandleOnRewardedAdClosed(object sender, EventArgs args)
	{//ad closed (even if not finished watching)
		BtnReward.interactable = true;

		adReward.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
		adReward.OnAdRewarded -= this.HandleOnAdRewarded;
		adReward.OnAdClosed -= this.HandleOnRewardedAdClosed;
	}

	#endregion


	//other functions
	//btn (more points) clicked
	public void OnGetMoretimeClicked()
	{
        BtnReward.interactable = false;
        RequestRewardAd();
    }
	//------------------------------------------------------------------------
	AdRequest AdRequestBuild()
	{
		return new AdRequest.Builder().Build();
	}

	void OnDestroy()
	{
	

	

		adReward.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
		adReward.OnAdRewarded -= this.HandleOnAdRewarded;
		adReward.OnAdClosed -= this.HandleOnRewardedAdClosed;

	}
}
