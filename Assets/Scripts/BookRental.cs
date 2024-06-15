
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookRental : MonoBehaviour
{
    [SerializeField] UnityEngine.XR.InputDevice device;
    [SerializeField] XRController controller;

    [SerializeField] GameObject rentalCompleteUI;

    NextScene nextScene;

    private void OnEnable()
    {
        isPressed = false;
        StartCoroutine(BookRentalComplete());
    }


    private void Start()
    {
        device = controller.inputDevice;
        nextScene = FindObjectOfType<NextScene>();
    }

    private void Update()
    {
        InputHelpers.IsPressed(controller.inputDevice, InputHelpers.Button.PrimaryButton, out isPressed);
    }

    bool isPressed = false;
    IEnumerator BookRentalComplete()
    {
        while(true)
        {
            if(isPressed == false)
            {
                while(true)
                {
                    if (isPressed == true)
                    {
                        UIMgr.instance.DeactiveUI();
                        rentalCompleteUI.SetActive(true);
                        nextScene.NextGameScene("EndScene");
                        yield return new WaitForSeconds(3.0f);
                        
                    }
                    yield return null;
                }   
            }

            yield return null;
        }
    }

}
