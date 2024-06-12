using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public static UIMgr instance;

    GameObject curUI = null;

    public UIMgr Instance 
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SetUI(GameObject _ui)
    {
        curUI = _ui;
    }

    public void ActiveUI()
    {
        if(curUI != null)
            curUI.SetActive(true);
    }

    public void DeactiveUI()
    {
        if (curUI != null)
            curUI.SetActive(false);
    }



}
