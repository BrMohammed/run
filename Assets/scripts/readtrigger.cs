using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readtrigger : MonoBehaviour
{
    public Transform reodprifabe;
    bool is_insade;

    private void Awake()
    {
        is_insade = false;
    }


    void OnTriggerEnter(Collider character)
    {
        
        if (character.gameObject.tag == "Player" & is_insade == false )
        {
            is_insade = true;
            Instantiate(reodprifabe, new Vector3(0, 0, transform.parent.position.z + 262.4f), reodprifabe.rotation);
            
        }
    }
}
