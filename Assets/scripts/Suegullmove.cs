using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suegullmove : MonoBehaviour
{
    private Rigidbody SuegullBody;
    [SerializeField] private float speed = 2;

    private void Start()
    {
        SuegullBody = GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter(Collider character)
    {
        if(character.gameObject.tag == "Player")
            SuegullBody.velocity = new Vector3(0, SuegullBody.velocity.y, -speed * Time.deltaTime);
    }
}
