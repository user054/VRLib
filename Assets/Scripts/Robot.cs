using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class Robot : ButtonPressFunc
{
    UnityEngine.XR.InputDevice device;
    [SerializeField] XRController controller;
    [SerializeField] GameObject []robotUI;
    bool leftPressed = false;
    bool rightPressed = false;
    int imageIndex = 0;

    private void Start()
    {
        device = controller.inputDevice;
        StartCoroutine(BookRentalComplete());
    }
    private void Update()
    {
        InputHelpers.IsPressed(controller.inputDevice, InputHelpers.Button.SecondaryButton, out leftPressed);
        InputHelpers.IsPressed(controller.inputDevice, InputHelpers.Button.PrimaryButton, out rightPressed);   
    }

    public override void TriggerButtonPress()
    {
        MainUiActive();
    }

    public override void TriggerButtonUp()
    {
        for (int i = 0; i < robotUI.Length; i++)
        {
            robotUI[i].SetActive(false);
        }
        //robotUI[0].SetActive(false);
    }

    void MainUiActive()
    {
        robotUI[0].SetActive(true);
    }

    IEnumerator BookRentalComplete()
    {
        while(true)
        {
            if(leftPressed == false && rightPressed ==false)
            {
                while(true)
                {
                    if (leftPressed == true)
                    {
                        robotUI[imageIndex].SetActive(false);
                        imageIndex--;

                        if(imageIndex > robotUI.Length - 1)
                        {
                            imageIndex = robotUI.Length - 1;
                        }
                        else if(imageIndex < 0)
                        {
                            imageIndex = 0;
                        }

                        robotUI[imageIndex].SetActive(true);

                        //yield return new WaitForSeconds(1.0f);
                        
                    }
                    else if(rightPressed == true)
                    {
                        robotUI[imageIndex].SetActive(false);
                        imageIndex++;

                        if(imageIndex > robotUI.Length - 1)
                        {
                            imageIndex = robotUI.Length - 1;
                        }
                        else if(imageIndex < 0)
                        {
                            imageIndex = 0;
                        }

                        robotUI[imageIndex].SetActive(true);

                        //yield return new WaitForSeconds(1.0f);
                    }
                    yield return null;
                }   
            }

            yield return null;
        }
    }

}
