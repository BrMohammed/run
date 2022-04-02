using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menucontroler : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    
    public void Beginthegame()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("game");
        SceneManager.LoadScene("game", LoadSceneMode.Single);


    }
}
