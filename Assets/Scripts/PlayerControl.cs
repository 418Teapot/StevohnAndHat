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

    private WiiMoteInputReader wiiInput;


    private bool facingLeft = false;
    private bool facingRight = true;

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

        float horizontalMove;

        if (wiimoteEnabled){
            horizontalMove = wiiInput.getX();
            anim.SetFloat("WalkSpeed", Mathf.Abs(horizontalMove));

          	if(wiiInput.getJump() > 0 && grounded)
			{
                rigid.AddForce(Vector2.up * jumpForce);
                Debug.Log("Jump "+jumpCount);
            }

        } else {
			//If wiiMote isn't enabled, and you want to controle with keyboard.
            horizontalMove = Input.GetAxis("Horizontal");
            anim.SetFloat("WalkSpeed", Mathf.Abs(horizontalMove));

			if(Input.GetButtonDown("Jump") && grounded){
				rigid.AddForce(Vector2.up * jumpForce);
				Debug.Log("Jump "+jumpCount);
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
		

		rigid.velocity = new Vector2(horizontalMove * moveSpeed, rigid.velocity.y);	
	}

<<<<<<< HEAD
=======
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

>>>>>>> hatman
	void OnCollisionEnter2D(Collision2D collider){
		grounded = true;
	}

	void OnCollisionExit2D(Collision2D collider){
		grounded = false;
	}



}