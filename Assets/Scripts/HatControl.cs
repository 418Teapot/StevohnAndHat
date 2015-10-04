using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HatControl : MonoBehaviour {

    public GameObject hat;
    public Transform muzzlePoint;
    public float force = 2500.0f;

    private bool hasHat = true;
    
	void FixedUpdate () {

        if(Input.GetButtonDown("Fire1") && hasHat)
        {
            Debug.Log("FIRE!");
            hasHat = false;
            GameObject realHat = GameObject.FindWithTag("Hat");
            if(realHat == null)
            {
                Debug.Log("NO HAT!");
            } else
            {
                Debug.Log(realHat);//realHat.active = false;
            }
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = transform.position.z - Camera.main.transform.position.z;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, mousePos - transform.position);
            GameObject instantiatedHat = (GameObject) Instantiate(hat, muzzlePoint.position, rotation);
            Rigidbody2D hatBody = instantiatedHat.GetComponent<Rigidbody2D>();

            //hatBody.AddForce(instantiatedHat.transform.up * force);
            hatBody.AddRelativeForce(Vector3.up * force);
            /*
                        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().IsFacingRight())
                        {
                            hatBody.AddForce(Vector2.right * force, ForceMode2D.Force);
                        } else
                        {
                            hatBody.AddForce(Vector2.left * force, ForceMode2D.Force);
                        }*/

            
        }
        
    }
}
