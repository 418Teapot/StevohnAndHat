using UnityEngine;
using System.Collections;

public class bottleCol : MonoBehaviour {
	private AudioSource bottleSound;


	// Use this for initialization
	void Start () {
		GameObject audio = GameObject.FindGameObjectWithTag("Mechanics");
	
		bottleSound = audio.transform.Find("Sounds/bottles").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collider){
		bottleSound.Play();

	}

}
