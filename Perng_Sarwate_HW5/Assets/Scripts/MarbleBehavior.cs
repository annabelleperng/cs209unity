using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 15f;
    public float jumpVelocity = 5f;

    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    private SphereCollider _col;
    private float fbInput;
    private float lrInput;

    private Rigidbody _rb;

    void Start()
    {
        //You'll need to add a rigidbody to the marble first
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<SphereCollider>();
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

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        // if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }

        this.transform.Translate(Vector3.forward * fbInput * Time.deltaTime);

        this.transform.Rotate(Vector3.up * lrInput * Time.deltaTime);
    }

    void FixedUpdate()
    {

        //Put code that moves the sprite using the RigidBody here
    }

    IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Goal"))
        {
            gameObject.GetComponent<ParticleSystem>().Play();
            yield return new WaitForSeconds(3);
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
    }

    private bool IsGrounded()
    {
        float sphereRadius = _col.radius;
        Vector3 center = _col.center;

        Debug.Log("checking if grounded");
        bool grounded = Physics.CheckSphere(this.transform.position, sphereRadius + distanceToGround, groundLayer,
                                            QueryTriggerInteraction.Ignore);
        Debug.Log("grounded = " + grounded);
        Debug.Log("position = " + this.transform.position);
        Debug.Log("rad = " + sphereRadius);
        Debug.Log("gl = " + groundLayer);
        return grounded;
    }

}
