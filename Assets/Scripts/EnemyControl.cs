using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

    // Use this for initialization
    //public float moveSpeed = 5.0f;
    //public float jumpForce = 15.0f;

    private Rigidbody2D rigid;
    private Transform enemyModel;

    private GameObject player = GameObject.FindWithTag("Player");


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update () {
	    //Go to the player. Avoid things.
	}
}
