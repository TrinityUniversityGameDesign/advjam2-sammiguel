using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    /*
        public GameObject target;
        private Vector3 offsetFromTarget;
        // Use this for initialization
        void Start()
        {
            offsetFromTarget = target.transform.position - transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = target.transform.position - offsetFromTarget;
        }*/
    public string camAxis;
    public GameObject target;
    public float turningSpeed = 30;
    public float damping = 1;
    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }
   /* private void Update()
    {
        float cameraHoriz = Input.GetAxis("CatCameraHoriz") * turningSpeed;
        Debug.Log("cameraHoriz = < " + cameraHoriz + ">");
        rb.velocity = new Vector3(cameraHoriz, 0, 0);
    }*/
    void LateUpdate()
    {
        /* float currentAngle = transform.eulerAngles.y;
         float desiredAngle = target.transform.eulerAngles.y;
         float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

         Quaternion rotation = Quaternion.Euler(0, angle, 0);
     */
        Debug.Log("InitY: " + transform.position.y);
        if (Input.GetButtonDown(camAxis))
        {
            Vector3 xzOffeset = offset;
            xzOffeset.y = 0;
            float dist = xzOffeset.magnitude;
            float camY = transform.position.y;
            Debug.Log("StoreY: " + camY);
            Vector3 camPos = target.transform.position - dist * target.transform.forward;
            transform.position = new Vector3(camPos.x, camY,camPos.z);
            Debug.Log("PostY: " + camY);
            offset = target.transform.position - transform.position;
        } 
        transform.position = target.transform.position - (offset);
        
        transform.LookAt(target.transform);
    }
}
