using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_on_off : MonoBehaviour
{
    [SerializeField] GameObject UI;

    public void UI_on()
    {
        UI.SetActive(true);
    }
    
    public void UI_off()
    {
        UI.SetActive(false);
    }

}
