using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yarnBoost : MonoBehaviour {
    public GameObject iguanapos;
    public GameObject pointer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pointer.transform.LookAt(new Vector3(iguanapos.transform.position.x,pointer.transform.position.y,iguanapos.transform.position.z));
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            
        }
    }
}
