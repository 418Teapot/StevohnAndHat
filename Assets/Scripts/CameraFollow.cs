using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float distance=15;
    private float yOffset;
    public float yOffsetAtGround=9;
	
	private GameObject player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		Debug.Log("Player found" + player );
	}
	
	// Update is called once per frame
	void Update () {
        yOffset = yOffsetAtGround - player.transform.position.y;
        if (yOffset<0) yOffset = 0;
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y+yOffset, -distance);
	}
}