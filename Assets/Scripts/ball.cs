using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody rb;
    public float power;
	public GameObject Ball;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
		rb.maxAngularVelocity = 28;
    }

    // Update is called once per frame
    void Update()
    {
		
		// Debug.Log("Ball Script");
        if(Input.GetKeyDown(KeyCode.Return))
        {
			// Debug.Log("Inside If Ball");
            rb.AddForce(Vector3.forward *5000);
			AudioSource source = GetComponent<AudioSource>();
			source.Play();
        }
		
	   if (Ball.transform.position.y < 0.35)
        {
            rb.AddForce(Vector3.forward * power);
        }
    }
}
