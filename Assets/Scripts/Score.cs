using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public float score = 0.0f;					// The player's 
	public float highScore = 0.0f;				// Haaaaands
	
	
	private PlayerControl playerControl;	// Reference to the player control script.	


	void Awake ()
	{
		// Setting up the reference.
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
	}
	
	
	void Update ()
	{
		// Score ++ for each second alive
		score = Time.time;

		// TO DO  reset score each time the player dies
		if(highScore < score ) highScore = score;


		// Set the score text.
//		GetComponent<GUIText>().BroadcastMessage = "Score: " + score;
//		GetComponent<GUIText>().BroadcastMessage = "High Score: " + highScore;

	}
	
}