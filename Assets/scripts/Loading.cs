using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Loading : MonoBehaviour
{
	[SerializeField] [Range(2f,8f)] float loadingDelay = 2f;
	[SerializeField]  GameObject GDPR_Popup;
	//static int npa = 1;
	
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
		Application.OpenURL ("https://www.google.com/"); //your privacy url
	}

}
