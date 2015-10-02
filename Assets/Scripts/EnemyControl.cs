using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour
{

    // Use this for initialization
    public float patrolSpeed = 5.0f;
    public float chaseSpeed = 8.0f;
    public float spottingDistance = 10f;
    public float patrolDistanceX = 25f;

    
    private Rigidbody2D rigid;
    private Transform enemyModel;
    private Vector2 startingSize;

    private GameObject player;
    private Animator anim;
    private Rigidbody2D playerRigid;
    private Vector2 vectorTowardsPlayer;
    private Vector2 mySpawnPoint;

    private Renderer patrolEyes;
    private Renderer chaseEyes;

    void Start()
    {
        patrolEyes = transform.Find("enemyEyesPatrol").GetComponent<Renderer>();
        chaseEyes = transform.Find("enemyEyesChase").GetComponent<Renderer>();

        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemyModel = GetComponent<Transform>();
        
        player = GameObject.FindWithTag("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();

        mySpawnPoint = rigid.transform.position;
        startingSize = enemyModel.localScale;

        Debug.Log("player is at:" + playerRigid.transform.position);
        Debug.Log("enemy spawned at:" + mySpawnPoint);

        rigid.velocity = new Vector2(patrolSpeed, rigid.velocity.y); //start by going right... randomize?
    }

    void Patrol()
    {
        patrolEyes.enabled = true;
        chaseEyes.enabled = false;

        anim.speed = 1;
        if (rigid.transform.position.x > mySpawnPoint.x + patrolDistanceX / 2) rigid.velocity = new Vector2(-patrolSpeed, rigid.velocity.y); //go left at edge of patrol area
        else if (rigid.transform.position.x < mySpawnPoint.x - patrolDistanceX / 2) rigid.velocity = new Vector2(patrolSpeed, rigid.velocity.y); //go right at edge of patrol area
    }

    void Chase()
    {
        patrolEyes.enabled = false;
        chaseEyes.enabled = true;
        anim.speed = 3;
        rigid.velocity = vectorTowardsPlayer.normalized * chaseSpeed; //move towards player
    }

    
    void FixedUpdate()
    {

        vectorTowardsPlayer = playerRigid.position - rigid.position;

        if (vectorTowardsPlayer.magnitude > spottingDistance) Patrol(); //gravity seems okay.
        else Chase();

        //grow big and mean when catching player: ... Useless? probably...
        if (vectorTowardsPlayer.magnitude < 0.5f) enemyModel.localScale = startingSize * 3;//, rigid.transform.lossyScale.y * 5);
        //else if (vectorTowardsPlayer.magnitude > 5) startingSize = enemyModel.localScale;

        //face direction of movement:
        if (rigid.velocity.x > 0) transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        else transform.localScale = new Vector2(-1*Mathf.Abs(transform.localScale.x), transform.localScale.y);


        if (rigid.transform.position.y < -0.8f) //keep above ground
        {
            rigid.transform.position = new Vector2(rigid.transform.position.x, -0.7f);
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
        }

        //Debug.Log("Enemy velocity: " + rigid.velocity);
        //Debug.Log("2D vector towards player: " + vectorTowardsPlayer);
    }
}