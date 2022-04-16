using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroydroad : MonoBehaviour
{
    public float destroytime;
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
