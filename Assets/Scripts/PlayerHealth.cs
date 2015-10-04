using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float health = 10.0f;
	public float recoverTime = 0.1f;
	public float damage = 10.0f;

	private float lastHitTime;
	private PlayerControl playerControl;		// Reference to the PlayerControl script.
	private GameObject camera;



	// Use this for initialization
	void Awake () {
		playerControl = GetComponent<PlayerControl>();
		lastHitTime = Time.time;
		Debug.Log("HP: " + health);

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D col){
		if(col.gameObject.tag == "Enemy"){
			if (Time.time > lastHitTime + recoverTime){
				health = health-damage;
				Debug.Log("Damage taken: " + damage + " Health left: " + health );
				if(health > 0f){
					// ... take damage and reset the lastHitTime.
					lastHitTime = Time.time; 
				} else if (health <= 0.0f){
					//die functions first
					GetComponent<PlayerControl>().enabled = false;
					foreach (CircleCollider2D cc in GetComponents<CircleCollider2D>()){
						cc.enabled = false;
					}
					GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;

					//Respawn here, look under; IEnumerator Respawn()
					StartCoroutine(Respawn());


					Debug.Log("dead");
				}
			}
		}	
	}

	IEnumerator Respawn() {
		//print(Time.time);
		yield return new WaitForSeconds(2);
		//print(Time.time);
		GetComponent<PlayerControl>().enabled = true;
		foreach (CircleCollider2D cc in GetComponents<CircleCollider2D>()){
			cc.enabled = true;
		}
		GameObject.FindWithTag("Player").transform.position = new Vector3(0,2,0);
		GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().enabled = true;

	}

}