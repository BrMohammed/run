using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimation : MonoBehaviour
{

    [SerializeField]
    GameObject startobj, paramobj, sharobj, likeobj;
    void Start()
    {
        LeanTween.scale(startobj, new Vector3(1.767763f, 9.080779f, 1.874742f), 1.5f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(sharobj, new Vector3(0.8221743f, 4.358987f, 0.8221743f), 1.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(paramobj, new Vector3(0.8221743f, 4.358987f, 0.8221743f), 1.5f).setDelay(0.7f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(likeobj, new Vector3(0.8221743f, 4.358987f, 0.8221743f), 1.5f).setDelay(0.8f).setEase(LeanTweenType.easeOutElastic);
    }

    public void close()
    {
        LeanTween.scale(startobj, new Vector3(0, 0, 0), 0.9f).setDelay(0.2f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.scale(sharobj, new Vector3(0, 0, 0), 0.8f).setDelay(0.3f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.scale(paramobj, new Vector3(0, 0, 0), 0.7f).setDelay(0.4f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.scale(likeobj, new Vector3(0, 0, 0), 0.6f).setDelay(0.5f).setEase(LeanTweenType.easeInOutBack);
    }
}
