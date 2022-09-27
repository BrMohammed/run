using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readtrigger : MonoBehaviour
{
    public Transform reodprifabe;
    void OnTriggerEnter(Collider character)
    {
        
        if (character.gameObject.tag == "Player" )
        {
           Instantiate(reodprifabe, new Vector3(0, 0, transform.parent.position.z + 262.4f), reodprifabe.rotation);
            
        }
    }
}
