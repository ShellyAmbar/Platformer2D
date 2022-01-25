using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D collider;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private float dirX = 0f;
    private float dirY = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementsState
    {
        idle,
        running, 
        jumping,
        falling
    }
  
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
       // dirY = Input.GetAxisRaw("Vertical");
        rigidbody.velocity = new Vector2(dirX * moveSpeed, rigidbody.velocity.y);


        if (Input.GetButtonDown("Jump") && isPlayerGrounded())
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
       
        }
        
        
       UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementsState state;
        if (dirX > 0f)
        {
            state = MovementsState.running;
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementsState.running;
            spriteRenderer.flipX = true;
        }
        else
        {
            state = MovementsState.idle;
        }
        if(rigidbody.velocity.y > .1f)
        {
            state = MovementsState.jumping;
        }
        else if (rigidbody.velocity.y < -.1f)
        {
            state = MovementsState.falling;
        }


        animator.SetInteger("state", (int)state);
        
    }

    private bool isPlayerGrounded()
    {
      return  Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    
}
