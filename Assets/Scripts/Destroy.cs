using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    public int lifeTime = 5;

	// Update is called once per frame
	void FixedUpdate () {
        Destroy(this.gameObject, lifeTime);   
	}
}
