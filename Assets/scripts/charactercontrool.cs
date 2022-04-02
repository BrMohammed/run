using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontrool : MonoBehaviour

{
    
    private Rigidbody thisrigid;
    public static float speed = 15f;
   public static float acceleration = 0.00002f;
    public float jumpforce = 5f;
    Animator anim;
    public Transform baraobj;
    public float baradestense = 50;
    float jumperate = 0.9f;
    float canjumpe = 0.1f;
    private bool issaad = false;

    
    void Start()
    {
        Debug.Log("highscore : " +SimpelDb.read());
        speed = 15f;
        acceleration = 0.00002f;
        thisrigid = GetComponent<Rigidbody>();
        GetComponent<Animator>().SetBool("isRuning", true);
        StartCoroutine(Bartime());
    }

    void Update()
    {
        GetComponent<Rigidbody> ().velocity = new Vector3 (0, thisrigid.velocity.y, speed += acceleration * Time.deltaTime);
        if (issaad == false)
        {
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space))
            {
                if(Time.time > canjumpe)
                {
                    thisrigid.velocity = new Vector3(0, jumpforce, 0);
                    GetComponent<Animator>().SetBool("isRuning", false);
                    canjumpe = Time.time + jumperate;
                    StartCoroutine(passiveMe(0.6f));
                }
            }
           // if(Time.time < canjumpe)
             //   GetComponent<Animator>().SetBool("isRuning", true);
        }  
    }

    IEnumerator passiveMe(float secs)
    {
        yield return new WaitForSeconds(secs);
        if(issaad == false)
            GetComponent<Animator>().SetBool("isRuning", true);
    }

    /////////////////////////////////////////bara tatch/////////////////
    
    void OnCollisionEnter(Collision character)
    {
         
        if (character.gameObject.name == "bara(Clone)")
        {
            issaad = true;
            speed = 0;
            acceleration = 0;
            GetComponent<Animator>().SetBool("issad", true);
            GameplayController.instance.gameover();
        }
    }

    /////////////////////////////bara Instantiate//////////////////////////////////
    
    IEnumerator Bartime()
    {
        while ( speed != 0 )
        {
            Instantiate(baraobj, new Vector3(0, 1.31f, transform.position.z + baradestense), baraobj.rotation);
            yield return new WaitForSeconds(Random.Range(0.7f,2f));

        }
    }

}
