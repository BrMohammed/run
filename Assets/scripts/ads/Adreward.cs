using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
using System.Collections;


public class Adreward : MonoBehaviour
{
    private RewardBasedVideoAd adReward;
    private string  idReward;
	private bool RewardLoaded = false;

	[SerializeField]   private GameplayController GC;

	[SerializeField] public Button BtnReward;

    static int loadCount = 1;

    // Start is called before the first frame update
    void OnEnable()
    {
		BtnReward.interactable = true;
		BtnReward.gameObject.SetActive(false);
		idReward = "ca-app-pub-3940256099942544/5224354917";

		adReward = RewardBasedVideoAd.Instance;

        MobileAds.Initialize(initStatus => { });

        //if (loadCount == 2)  // only show ad every third time
        //{
        //    loadCount = 1;
        //    BtnReward.interactable = true;

        //}
        //else loadCount++;

    }


	void Update()
	{
		if (RewardLoaded)
		{
			RewardLoaded = false;
			BtnReward.gameObject.SetActive(true);
		}
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
		RewardLoaded = true;

	}

	public void HandleOnAdRewarded(object sender, EventArgs args) // end video
	{
		GC.GameOver_Adwatch();
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
