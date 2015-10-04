using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HatControl : MonoBehaviour {

    public GameObject hat;
    public GameObject bigHat;

    public Transform muzzlePoint;
    public GameObject realHat;

    public GameObject bigHatParicles;

    public GameObject hatParticles;
    
    public float force = 2500.0f;
    public float lifeTime = 5.0f;
    public float largeHatTime = 10.0f;
    private bool hasHat = true;

    private bool madeItBig = false;
    private GameObject instantiatedHat;
    private GameObject superHat;
    // ny wait for thing yes!
    private float __gWaitSystem;

    void TappedWaitForSecondsOrTap()
    {
        __gWaitSystem = 0.0f;
    }

    IEnumerator WaitForSecondsOrTap(float seconds)
    {
        __gWaitSystem = seconds;
        while( __gWaitSystem > 0.0f)
        {
            __gWaitSystem -= Time.deltaTime;
            yield return null;
        }
    }

    public void EnableHat()
    {
        hasHat = true;
        madeItBig = false;
        GameObject particlesHat = (GameObject) Instantiate(hatParticles, muzzlePoint.position, muzzlePoint.rotation);        
        realHat.GetComponent<SpriteRenderer>().enabled = true;
        Destroy(particlesHat, 5); // clean up ;)
    }

    void FixedUpdate()
    {

        if (Input.GetButtonDown("Fire1") && hasHat)
        {
            hasHat = false;
            Debug.Log("FIRE!");            
            if (realHat == null)
            {
                Debug.Log("NO HAT!");
            }
            else
            {
                Debug.Log(realHat);//realHat.active = false;
                realHat.GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("AudioClips/Throw").GetComponent<AudioSource>().Play();
            }
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = transform.position.z - Camera.main.transform.position.z;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, mousePos - transform.position);
            instantiatedHat = (GameObject)Instantiate(hat, muzzlePoint.position, rotation);
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
        } else if (Input.GetButtonDown("Fire1") && !hasHat && !madeItBig)
        {
            Debug.Log("ENLARGE ME!");
            GameObject.Find("AudioClips/Poof").GetComponent<AudioSource>().Play();
            GameObject bigHatParticleSys = (GameObject) Instantiate(bigHatParicles, instantiatedHat.transform.position, instantiatedHat.transform.rotation);
            Destroy(bigHatParticleSys, 5);
            superHat = (GameObject) Instantiate(bigHat, instantiatedHat.transform.position, instantiatedHat.transform.rotation);
            Destroy(instantiatedHat);
            madeItBig = true;
            //StopCoroutine(AutoDestroy());
        }
    }

    public void KillTheHat()
    {
        StopAllCoroutines();
        EnableHat();
        GameObject.Find("AudioClips/Poof").GetComponent<AudioSource>().Play();
    }

    IEnumerator AutoDestroyLarge()
    {
        yield return new WaitForSeconds(largeHatTime);        
        EnableHat();
        Destroy(superHat);
        GameObject.Find("AudioClips/Poof").GetComponent<AudioSource>().Play();
    }

    IEnumerator AutoDestroy(GameObject hat)
    {
        yield return new WaitForSeconds(lifeTime);
        if (!madeItBig) {
            EnableHat();
            Destroy(hat);
            GameObject.Find("AudioClips/Poof").GetComponent<AudioSource>().Play();
        } else
        {
            StartCoroutine(AutoDestroyLarge());
        }
    }
}
