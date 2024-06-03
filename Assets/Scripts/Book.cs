using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Book : MonoBehaviour
{
    Animator anim;

    Transform originalTransform;

    [SerializeField] GameObject setUI;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        originalTransform = transform;
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
