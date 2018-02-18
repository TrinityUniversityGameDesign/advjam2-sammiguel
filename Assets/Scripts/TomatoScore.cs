using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class TomatoScore : MonoBehaviour {
    public int requiredScore = 3;
    public Text score;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        if(other.tag == "Enemy")
        {
            score.text = (System.Int32.Parse(score.text) + 1).ToString();
            if(System.Int32.Parse(score.text) >= requiredScore)
            {
                SceneManager.LoadScene("EndScene");
            }
            this.gameObject.SetActive(false);
        }
    }
}
