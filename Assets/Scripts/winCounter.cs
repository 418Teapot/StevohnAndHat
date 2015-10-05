using UnityEngine;
using System.Collections;

public class winCounter : MonoBehaviour {
	private int tableCounter = 0; 

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Table"){
			tableCounter ++;
            GameObject.FindWithTag("Mechanics").GetComponent<Mechanics>().SetScore(10); // 10 points pr bord!
			Debug.Log ("Tables: " + tableCounter);
		}

	}

	public int Tables(){
		return tableCounter;
	}
}
