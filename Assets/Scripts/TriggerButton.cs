using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerButton : MonoBehaviour
{
    private XRBaseInteractor interactor; // Reference to the interactor component

    private void Start()
    {
        // Get the XRBaseInteractor component attached to this game object
        interactor = GetComponent<XRBaseInteractor>();

        // Subscribe to the OnHoverEntered event using a lambda expression
        interactor.hoverEntered.AddListener(args => OnHoverEntered(args));

        // Subscribe to the OnHoverExited event
        interactor.hoverExited.AddListener(args => OnHoverExited(args));
    }

    GameObject hoveredObject = null;
    Coroutine triggerButtonPressCoroutine = null;
    private void OnHoverExited(HoverExitEventArgs args)
    {
        hoveredObject = null;
        if (triggerButtonPressCoroutine != null)
        {
            StopCoroutine(triggerButtonPressCoroutine);
        }
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        hoveredObject = args.interactable.gameObject;
        triggerButtonPressCoroutine = StartCoroutine(TriggerButtonPress());
    }

    IEnumerator TriggerButtonPress()
    {
        while(true)
        {
            if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
            {
                hoveredObject.GetComponent<ButtonPressFunc>().TriggerButtonPress();
                break;
            }
            yield return null;
        }
    }


}




