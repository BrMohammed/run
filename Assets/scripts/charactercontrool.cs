using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontrool : MonoBehaviour

{
   
    private Rigidbody thisrigid;
    private Vector3 EndToushP, StartTouchP;
    private bool jumpAllowed = false;
    private bool SlideAllowed = false;
    public static float speed = 15f;
   public static float acceleration = 0.00002f;
    public float jumpforce = 5f;
    Animator anim;
    public Transform baraobj,seagull,cristal;
    public float baradestense = 50;
    float jumperate = 0.9f;
    float canjumpe = 0.1f;
    private bool issaad = false;
    private bool enter = false;

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
        speed = 15f;
        acceleration = 0.00002f;
        thisrigid = GetComponent<Rigidbody>();
        GetComponent<Animator>().SetBool("isRuning", true);
        GetComponent<Animator>().SetBool("isJumping", false);
        GetComponent<Animator>().SetBool("isSliding", false);
        StartCoroutine(Bartime());
        StartCoroutine(CoinTime());
    }

    private void Update()
    {
        GetComponent<Rigidbody> ().velocity = new Vector3 (0, thisrigid.velocity.y, speed += acceleration * Time.deltaTime);
        if (issaad == false)
        {

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                StartTouchP = Input.GetTouch(0).position;
            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                EndToushP = Input.GetTouch(0).position;
                if (StartTouchP.y < EndToushP.y && (thisrigid.velocity.y > -1 && thisrigid.velocity.y < 0))
                    jumpAllowed = true;
                if (StartTouchP.y > EndToushP.y)
                    SlideAllowed = true;
            }

        }
    }

    private void FixedUpdate()
    {

        Actions();
    }
    private void Actions()
    {
        if (jumpAllowed && issaad == false)
        {
            thisrigid.AddForce(Vector3.up * jumpforce);
            GetComponent<Animator>().SetBool("isJumping", true);
            GetComponent<Animator>().SetBool("isRuning", false);
            StartCoroutine(passiveMe());
            jumpAllowed = false;
        }
        if (SlideAllowed && issaad == false)
        {
            GetComponent<Animator>().SetBool("isSliding", true);
            GetComponent<Animator>().SetBool("isRuning", false);
            StartCoroutine(passiveMe());
            SlideAllowed = false;
        }
       
    }
    IEnumerator passiveMe()
    {
        yield return new WaitForSeconds(0.4f);
        if (issaad == false)
        {
            GetComponent<Animator>().SetBool("isRuning", true);
            GetComponent<Animator>().SetBool("isSliding", false);
            GetComponent<Animator>().SetBool("isJumping", false);
        }
    }
    /////////////////////////////////////////bara tatch/////////////////

    void OnCollisionEnter(Collision character)
    {
        if (character.gameObject.name == "bara(Clone)")
        {
            issaad = true;
            speed = 0;
            acceleration = 0;
            GetComponent<Animator>().SetTrigger("issad");
            GameplayController.instance.gameover();
        }
    }

    /// ///////// ///////// suegulle //////////////

    private void OnTriggerEnter(Collider character)
    {
        
        if (character.gameObject.tag == "Bara")
        {
            issaad = true;
            speed = 0;
            acceleration = 0;
            GetComponent<Animator>().SetTrigger("isdied");
            GameplayController.instance.gameover();
        }
        
    }
    private IEnumerator enter01()
    {
        yield return new WaitForEndOfFrame();
        enter = true;
    }

    /////////////////////////////bara Instantiate//////////////////////////////////

    IEnumerator Bartime()
    {
        while ( speed != 0 )
        {
            if(Random.Range(0, 10) <= 8)
                Instantiate(baraobj, new Vector3(0, 1.31f, transform.position.z + baradestense), baraobj.rotation);
            else
                Instantiate(seagull, new Vector3(0.25f, 2.86f, transform.position.z + baradestense), seagull.rotation);
            yield return new WaitForSeconds(Random.Range(1.2f,2f));

        }
    }
    IEnumerator CoinTime()
    {
        while (speed != 0)
        {
            Instantiate(cristal, new Vector3(0.30f, 0.6f, transform.position.z + baradestense + Random.Range(50, 90)), cristal.rotation);
            yield return new WaitForSeconds(Random.Range(8f, 20f));
        }

    }
}
