using UnityEngine;
using System.Collections;

public class IguanaUserController : MonoBehaviour {
	IguanaCharacter iguanaCharacter;
    public float speed = 10;
    public float maxSpeed = 100;
    public float turningSpeed = 60;
    private Rigidbody rb;
    public Camera cam;
	void Start () {
		iguanaCharacter = GetComponent < IguanaCharacter> ();
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {	
		if (Input.GetButtonDown ("Fire1")) {
			iguanaCharacter.Attack();
		}
		
		if (Input.GetKeyDown (KeyCode.H)) {
			iguanaCharacter.Hit();
		}
		
		if (Input.GetKeyDown (KeyCode.E)) {
			iguanaCharacter.Eat();
		}

		if (Input.GetKeyDown (KeyCode.K)) {
			iguanaCharacter.Death();
		}
		
		if (Input.GetKeyDown (KeyCode.R)) {
			iguanaCharacter.Rebirth();
		}		



	}
	
	private void FixedUpdate()
	{
		float h = Input.GetAxis ("P2Horizontal") * speed;
        float v = Input.GetAxis("P2Vertical") * speed;

    /*    float horizontal = Input.GetAxis("P2Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);

        Vector3 vertical = transform.forward * speed * Input.GetAxis("P2Vertical");
        // transform.Translate(0, 0, vertical);
        rb.AddForce(vertical);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }*/

        Vector3 fwd = cam.transform.forward;
        fwd.y = 0;
        fwd.Normalize();
        Vector3 right = cam.transform.right;
        float horiz = Input.GetAxis("P2Horizontal");
        float vert = Input.GetAxis("P2Vertical");


        Vector3 mVert = new Vector3(horiz, 0, vert);
        Vector3 dir = vert * fwd + horiz * right;
        if (Mathf.Abs(horiz) > 0.01 || Mathf.Abs(vert) > 0.01)
        {
            transform.forward = dir.normalized;
        }
        rb.AddForce(transform.forward * speed * mVert.magnitude);


        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }



        iguanaCharacter.Move (v,h);
	}
}
