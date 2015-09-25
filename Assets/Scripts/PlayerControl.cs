using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float moveSpeed = 5.0f;

	private Rigidbody2D rigid;
	private Animator anim;
	private Transform playerModel;

	void Start(){
		rigid = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		playerModel = transform.Find("PlayerModel");
	}

	void FixedUpdate(){
		float horizontalMove = Input.GetAxis("Horizontal");

		if(horizontalMove > 0){
			Vector3 scale = playerModel.transform.localScale;
			scale.x *= 1;
			playerModel.transform.localScale = scale;
		} else {
			Vector3 scale = playerModel.transform.localScale;
			scale.x *= -1;
			playerModel.transform.localScale = scale;
		}

		anim.SetFloat("WalkSpeed", Mathf.Abs(horizontalMove));

		rigid.velocity = new Vector2(horizontalMove * moveSpeed, rigid.velocity.y);	
	}



}