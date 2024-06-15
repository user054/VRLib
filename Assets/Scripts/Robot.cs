using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : ButtonPressFunc
{
    [SerializeField] GameObject []robotUI;

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

}
