using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafol : MonoBehaviour
{

    private Rigidbody thisrigid;
    private GameObject playermove;
    void Start()
    {
        //thisrigid = GetComponent<Rigidbody>();
        //playermove = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(0, playermove.GetComponent<Rigidbody>().velocity.y, playermove.GetComponent<Rigidbody>().velocity.z);
        ////GetComponent<Rigidbody>().velocity = new Vector3(0, thisrigid.velocity.y, charactercontrool.speed);
        //Debug.Log(charactercontrool.speed);
        //float pv = Input.GetAxis("Vertical");
        //float ph = Input.GetAxis("Horizontal");

        //Vector3 forward = Camera.main.transform.forward;
        //Vector3 right = Camera.main.transform.right;


        //Vector3 frvi = pv * forward;
        //Vector3 rrhi = ph * right;

        //Vector3 camerarolativetomovement = frvi + rrhi;
        //this.transform.Translate(camerarolativetomovement, Space.World);
    }
}
