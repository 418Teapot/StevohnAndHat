using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject character;
    public int timeToSpawn;
    private bool canSpawn = false;
    public int nrToSpawn = 3;
    private int spawned = 0;
	// Use this for initialization
	void Start () {
        
	}

    void Update()
    {

        if(transform.childCount == 0) // hvis 0 har jeg ikke flere "children" og skal derfor spawne nye!
        {
            canSpawn = true;
            spawned = 0;
        }

        if (canSpawn && spawned < nrToSpawn)
        {
            GameObject instantiated = (GameObject)Instantiate(character, transform.position, transform.rotation);
            instantiated.GetComponent<EnemyControl>().myMinHeight = transform.position.y;
            instantiated.transform.parent = transform;
            spawned++;
            StartCoroutine(SpawnCharacters());
        }
        
    }


    IEnumerator SpawnCharacters()
    {
        canSpawn = false;
        yield return new WaitForSeconds(timeToSpawn);
        canSpawn = true;
        StopAllCoroutines();
    }
}
