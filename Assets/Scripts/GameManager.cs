using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{   


    public GameObject ball;
    int score = 0;
    int turnCounter = 0;
    GameObject[] pins;
    public Text scoreUI;

    Vector3[] positions;
    Quaternion[] rotations;

    public HighScore highScore;
	
	public Score scores;
    public Counter counter;

    public GameObject menu;

    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
        positions = new Vector3[pins.Length];
        rotations = new Quaternion[pins.Length];
        for(int i=0; i< pins.Length; i++)
        {
            positions[i] = pins[i].transform.position;
            rotations[i] = pins[i].transform.rotation;
            Debug.Log(positions[i]);
        }
    }

    void Update()
    {

        if(ball.transform.position.y < -10)
        {
            CountPinsDown();
            turnCounter++;
            ResetPins();

            // if(turnCounter == 10)
            // {
                // menu.SetActive(true);
            // }
        }
		
		if (turnCounter >= 10)
        {
            SceneManager.LoadScene(0);
            // menu.SetActive(true);
            for (int i = 0; i < pins.Length; i++)
            {
                pins[i].SetActive(false);
            }
        }

    }


    void CountPinsDown()
    {
        for(int i = 0; i < pins.Length; i++)
        {
            if(pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                score++;
                pins[i].SetActive(false);
            }
        }

        scoreUI.text = score.ToString();
		Debug.Log(turnCounter);
		
		if (turnCounter == 9)
		{
			Debug.Log("SCORE UPDATE");
			if(scores.PlayerScore[9] < score){
				scores.PlayerScore[9] = score;
				counter.counter = counter.counter + 1;
			}
			Array.Sort(scores.PlayerScore);
			Array.Reverse(scores.PlayerScore);
			
		}
		
        if(score > highScore.highScore)
        {
            highScore.highScore = score;
        }

        // Debug.Log(highScore.highScore);

    }

    void ResetPins()
    {
        for(int i = 0; i < pins.Length; i++)
        {
            pins[i].SetActive(true);
            pins[i].transform.position = positions[i];
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pins[i].transform.rotation = rotations[i];
        }

        ball.transform.position = new Vector3(-0.79f, 0.3720f, -6.921522f);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.rotation = Quaternion.identity;

    }

}
