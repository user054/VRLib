using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFollow : MonoBehaviour
{
    [SerializeField] GameObject target;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(2 * transform.position - target.transform.position);
    }
}
