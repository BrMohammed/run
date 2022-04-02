using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafol : MonoBehaviour
{

    private Rigidbody thisrigid;
    void Start()
    {
        thisrigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, thisrigid.velocity.y, charactercontrool.speed += charactercontrool.acceleration );


    }
}
