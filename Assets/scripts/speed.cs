using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;



public class speed : MonoBehaviour
{
    [SerializeField] public  float speed2 = 10f;
    [SerializeField] private GameObject Camera;
    float p;
    void Start()
    {
        GetComponent<Animator>().SetBool("isRuning", true);
        p = this.transform.position.z - Camera.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
        GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, speed2);
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, this.transform.position.z - p );
        GetComponent<Animator>().SetBool("isRuning", true);
        
    }
}
