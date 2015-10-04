using UnityEngine;
using System.Collections;

public class Mechanics : MonoBehaviour {
	private int numberOfTables = 0;
	public GameObject winZone;

	// Use this for initialization
	void Start () {
		numberOfTables = GameObject.FindGameObjectsWithTag("Table").Length;
		Debug.Log ("Tables" + numberOfTables);
	}
	
	// Update is called once per frame
	void Update () {
		if(numberOfTables <= winZone.GetComponent<winCounter>().Tables()){
			Debug.Log("you haz won");
			Time.timeScale = 0f;
		}
	}
}
