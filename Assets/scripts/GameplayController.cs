using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    
    [SerializeField] private Text distancescore,gameoverscoretext, highscore, totalcoinGameover,totalcoinMenu;
    [SerializeField] private GameObject pausePanal,gameoverpanal,destancepanel, menupanal,pausebutten;
    [Header("characters")]
    [SerializeField] private GameObject[] Characters;
    [SerializeField] private GameObject[] Maps;
    int destanceunite = 0;
    public bool gamebegin;
    private int characterSelect;
    private int MapsSelect;


    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    private GameObject playermove;
    private Vector3 playerrespawn;
    private bool loos = false;
    private void Awake()
    {
        string shopDataString = SimpelDb.read("SaveDataShop");
        string shopMapDataString = SimpelDb.read("SaveMapDataShop");
        characterSelect = shopDataString.Contains(":") ? int.Parse(shopDataString.Split(':', ',')[1]) : 0;
        MapsSelect = shopMapDataString.Contains(":") ? int.Parse(shopMapDataString.Split(':', ',')[1]) : 0;
        Debug.Log("MapsSelect" + MapsSelect);
        Debug.Log("characterSelect" + characterSelect);
        Characters[characterSelect].SetActive(true);
        Maps[MapsSelect].SetActive(true);
        charactercontrool.speed = 15f;
        charactercontrool.acceleration = 0.00002f;
        playermove = GameObject.FindGameObjectWithTag("Player");
        
        playerrespawn = playermove.transform.position;
        //playerscore//
       
        InvokeRepeating("setscore", 0, 5/charactercontrool.speed);

        makeinstance();

        StartCoroutine(call_return_loop());
    }
    IEnumerator call_return_loop()
    {
        yield return new WaitForEndOfFrame();
        if (loop_of_return_canva.loop_berig_script == true)
        {
            Beginthegame();
        }
        else
            menupanal.SetActive(true);
        
    }
    
    void makeinstance()
    {
        if (instance == null)
            instance = this;
    }
    private void Update()
    {
        totalcoinGameover.text = "" + int.Parse(SimpelDb.read("TotalCoin"));
        totalcoinMenu.text = "" + int.Parse(SimpelDb.read("TotalCoin"));
    }
    //////////////////////////////////////////playerscore//////////////////////////////
    public void setscore()
    {
        if (charactercontrool.speed != 0 && Enable_Scripts.count_begin == true)
        {
            destanceunite++;
            distancescore.text = destanceunite.ToString();

        }
       
    }
    //////////////////////////////////////////pause//////////////////////////////
    public void pauseThegame()
    {
        FindObjectOfType<AudioManager>().PlaySound("click");
        Time.timeScale = 0f;
        pausePanal.SetActive(true);
    }
    public void RusumeThegame()
    {
        FindObjectOfType<AudioManager>().PlaySound("click");
        Time.timeScale = 1f;
        pausePanal.SetActive(false);

    }
    public void menuhome()
    {
        FindObjectOfType<AudioManager>().PlaySound("click");
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu", LoadSceneMode.Single);

    }
    //////////////////////////////////////////Game over//////////////////////////////
    public void gameover()
    {
        if(loos == false)
        {
            loos = true;
            FindObjectOfType<AudioManager>().PlaySound("loos");
        }
        if (int.Parse(SimpelDb.read("score")) <= destanceunite)
            SimpelDb.update(destanceunite.ToString(),"score");
        StartCoroutine(waitgameover());
    }
    IEnumerator waitgameover()
    {
        yield return new WaitForSeconds(2);
        gameoverpanal.SetActive(true);
        gameoverscoretext.text = destanceunite.ToString();
        highscore.text = SimpelDb.read("score");
        destancepanel.SetActive(false);
        pausebutten.SetActive(false);
    }

//////////////////////////////////////////returne//////////////////////////////
    [Obsolete]
    public void returnegame()
    {
        FindObjectOfType<AudioManager>().PlaySound("click");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        loop_of_return_canva.loop_berig_script = true;
    }


    public void Beginthegame()
    {
        FindObjectOfType<AudioManager>().PlaySound("click");
        StartCoroutine(delay());
        //destancepanel.SetActive(true);
        //pausebutten.SetActive(true);
        //menupanal.SetActive(false);
        //Enable_Scripts.enable_scripte();
        //loop_of_return_canva.loop_berig_script = false;
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        destancepanel.SetActive(true);
        pausebutten.SetActive(true);
        menupanal.SetActive(false);
        Enable_Scripts.enable_scripte();
        loop_of_return_canva.loop_berig_script = false;
    }

    public void Shop()
    {
        FindObjectOfType<AudioManager>().PlaySound("click");
        SceneManager.LoadSceneAsync(2);
    }
}
