﻿using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
using System.Collections;

public class inter : MonoBehaviour
{
	private InterstitialAd adInterstitial;
	private string idInterstitial;

	static int loadCount = 1;
	Coroutine pendingAd;
	void Start()
	{
		idInterstitial = "ca-app-pub-3940256099942544/1033173712";

		MobileAds.Initialize(initStatus => { });

		RequestInterstitialAd();
		if (loadCount == 3)  // only show ad every third time
		{
			loadCount = 1;
			ShowInterstitialAd();
		}
		else
			loadCount++;
	}

	#region Interstitial methods ---------------------------------------------

	public void RequestInterstitialAd()
	{
		adInterstitial = new InterstitialAd(idInterstitial);
		AdRequest request = AdRequestBuild();
		adInterstitial.LoadAd(request);

		//attach events
		adInterstitial.OnAdLoaded += this.HandleOnAdLoaded;
		adInterstitial.OnAdOpening += this.HandleOnAdOpening;
		adInterstitial.OnAdClosed += this.HandleOnAdClosed;
	}

	public void ShowInterstitialAd()
	{

		if (pendingAd == null)
			pendingAd = StartCoroutine(ShowIntersitialAdWhenReady());

	}
	IEnumerator ShowIntersitialAdWhenReady()
	{
		// As long as the ad hasn't leaded, let the game keep running.
		while (adInterstitial.IsLoaded() == false)
			yield return null;

		// Now the ad has loaded - show it.
		adInterstitial.Show();

		// Clear out our "pending" state.
		pendingAd = null;
	}

	public void DestroyInterstitialAd()
	{
		adInterstitial.Destroy();
	}

	//interstitial ad events
	public void HandleOnAdLoaded(object sender, EventArgs args)
	{
		//this method executes when interstitial ad is Loaded and ready to show

	}

	public void HandleOnAdOpening(object sender, EventArgs args)
	{
		//this method executes when interstitial ad is shown
		//BtnInterstitial.interactable = false; //disable the button
	}

	public void HandleOnAdClosed(object sender, EventArgs args)
	{
		//this method executes when interstitial ad is closed
		adInterstitial.OnAdLoaded -= this.HandleOnAdLoaded;
		adInterstitial.OnAdOpening -= this.HandleOnAdOpening;
		adInterstitial.OnAdClosed -= this.HandleOnAdClosed;
		RequestInterstitialAd(); //request new interstitial ad after close
	}

	#endregion


	//------------------------------------------------------------------------
	AdRequest AdRequestBuild()
	{
		return new AdRequest.Builder().Build();
	}

	void OnDestroy()
	{
		
		DestroyInterstitialAd();

		//dettach events
		adInterstitial.OnAdLoaded -= this.HandleOnAdLoaded;
		adInterstitial.OnAdOpening -= this.HandleOnAdOpening;
		adInterstitial.OnAdClosed -= this.HandleOnAdClosed;	

	}

}
