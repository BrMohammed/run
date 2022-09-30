﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using ShopSystem;

public class Loading : MonoBehaviour
{
	[SerializeField] [Range(2f,8f)] float loadingDelay = 2f;
	[SerializeField]  GameObject GDPR_Popup;
	void OnEnable()
	{
		Debug.Log(Application.persistentDataPath);
		Time.timeScale = 1;
		StartCoroutine(call());
	}
	IEnumerator call()
    {
		yield return new WaitForSeconds(1);
		if (int.Parse(SimpelDb.read("npa")) == 1)
			Invoke("CheckForGDPR", 1f);

		Invoke("StartGame", loadingDelay);

	}

	void StartGame ()
	{

		if (int.Parse(SimpelDb.read("Sound")) == 0)
			M_Sound();
		if (int.Parse(SimpelDb.read("Music")) == 0)
			M_Music();
		FindObjectOfType<AudioManager>().PlaySound("background");
		SceneManager.LoadSceneAsync (1);
	}

	//GDPR
	void CheckForGDPR ()
	{

			//show gdpr popup
			GDPR_Popup.SetActive (true);
			//pause the game
			Time.timeScale = 0;
	}

	//Popup events
	public void OnUserClickAccept ()
	{
		FindObjectOfType<AudioManager>().PlaySound("click");
		SimpelDb.update(2.ToString(), "npa");
		//hide gdpr popup
		GDPR_Popup.SetActive (false);
		//play the game
		Time.timeScale = 1;
	}

	public void OnUserClickCancel ()
	{
		FindObjectOfType<AudioManager>().PlaySound("cancel");
		//hide gdpr popup
		GDPR_Popup.SetActive (false);
		//play the game
		Time.timeScale = 1;
	}

	public void OnUserClickPrivacyPolicy ()
	{
		FindObjectOfType<AudioManager>().PlaySound("click");
		Application.OpenURL ("https://sites.google.com/view/runlikecrazy"); //your privacy url
	}

	public void M_Sound()
	{
		FindObjectOfType<AudioManager>().MuteSound("cancel");
		FindObjectOfType<AudioManager>().MuteSound("loos");
		FindObjectOfType<AudioManager>().MuteSound("femal jump");
		FindObjectOfType<AudioManager>().MuteSound("man jump");
		FindObjectOfType<AudioManager>().MuteSound("run");
		FindObjectOfType<AudioManager>().MuteSound("coin");
		FindObjectOfType<AudioManager>().MuteSound("slide");
		FindObjectOfType<AudioManager>().MuteSound("click");
	}
	public void M_Music()
	{
		FindObjectOfType<AudioManager>().MuteSound("background");
	}

}
