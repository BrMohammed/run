using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readtrigger : MonoBehaviour
{
    public Transform reodprifabe;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter(Collider character)
    {
        
        if (character.tag == "Player" )
        {
           Instantiate(reodprifabe, new Vector3(0, 0, transform.parent.position.z + 262.4f), reodprifabe.rotation);
            
        }

        


    }
}
