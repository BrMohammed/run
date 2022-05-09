using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalMove : MonoBehaviour
{
    private Rigidbody Cristal;
    [SerializeField]private float Speed = 2f;
    [SerializeField] private float Rspeed = 2f;
  
    void Start()
    {
        Cristal = GetComponent<Rigidbody>();
        Cristal.velocity = new Vector3(0, Speed * Time.deltaTime, Cristal.velocity.z);
    }

    void Update()
    {
        if (Cristal.worldCenterOfMass.y >= 1.3f )
            Cristal.velocity = new Vector3(0, -Speed * Time.deltaTime, Cristal.velocity.z);
        else if (Cristal.worldCenterOfMass.y <= 0.6f)
            Cristal.velocity = new Vector3(0, Speed * Time.deltaTime, Cristal.velocity.z);
        transform.Rotate(Vector3.up * Rspeed * Time.deltaTime);
    }
 
    private void OnTriggerEnter(Collider character)
    {
        if (character.gameObject.tag == "Player")
        {
            int totalcoin = int.Parse(SimpelDb.read("TotalCoin"));
            totalcoin++;
            SimpelDb.update(totalcoin.ToString(), "TotalCoin");
            Debug.Log(totalcoin);
            Destroy(gameObject);
        }
    }
}
