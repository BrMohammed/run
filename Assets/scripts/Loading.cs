using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
	[SerializeField] [Range(2f,8f)] float loadingDelay = 2f;
	[SerializeField]  GameObject GDPR_Popup;
	static int npa = 1;
	
	void OnEnable()
	{
		
		Time.timeScale = 1;
		
		if (PlayerPrefs.GetInt("npa", npa) == 1)
			Invoke("CheckForGDPR", 1f);

		Invoke ("StartGame", loadingDelay);
	}

	void StartGame ()
	{
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
		
		PlayerPrefs.SetInt("npa", 2);


		//hide gdpr popup
		GDPR_Popup.SetActive (false);
		//play the game
		Time.timeScale = 1;
	}

	public void OnUserClickCancel ()
	{

		

		//hide gdpr popup
		GDPR_Popup.SetActive (false);
		//play the game
		Time.timeScale = 1;
	}

	public void OnUserClickPrivacyPolicy ()
	{
		Application.OpenURL ("https://www.google.com/"); //your privacy url
	}

}
