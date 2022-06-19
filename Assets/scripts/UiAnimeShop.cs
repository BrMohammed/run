using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimeShop : MonoBehaviour
{
    [SerializeField] GameObject Soundobj;
    private int Double = 1;
    private int begin = 0;
    void Start()
    {
        
    }

    public void motion()
    {
        if(Double == 1)
        {
            LeanTween.moveLocalX(Soundobj, 21f, 0.2f);
            LeanTween.scaleX(Soundobj, 1.82f, 0.2f);
            if(begin == 0)
                LeanTween.moveLocalY(Soundobj, Soundobj.transform.localPosition.y - 25f, 1f).setEaseInOutSine().setLoopPingPong();
            Double = 0;
            begin = 1;
        }
        else
        {
            LeanTween.moveLocalX(Soundobj, 214.35f, 0.2f);
            LeanTween.scaleX(Soundobj, 0f, 0.2f);
            Double = 1;
        }
    }
    static public void butten_haver(GameObject buttenobj)
    {
        LeanTween.scale(buttenobj, new Vector3(buttenobj.transform.localScale.x / 1.5f, buttenobj.transform.localScale.y / 1.5f, buttenobj.transform.localScale.z / 1.5f),0.05f);
        LeanTween.scale(buttenobj, new Vector3((buttenobj.transform.localScale.x / 1.5f) * 1.5f, (buttenobj.transform.localScale.y / 1.5f) * 1.5f, (buttenobj.transform.localScale.z / 1.5f) * 1.5f), 0.05f).setDelay(0.05f);
    }
}
