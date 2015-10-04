using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HatControl : MonoBehaviour {

    public GameObject hat;
    public Transform muzzlePoint;
    public float force = 100.0f;
    
	void FixedUpdate () {

        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("FIRE!");
            GameObject instantiatedHat = (GameObject) Instantiate(hat, muzzlePoint.position, muzzlePoint.rotation);
            Rigidbody2D hatBody = instantiatedHat.GetComponent<Rigidbody2D>();
            hatBody.AddForce(Vector2.right*force, ForceMode2D.Force);
        }
        
    }
}
