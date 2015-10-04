using UnityEngine;
using System.Collections;

public class bottleCol : MonoBehaviour {

    private GameObject audioObj;
	// Use this for initialization
	void Start () {
		audioObj = GameObject.FindGameObjectWithTag("Mechanics").transform.Find("Sounds/bottles").gameObject;	
	}

	void OnCollisionEnter2D(Collision2D collider){
        audioObj.GetComponent<TimedAudio>().Play();

	}

}
