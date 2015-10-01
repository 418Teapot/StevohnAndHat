using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public float health = 10.0f;
	public float recoverTime = 0.1f;
	public float damage = 10.0f;

	private float lastHitTime;



	// Use this for initialization
	void Start () {
		lastHitTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col){
		if(col.gameObject.tag == "Enemy"){
			if (Time.time > lastHitTime + recoverTime){
				health = health-damage;

				if(health > 0f){
					// ... take damage and reset the lastHitTime.
					lastHitTime = Time.time; 
				} //else {
					//die
				//}
			}
		}	
	}
}