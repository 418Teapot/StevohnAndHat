using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject character;
    public int timeToSpawn;
    public float spawnTimeout = 20.0f;
    private bool canSpawn = false;
    public int nrToSpawn = 3;
    private int spawned = 0;

    private bool start = true;
	// Use this for initialization
	void Start () {
        canSpawn = true;
	}

    void Update()
    {

        if(transform.childCount == 0 && !start) // hvis 0 har jeg ikke flere "children" og skal derfor spawne nye!
        {
            StartCoroutine(RestartSpawn());                       
        }

        if (canSpawn && spawned < nrToSpawn)
        {
            GameObject instantiated = (GameObject)Instantiate(character, transform.position, transform.rotation);
            instantiated.GetComponent<EnemyControl>().myMinHeight = transform.position.y;
            instantiated.transform.parent = transform;
            spawned++;
            start = true;
            StartCoroutine(SpawnCharacters());
        }
        
    }

    IEnumerator RestartSpawn()
    {
        yield return new WaitForSeconds(spawnTimeout);
        canSpawn = true;
        spawned = 0;
        StopAllCoroutines();
    }


    IEnumerator SpawnCharacters()
    {
        canSpawn = false;
        yield return new WaitForSeconds(timeToSpawn);
        canSpawn = true;
        StopAllCoroutines();
    }
}
