using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float distance = 15.0f;
	
	private GameObject player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		Debug.Log("Player found" + player );
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -distance);
	}
}