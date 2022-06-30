﻿using System.Collections;
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

    private float period = 0f;
    /// 

    public float gravity = 15;
    public float gravity_delay = 0.3f;
    private int characterSelect;

    Vector3 destent_for_cristal;

  //  private ConstantForce gravity;

    private void Start()
    {
        speed = 15f;
        acceleration = 0.00002f;

        thisrigid = GetComponent<Rigidbody>();
        GetComponent<Animator>().SetBool("isRuning", true);
        GetComponent<Animator>().SetBool("isJumping", false);
        GetComponent<Animator>().SetBool("isSliding", false);
        StartCoroutine(Bartime());
        StartCoroutine(CoinTime());
        string shopDataString = SimpelDb.read("SaveDataShop");
        characterSelect = shopDataString.Contains(":") ? int.Parse(shopDataString.Split(':', ',')[1]) : 0;
    }

    private void Update()
    {
        
        GetComponent<Rigidbody> ().velocity = new Vector3 (0, thisrigid.velocity.y, speed += acceleration * Time.deltaTime);
        period += Time.deltaTime;
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
            if(SlideAllowed == true || jumpAllowed == true)
                period = -0.64f;
            else if (period >= 0.36f)
            {
                period = 0f;
                FindObjectOfType<AudioManager>().PlaySound("run");
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
            if (characterSelect < 2)
                FindObjectOfType<AudioManager>().PlaySound("man jump");
            else
                FindObjectOfType<AudioManager>().PlaySound("femal jump");
            Jump();
            GetComponent<Animator>().SetBool("isJumping", true);
            GetComponent<Animator>().SetBool("isRuning", false);
            StartCoroutine(passiveMe());
            jumpAllowed = false;
        }
        if (SlideAllowed && issaad == false)
        {
            FindObjectOfType<AudioManager>().PlaySound("slide");
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


    void Jump()
    {
        thisrigid.AddForce(Vector3.up * jumpforce);
        StartCoroutine(deley_jump());
    }
    IEnumerator deley_jump()
    {
        yield return new WaitForSeconds(gravity_delay);
        thisrigid.AddForce(Vector3.down * gravity);
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
            GetComponent<Animator>().SetBool("isSliding", false);
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
        while (speed != 0)
        {
            if(Random.Range(0, 10) <= 8)
                Instantiate(baraobj, new Vector3(0, 1.31f, transform.position.z + baradestense), baraobj.rotation);
            else
                Instantiate(seagull, new Vector3(0.25f, 2.86f, transform.position.z + baradestense), seagull.rotation);
            yield return new WaitForSeconds(Random.Range(1.1f,2f));
            destent_for_cristal.z = transform.position.z + baradestense;
        }
    }
    IEnumerator CoinTime()
    {
        while (speed != 0)
        {
            Debug.Log(transform.position.z + baradestense + 20);
            Debug.Log(destent_for_cristal.z);
            if (transform.position.z + baradestense + 20 < destent_for_cristal.z || transform.position.z + baradestense + 20 > destent_for_cristal.z)
            Instantiate(cristal, new Vector3(0.30f, 0.6f, transform.position.z + baradestense + Random.Range(50, 90)), cristal.rotation);
            yield return new WaitForSeconds(Random.Range(8f, 15f));
        }

    }
}
