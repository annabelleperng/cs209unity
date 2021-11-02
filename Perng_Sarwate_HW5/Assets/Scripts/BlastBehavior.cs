using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBehavior : MonoBehaviour
{
    public float onscreenDelay = 3f;

    public GameObject blast;
    public float blastSpeed = 100f;

    // private float _vInput; 
    // private float _hInput;
    // private Rigidbody _rb;
    // private CapsuleCollider _col;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(gameObject, onscreenDelay);
    }

    void FixedUpdate()
    {
        // Vector3 rotation = Vector3.up * _hInput * Time.fixedDeltaTime;
        // Quaternion deltaRotation = Quaternion.Euler(rotation);
        // _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);
        // _rb.MoveRotation(_rb.rotation * deltaRotation);
        // if (Input.GetMouseButtonDown(0))
        // {
        //     GameObject newBlast = Instantiate(blast, this.transform.position, this.transform.rotation) as GameObject;
        //     Rigidbody blastRB = newBlast.GetComponent<Rigidbody>();
        //     blastRB.velocity = this.transform.forward * blastSpeed;
        // }
    }

}
