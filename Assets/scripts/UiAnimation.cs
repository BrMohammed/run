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
        resumeicoobj.transform.localScale = new Vector3(0f, 0f, 0f);
        homeicoobj.transform.localScale = new Vector3(0f, 0f, 0f);
        returnicoob.transform.localScale = new Vector3(0f, 0f, 0f);

        LeanTween.scale(resumeicoobj, new Vector3(0.5349266f, 0.5349266f, 0.5349266f), 1f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
        LeanTween.scale(homeicoobj, new Vector3(0.6832607f, 3.211845f, 0.6832607f), 1f).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
        LeanTween.scale(returnicoob, new Vector3(0.557861f, 2.957656f, 0.557861f), 1f).setDelay(0.4f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
    }

    static public void closePausePaneleEAffects(GameObject resumeicoobj, GameObject homeicoobj, GameObject returnicoob)
    {
        LeanTween.scale(resumeicoobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
        LeanTween.scale(homeicoobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
        LeanTween.scale(returnicoob, new Vector3(0, 0, 0), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
    }

    static public void butten_haver(GameObject buttenobj)
    {
        LeanTween.scale(buttenobj, new Vector3(buttenobj.transform.localScale.x / 1.5f, buttenobj.transform.localScale.y / 1.5f, buttenobj.transform.localScale.z / 1.5f), 0.05f).setIgnoreTimeScale(true);
        LeanTween.scale(buttenobj, new Vector3((buttenobj.transform.localScale.x / 1.5f) * 1.5f, (buttenobj.transform.localScale.y / 1.5f) * 1.5f, (buttenobj.transform.localScale.z / 1.5f) * 1.5f), 0.05f).setDelay(0.05f).setIgnoreTimeScale(true);
    }
}
