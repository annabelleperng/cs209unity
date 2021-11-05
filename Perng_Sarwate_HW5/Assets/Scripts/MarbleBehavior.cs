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

    public GameObject blast;
    public float blastSpeed = 100f;

    public GameBehaviorScript gameManager;

    private Rigidbody _rb;

    void Start()
    {
        //You'll need to add a rigidbody to the marble first
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<SphereCollider>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxis("Vertical");
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

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBlast = Instantiate(blast, this.transform.position, this.transform.rotation) as GameObject;

            Rigidbody blastRB = newBlast.GetComponent<Rigidbody>();
            blastRB.velocity = this.transform.forward * blastSpeed;
            //Destroy(newBlast, 3f);
        }
    }

    IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Goal"))
        {
            gameObject.GetComponent<ParticleSystem>().Play();
            yield return new WaitForSeconds(3);
            gameObject.GetComponent<ParticleSystem>().Stop();
        } else if (collision.gameObject.name.Contains("Obstacle")) {
            gameManager.PlayerHealth -= 25;
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
