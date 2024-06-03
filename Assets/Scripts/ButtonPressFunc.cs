using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressFunc : MonoBehaviour
{
    public virtual void TriggerButtonPress()
    {
        Debug.Log("Button Pressed!");
    }

    public virtual void TriggerButtonUp()
    {
        Debug.Log("Button Released!");
    } 

    
}
