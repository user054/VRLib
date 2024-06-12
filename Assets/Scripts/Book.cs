using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Book : MonoBehaviour
{
    Animator anim;

    Transform originalTransform;

    [SerializeField] GameObject setUI;
    [SerializeField] GameObject rentalUI;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        originalTransform = transform;
    }

    public void BookRentalUIActive()
    {
        UIMgr.instance.SetUI(rentalUI);
        UIMgr.instance.DeactiveUI();
        rentalUI.SetActive(true);
    }

    public void BookRentalUIFalse()
    {
        rentalUI.SetActive(false);
    }

    public void OpenBook()
    {
        Debug.Log("Book Opened!");
        if(OpenBookCoroutineCheck == null)
        {
            OpenBookCoroutineCheck = StartCoroutine(OpenBookCoroutine());
        }
           
    }

    Coroutine OpenBookCoroutineCheck = null;
    IEnumerator OpenBookCoroutine()
    {
        anim.SetTrigger("BookOpen");
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        setUI.SetActive(true);
        OpenBookCoroutineCheck = null;
        yield break;
    }

    public void CloseBook()
    {
        Debug.Log("Book Closed!");
        anim.SetTrigger("BookClose");
        setUI.SetActive(false);

    }

}
