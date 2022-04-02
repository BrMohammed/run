using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroydroad : MonoBehaviour
{
    public float destroytime = 60;
    private float currenttime;
    
    void Update()
    {
        currenttime += Time.deltaTime;
        if(currenttime > destroytime && charactercontrool.speed != 0)
        {
            Destroy(gameObject);
        }
    }
}
