using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Plane")
        {
            AudioSource rollingBall = GetComponent<AudioSource>();
            rollingBall.Play();
        }
        Debug.Log(other.gameObject.name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
