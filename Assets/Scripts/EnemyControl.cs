using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

    // Use this for initialization
    //public float moveSpeed = 5.0f;
    //public float jumpForce = 15.0f;

    private Rigidbody2D rigid;
    private Transform enemyModel;

    private GameObject player;
    private Rigidbody2D playerRigid;
    private Vector2 towardsPlayer;
    


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
        Debug.Log("enemy loaded:" + rigid);
        Debug.Log("player is at:" + playerRigid.transform.position);
        Debug.Log("enemy is at:" + rigid.transform.position);

    }

    // Update is called once per frame
    void FixedUpdate() {
        towardsPlayer = playerRigid.position - rigid.position;
        Debug.Log("2D vector towards player: " + towardsPlayer);
        //Go to the player. Avoid things.
    }
}
