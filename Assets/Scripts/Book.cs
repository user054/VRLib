using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Book : MonoBehaviour
{
    Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenBook()
    {
        Debug.Log("Book Opened!");
        anim.SetTrigger("BookOpen");
        
    }

    public void CloseBook()
    {
        Debug.Log("Book Closed!");
        anim.SetTrigger("BookClose");

    }

}
