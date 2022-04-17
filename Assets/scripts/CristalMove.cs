using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalMove : MonoBehaviour
{
    private Rigidbody Cristal;
    [SerializeField]private float Speed = 2f;
    [SerializeField] private float Rspeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Cristal = GetComponent<Rigidbody>();
        Cristal.velocity = new Vector3(0, Speed * Time.deltaTime, Cristal.velocity.z);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Cristal.velocity.y);
        if (Cristal.worldCenterOfMass.y >= 1.3f )
            Cristal.velocity = new Vector3(0, -Speed * Time.deltaTime, Cristal.velocity.z);
        else if (Cristal.worldCenterOfMass.y <= 0.6f)
            Cristal.velocity = new Vector3(0, Speed * Time.deltaTime, Cristal.velocity.z);
        transform.Rotate(Vector3.up * Rspeed * Time.deltaTime);

    }
}
