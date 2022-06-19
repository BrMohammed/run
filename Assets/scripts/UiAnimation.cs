using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimation : MonoBehaviour
{

    [SerializeField]
    GameObject startobj, paramobj, sharobj, likeobj;
    void Start()
    {
        LeanTween.scale(startobj, new Vector3(1.767763f, 9.080779f, 1.874742f), 1f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(sharobj, new Vector3(0.8221743f, 4.358987f, 0.8221743f), 1f).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(paramobj, new Vector3(0.8221743f, 4.358987f, 0.8221743f), 1f).setDelay(0.4f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(likeobj, new Vector3(0.8221743f, 4.358987f, 0.8221743f), 1f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
    }

    public void close()
    {
        LeanTween.scale(startobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(sharobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(paramobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(likeobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.4f).setEase(LeanTweenType.easeOutElastic);
    }

    static public void PausePaneleEAffects(GameObject resumeicoobj, GameObject homeicoobj, GameObject returnicoob)
    {
         Vector3 val1, val2, val3;

        val1 = resumeicoobj.transform.localScale;
        val2 = homeicoobj.transform.localScale;
        val3 = returnicoob.transform.localScale;

        resumeicoobj.transform.localScale = new Vector3(0f, 0f, 0f);
        homeicoobj.transform.localScale = new Vector3(0f, 0f, 0f);
        returnicoob.transform.localScale = new Vector3(0f, 0f, 0f);



        LeanTween.scale(resumeicoobj,new Vector3(val1.x, val1.y, val1.z), 1f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
        LeanTween.scale(homeicoobj, new Vector3(val2.x, val2.y, val2.z), 1f).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
        LeanTween.scale(returnicoob, new Vector3(val3.x, val3.y, val3.z), 1f).setDelay(0.4f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
    }
}
