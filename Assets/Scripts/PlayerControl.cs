using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float moveSpeed = 7.0f;
    public float jumpForce = 500.0f;

	private Rigidbody2D rigid;
	private Animator anim;
	private Transform playerModel;
    public bool wiimoteEnabled = false;
    private int jumpCount = 0;
	private bool grounded = true;
    private bool groundL = true;
    private bool groundR = true;

    private WiiMoteInputReader wiiInput;


    private bool facingLeft = false;
    private bool facingRight = true;
    private bool dancing = false;

	void Start(){
		rigid = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        
        wiiInput = GameObject.FindWithTag("Mechanics").GetComponentInChildren<WiiMoteInputReader>();
    }

    void flip()
    {
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;
    }

	void FixedUpdate(){
        grounded = Physics2D.Linecast(transform.position, transform.Find("groundCheck").transform.position, 1 << LayerMask.NameToLayer("Ground"));
        groundR = Physics2D.Linecast(transform.position, transform.Find("groundCheckR").transform.position, 1 << LayerMask.NameToLayer("Ground"));
        groundL = Physics2D.Linecast(transform.position, transform.Find("groundCheckL").transform.position, 1 << LayerMask.NameToLayer("Ground"));

        //Debug.Log("Grnd: " + grounded);
        float horizontalMove;

        if (wiimoteEnabled){
            horizontalMove = wiiInput.getX();
            anim.SetFloat("WalkSpeed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                if (grounded || groundR || groundL) //stupid hax/fix fordi vores ting er skod - eller noget!
                {
                    rigid.AddForce(Vector2.up * jumpForce);
                    Debug.Log("Jump " + jumpCount);
                }
            }

            if (horizontalMove == 0 && Input.GetButton("Dance"))
            {
                dancing = true;
                anim.SetBool("Dancing", dancing);
            }
            else
            {
                dancing = false;
                anim.SetBool("Dancing", dancing);
            }


        } else {
			//If wiiMote isn't enabled, and you want to controle with keyboard.
            horizontalMove = Input.GetAxis("Horizontal");
            anim.SetFloat("WalkSpeed", Mathf.Abs(horizontalMove));

			if(Input.GetButtonDown("Jump")){
                if (grounded || groundR || groundL) //stupid hax/fix fordi vores ting er skod - eller noget!
                {
                    rigid.AddForce(Vector2.up * jumpForce);
                    Debug.Log("Jump " + jumpCount);
                }
			}

            if (horizontalMove == 0 && Input.GetButton("Dance"))
            {
                dancing = true;
                anim.SetBool("Dancing", dancing);
            }
            else
            {
                dancing = false;
                anim.SetBool("Dancing", dancing);
            }

        }

        if(horizontalMove < 0 && !facingLeft){
            flip();
            facingLeft = true;
            facingRight = false;
        } else if(horizontalMove > 0 && !facingRight){
            flip();
            facingRight = true;
            facingLeft = false;
        }

       

        /*if(horizontalMove > 0){
			Vector3 scale = transform.localScale;
			scale.x *= 1;
			transform.localScale = scale;
		} else {
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}*/

        Debug.Log("Grnd: " + grounded);
		rigid.velocity = new Vector2(horizontalMove * moveSpeed, rigid.velocity.y);	
	}

    public bool IsFacingRight()
    {
        if (facingRight)
        {
            return true;
        } else
        {
            return false;
        }
    }
    /*
	void OnTriggerEnter2D(Collider2D collider){
        //if (collider.tag == "Ground" || collider.tag == "Hat" || collider.tag == "Chair" || collider.tag == "Table")        
            grounded = true;
        
	}

	void OnTriggerExit2D(Collider2D collider){
		grounded = false;
	}*/




}