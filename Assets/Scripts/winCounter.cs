using UnityEngine;
using System.Collections;

public class winCounter : MonoBehaviour {
	private int tableCounter = 0;

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Table"){
			tableCounter ++;
			Debug.Log ("Tables: " + tableCounter);
		}

	}

	public int Tables(){
		return tableCounter;
	}
}
