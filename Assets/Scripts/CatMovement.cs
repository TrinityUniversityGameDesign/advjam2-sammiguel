using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatMovement : MonoBehaviour {

    public Camera cam;
    public float speed = 100;
    public float maxSpeed = 100;
    public float turningSpeed = 60;
    public string axisForward;
    public Animator anim;

    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {

        anim.SetFloat("speed", rb.velocity.magnitude);
        //transform.forward = rb.velocity;


        /*        float horizontal = Input.GetAxis("P1Horizontal") * turningSpeed * Time.deltaTime;
                transform.Rotate(0, horizontal, 0);

                Vector3 vertical = transform.forward * speed * Input.GetAxis("P1Vertical");
                // transform.Translate(0, 0, vertical);
                rb.AddForce(vertical);
                if(rb.velocity.magnitude > maxSpeed)
                {
                    rb.velocity = rb.velocity.normalized * maxSpeed;
                }*/


        Vector3 fwd = cam.transform.forward;
        fwd.y = 0;
        fwd.Normalize();
        Vector3 right = cam.transform.right;
        float horiz = Input.GetAxis("P1Horizontal");
        float vert = Input.GetAxis("P1Vertical");


        Vector3 mVert = new Vector3(horiz, 0, vert);
        Vector3 dir = vert * fwd + horiz * right;
        if (Mathf.Abs(horiz) > 0.01 || Mathf.Abs(vert) > 0.01) { 
            transform.forward = dir.normalized;
        }
        rb.AddForce(transform.forward * speed * mVert.magnitude);


        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }










      //  Debug.Log("vertical = <" + vertical + ">");
       // Debug.Log("plain vertical = <" + Input.GetAxis("P1Vertical") + ">");

    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
