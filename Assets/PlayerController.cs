using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public SwordAttack swordAttack;
    bool canMove = true;
    SpriteRenderer spriteRenderer;
    Vector2 movementInput;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.02f;
    
    public ContactFilter2D movementFilter;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    Animator animator;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(canMove){
            if(movementInput != Vector2.zero)//If there is a movement input, try to move the player
            {
                bool success = TryToMove(movementInput);

                if(!success)
                {
                    success = TryToMove(new Vector2(movementInput.x, 0));

                    if(!success)
                    {
                        print("Move");
                        success = TryToMove(new Vector2(0, movementInput.y));
                    }
                }
                animator.SetBool("IsMoving", success);
            }
            else{
                animator.SetBool("IsMoving", false);
            }

            //Set the direction of the sprite
            if(movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if(movementInput.x > 0){
                spriteRenderer.flipX = false;
            }
        }
    }

    private bool TryToMove(Vector2 direction)
    {
        if(direction != Vector2.zero)//if the player move in a good direction
        {
            //Cast to see if the movement is valid. If there is nothing on the way who block the player, count = 0
            int count = rb.Cast(direction,movementFilter,castCollisions,moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if(count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else{
                return false;
            }
        }
        else{// the player can't move so stop the moving animation and stay idle
            return false;
        }
        
    }
    

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire(){
        animator.SetTrigger("AttackSword");
    }

    public void Swing()
    {
        LockMovement();
        if(spriteRenderer.flipX == true)
        {
        swordAttack.AttackLeft();
        }
        else{
        swordAttack.AttackRight();
        }
    }

    public void EndAttack()
    {
        UnlockMovement();
        swordAttack.StopAttack();
    }

    void LockMovement()
    {
        canMove =false;
    }
    void UnlockMovement()
    {
        canMove = true;
    }
}
