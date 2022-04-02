using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;



public class speed : MonoBehaviour
{
    [SerializeField] public  float speed2 = 10f;
    void Start()
    {
        GetComponent<Animator>().SetBool("isRuning", true);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, speed2);
        GetComponent<Animator>().SetBool("isRuning", true);
        
    }
}
