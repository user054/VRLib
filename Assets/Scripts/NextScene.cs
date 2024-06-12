using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    [SerializeField] GameObject image;
    [SerializeField] float fadeSpeed = 0.01f;


    public void NextGameScene(string sScene)
    {
        image.GetComponent<FadeInOut>().DisplayFadeInOutController(0, 0.0f, 1.0f, fadeSpeed);

        StartCoroutine(SceneChangeCoroutine(sScene));

    }

    IEnumerator SceneChangeCoroutine(string sScene)
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(sScene);


    }

}
