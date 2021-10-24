using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 15f;
    
    private float fbInput;
    private float lrInput;
    
    private Rigidbody _rb;
    
    void Start()
    {
        //You'll need to add a rigidbody to the marble first
//        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxis("Vertical");
        if (vert < 0)
        {
            vert = 0;
        }
        fbInput = vert * moveSpeed;
        lrInput = Input.GetAxis("Horizontal") * rotateSpeed;

        this.transform.Translate(Vector3.forward * fbInput * Time.deltaTime);

        this.transform.Rotate(Vector3.up * lrInput * Time.deltaTime);
    }
    
    void FixedUpdate()
    {
    
        //Put code that moves the sprite using the RigidBody here
    }
    
}
