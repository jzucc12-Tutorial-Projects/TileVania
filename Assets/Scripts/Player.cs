using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Player : MonoBehaviour
{
    //Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(-5f, 5f);
   
    //State
    bool isAlive = true;
    float startGravity;
    
    //Cached components
    Animator myAnimator;
    Rigidbody2D myRigidBody;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        startGravity = myRigidBody.gravityScale;
    }

    void Update()
    {
        if (isAlive)
        {
            Run();
            Jump();
            Climb();
            Die();
        }
    }

    private void Run()
    {
        //Moving
        float running = Input.GetAxis("Horizontal");
        float deltaX = running * runSpeed * Time.deltaTime;
        //Debug.Log(new Vector2(deltaX/Time.deltaTime, 0));
        float newX = deltaX + transform.position.x;
        transform.position = new Vector2(newX, transform.position.y);

        //Flip sprite and animate
        if (running != 0)
        {
            myAnimator.SetBool("isRunning", true);
            transform.localScale = new Vector2(Mathf.Sign(running), transform.localScale.y);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }
    
    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Vector2 addJump = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += addJump;
        }    
    }
    private void Climb()
    {
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myRigidBody.gravityScale = 0;
            Vector2 addJump = new Vector2(0f, Input.GetAxis("Vertical") * climbSpeed);
            myRigidBody.velocity = addJump;
            if(Input.GetButton("Vertical"))
            {
                myAnimator.SetBool("isClimbing", true);
            }
            else
                myAnimator.SetBool("isClimbing", false);

        }
        else
        {
            myRigidBody.gravityScale = startGravity;
            myAnimator.SetBool("isClimbing", false);
        }
    }

    private void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazard")))
        {
            myAnimator.SetTrigger("Die");
            isAlive = false;
            myRigidBody.velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
