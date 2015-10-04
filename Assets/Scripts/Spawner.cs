using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject character;
    public int timeToSpawn;
    private bool canSpawn = true;
	// Use this for initialization
	void Start () {
        
	}

    void Update()
    {
        if (canSpawn)
        {
            GameObject instantiated = (GameObject)Instantiate(character, transform.position, transform.rotation);
            instantiated.GetComponent<EnemyControl>().myMinHeight = transform.position.y;
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
