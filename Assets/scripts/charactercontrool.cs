﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontrool : MonoBehaviour

{
   
    private Rigidbody thisrigid;
    private Vector3 EndToushP, StartTouchP;
    private bool jumpAllowed = false;
    private bool SlideAllowed = false;
    public static float speed;
    public static float acceleration;
    public float jumpforce = 5f;
    public Transform baraobj,seagull,cristal;
    public float baradestense = 50;
    public static bool issaad = false;
    private bool enter = false;
    private float period = 0f;
    public float gravity = 15;
    public float gravity_delay = 0.3f;
    private int characterSelect;
    Vector3 destent_for_cristal;
    private int baracount = 0;
    [SerializeField] private GameObject Camera;
    float p;
    private void Start()
    {
        speed = 20f;
        acceleration = 0.00002f;
        thisrigid = GetComponent<Rigidbody>();
        GetComponent<Animator>().SetBool("isRuning", true);
        GetComponent<Animator>().SetBool("isJumping", false);
        GetComponent<Animator>().SetBool("isSliding", false);
        StartCoroutine(Bartime());
        StartCoroutine(CoinTime());
        string shopDataString = SimpelDb.read("SaveDataShop");
        characterSelect = shopDataString.Contains(":") ? int.Parse(shopDataString.Split(':', ',')[1]) : 0;
        p = this.transform.position.z - Camera.transform.position.z;
    }

    private void Update()
    {
        speed += acceleration * Time.deltaTime;
        GetComponent<Rigidbody> ().velocity = new Vector3 (0, thisrigid.velocity.y, speed);
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, this.transform.position.z - p);
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
        while (issaad != true)
        {
            if(Random.Range(0, 10) <= 8)
            {
                Transform newGameObject;
                baracount++;
                newGameObject  = Instantiate(baraobj, new Vector3(0, 1.31f, transform.position.z + baradestense), baraobj.rotation);
                if(baracount % 2 == 0)
                {
                    for (var i = newGameObject.transform.childCount - 1; i >= 0; i--)
                    {
                        Object.Destroy(newGameObject.transform.GetChild(i).gameObject);
                    }
                }
            }
            else
                Instantiate(seagull, new Vector3(0.25f, 2.86f, transform.position.z + baradestense), seagull.rotation);
            yield return new WaitForSeconds(Random.Range(1.3f,3f));
            destent_for_cristal.z = transform.position.z + baradestense;
        }
    }
    IEnumerator CoinTime()
    {
        while (issaad != true)
        {
            //Debug.Log(transform.position.z + baradestense + 20);
           // Debug.Log(destent_for_cristal.z);
            if (transform.position.z + baradestense + 20 < destent_for_cristal.z || transform.position.z + baradestense + 20 > destent_for_cristal.z)
            Instantiate(cristal, new Vector3(0.30f, 0.6f, transform.position.z + baradestense + Random.Range(50, 90)), cristal.rotation);
            yield return new WaitForSeconds(Random.Range(8f, 15f));
        }

    }
}
