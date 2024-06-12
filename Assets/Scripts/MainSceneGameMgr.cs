using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneGameMgr : MonoBehaviour
{
    [SerializeField] FadeInOut fadeInOut;
    [SerializeField] float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        fadeInOut.DisplayFadeInOutController(1, 1.0f, 0.0f, -fadeSpeed);

    }

    public void FadeOutStart()
    {
        fadeInOut.DisplayFadeInOutController(0, 0.0f, 1.0f, fadeSpeed);
    }

}
