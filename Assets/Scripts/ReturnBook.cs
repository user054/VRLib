using UnityEngine;

public class ReturnBook : MonoBehaviour
{
    Vector3 curTransformposition;
    Vector3 curTransformrotation;
    Rigidbody rb;

    private void Start()
    {
        curTransformposition = transform.position;
        curTransformrotation = transform.eulerAngles;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        print(curTransformposition);
        print(transform.position);
    }
    
    public void REturnBook()
    {
        transform.position = curTransformposition;
        transform.eulerAngles = curTransformrotation;
        rb.velocity = Vector3.zero;
    }
}
