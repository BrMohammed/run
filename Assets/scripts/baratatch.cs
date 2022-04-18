using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baratatch : MonoBehaviour
{
    public Transform baraobj;
    public float baradestense = 50f;
    void Start()
    {
        StartCoroutine(bartime());
    }

    IEnumerator bartime()
    {
        Instantiate(baraobj, new Vector3(0, 0, transform.parent.position.z + baradestense), baraobj.rotation);
        yield return new WaitForSeconds(Random.Range(1, 4));
    }
}
