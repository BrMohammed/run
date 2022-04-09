using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    
    [SerializeField] private Text distancescore,gameoverscoretext, highscore;
    [SerializeField] private GameObject pausePanal,gameoverpanal,destancepanel, menupanal,pausebutten;
    int destanceunite = 0;
    public bool gamebegin;


    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    private GameObject playermove;
    private Vector3 playerrespawn;
    private void Awake()
    {
        
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
        Time.timeScale = 0f;
        pausePanal.SetActive(true);
    }
    public void RusumeThegame()
    {
        Time.timeScale = 1f;
        pausePanal.SetActive(false);

    }
    public void menuhome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu", LoadSceneMode.Single);

    }
    //////////////////////////////////////////Game over//////////////////////////////
    public void gameover()
    {
        if(int.Parse(SimpelDb.read("score")) <= destanceunite)
            SimpelDb.update(destanceunite,"score");

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
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        loop_of_return_canva.loop_berig_script = true;
    }


    public void Beginthegame()
    {
        destancepanel.SetActive(true);
        pausebutten.SetActive(true);
        menupanal.SetActive(false);
        Enable_Scripts.enable_scripte();
        loop_of_return_canva.loop_berig_script = false;
    }

}
