using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HatControl : MonoBehaviour {

    public GameObject hat;
    public Transform muzzlePoint;
    public GameObject realHat;

    public GameObject hatParticles;

    public float force = 2500.0f;
    public float lifeTime = 5.0f;
    private bool hasHat = true;

    private bool madeItBig = false;

    public void EnableHat()
    {
        hasHat = true;
        GameObject particlesHat = (GameObject) Instantiate(hatParticles, muzzlePoint.position, muzzlePoint.rotation);        
        realHat.GetComponent<SpriteRenderer>().enabled = true;
        Destroy(particlesHat, 5); // clean up ;)
    }
    
	void FixedUpdate () {

        if(Input.GetButtonDown("Fire1") && hasHat)
        {
            Debug.Log("FIRE!");
            hasHat = false;            
            if(realHat == null)
            {
                Debug.Log("NO HAT!");
            } else
            {
                Debug.Log(realHat);//realHat.active = false;
                realHat.GetComponent<SpriteRenderer>().enabled = false;
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

            StartCoroutine(AutoDestroy(instantiatedHat));
        }
        
    }

    IEnumerator AutoDestroy(GameObject hat)
    {
        yield return new WaitForSeconds(lifeTime);
        if (!madeItBig) {
            EnableHat();
            Destroy(hat);
        }
    }
}
