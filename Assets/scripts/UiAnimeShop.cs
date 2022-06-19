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
            LeanTween.moveLocalX(Soundobj, 21f, 0.3f);
            LeanTween.scaleX(Soundobj, 1.82f, 0.3f);
            if(begin == 0)
                LeanTween.moveLocalY(Soundobj, Soundobj.transform.localPosition.y - 25f, 1.5f).setEaseInOutSine().setLoopPingPong();
            Double = 0;
            begin = 1;
        }
        else
        {
            LeanTween.moveLocalX(Soundobj, 214.35f, 0.3f);
            LeanTween.scaleX(Soundobj, 0f, 0.3f);
            Double = 1;
        }
        
    }
}
