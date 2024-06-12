using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class TriggerButton : MonoBehaviour
{
    private XRBaseInteractor interactor; // Reference to the interactor component

    [SerializeField] UnityEngine.XR.InputDevice device;
    [SerializeField] XRController controller;

    private void Start()
    {
        // Get the XRBaseInteractor component attached to this game object
        interactor = GetComponent<XRBaseInteractor>();

        device = controller.inputDevice;

        // Subscribe to the OnHoverEntered event using a lambda expression
        interactor.hoverEntered.AddListener(args => OnHoverEntered(args));

        // Subscribe to the OnHoverExited event
        interactor.hoverExited.AddListener(args => OnHoverExited(args));
    }

    GameObject hoveredObject = null;
    Coroutine triggerButtonPressCoroutine = null;
    private void OnHoverExited(HoverExitEventArgs args)
    {
        if(hoveredObject != null)
        {
            if(hoveredObject.TryGetComponent(out ButtonPressFunc buttonPressFunc))
            {
                hoveredObject.GetComponent<ButtonPressFunc>().TriggerButtonUp();
            }
            hoveredObject = null;
        }

        if (triggerButtonPressCoroutine != null)
        {
            StopCoroutine(triggerButtonPressCoroutine);
        }
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        hoveredObject = args.interactableObject.transform.gameObject;
        triggerButtonPressCoroutine = StartCoroutine(TriggerButtonPress());
    }

    IEnumerator TriggerButtonPress()
    {
        //print(controller.inputDevice);
        bool isPressed = false;
        while(true)
        {
            InputHelpers.IsPressed(controller.inputDevice, InputHelpers.Button.TriggerButton, out isPressed);
            if(hoveredObject != null)
            {
                if(isPressed == true)
                {         
                    if(hoveredObject.TryGetComponent(out ButtonPressFunc buttonPressFunc))
                    {
                        hoveredObject.GetComponent<ButtonPressFunc>().TriggerButtonPress();
                    }
                }
                else
                {
                    //print("jkl");
                    if(hoveredObject.TryGetComponent(out ButtonPressFunc buttonPressFunc))
                    {
                        hoveredObject.GetComponent<ButtonPressFunc>().TriggerButtonUp();
                    }
                    
                }
            }

            yield return null;
        }
    }


}




