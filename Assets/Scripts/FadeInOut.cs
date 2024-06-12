using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] Image fadeImage;

    //fadeType = ���̵带 ������ �ƿ����� ������ �ڵ�(0 = ���̵�ƿ�, 1 = ���̵���) fadeValue = ������ �̹��� ���İ�(0~1), finalFadeValue = ���� �̹��� ���İ�(0~1), imageFadeSpeed = ���İ��� �����ϴ� �ӵ�
    public void DisplayFadeInOutController(int fadeType, float fadeValue, float finalFadeValue, float imageFadeSpeed)
    {
        StartCoroutine(PanelFadeCoroutine( fadeType,  fadeValue,  finalFadeValue,  imageFadeSpeed));

    }

    IEnumerator PanelFadeCoroutine(int fadeType, float fadeValue, float finalFadeValue, float imageFadeSpeed)
    {
        while (true)
        {
            fadeValue += imageFadeSpeed;
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = new Color(0, 0, 0, fadeValue);

            if (fadeType == 0 && fadeValue > finalFadeValue)
            {
                yield break;
            }
            else if (fadeType == 1 && fadeValue < finalFadeValue)
            {
                yield break;
            }

        }

    }



}
