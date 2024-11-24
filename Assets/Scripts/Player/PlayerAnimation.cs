using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public PlayerManager pManager;
    public PlayerCombat playerCombat;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private GameFreeze gameFreeze;
    private CameraShake cameraShake;

    private string currentState;

    //animation states
    string ANIMATION_IDLE = "Idle";
    string ANIMATION_WALK = "Walk";
    string ANIMATION_JUMP = "Jump";
    string ANIMATION_FALL = "Fall";
    string ANIMATION_HURT = "Hurt";
    string ANIMATION_DIE = "Die";
    string ANIMATION_COMBO1 = "Combo1";
    string ANIMATION_COMBO2 = "Combo2";
    string ANIMATION_COMBO3 = "Combo3";
    string ANIMATION_ATTACK1 = "Attack1";
    string ANIMATION_ATTACK2 = "Attack2";
    string ANIMATION_DASH = "Dash";
    string ANIMATION_SHOOT = "Shoot";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        if (pManager.defaultFacingLeft) Flip();
    }

    private void Update()
    {
        PlayAnimations();
    }

    private void ChangeAnimationState(string newState)
    {
        if (newState == currentState) return;

        animator.Play(newState);
        currentState = newState;
    }

    private void PlayAnimations()
    {
        if (pManager.isDeath)
        {
            ChangeAnimationState(ANIMATION_DIE);
            boxCollider.enabled = false;
            return;
        }

        if (pManager.isHurt)
        {
            ChangeAnimationState(ANIMATION_HURT);
            StartCoroutine(Flashing());
            spriteRenderer.sortingOrder = 0; // make attacking character's skills more visible
            return;
        }
        else
        {
            spriteRenderer.sortingOrder = 1;
        }

        if (pManager.combo[0])
        {
            ChangeAnimationState(ANIMATION_COMBO1);
            return;
        }

        if (pManager.combo[1])
        {
            ChangeAnimationState(ANIMATION_COMBO2);
            return;
        }

        if (pManager.combo[2])
        {
            ChangeAnimationState(ANIMATION_COMBO3);
            return;
        }


        if (pManager.isAttacking1)
        {
            ChangeAnimationState(ANIMATION_ATTACK1);
            return;
        }

        if (pManager.isAttacking2)
        {
            ChangeAnimationState(ANIMATION_ATTACK2);
            return;
        }

        if (pManager.isShooting)
        {
            ChangeAnimationState(ANIMATION_SHOOT);
            return;
        }

        if (pManager.isDashing)
        {
            ChangeAnimationState(ANIMATION_DASH);
            playerCombat.enabled = false;

            return;
        }
        else playerCombat.enabled = true;

        if (pManager.isGrounded) // horizontal movement animations
        {
            if (pManager.movementX == 0f) ChangeAnimationState(ANIMATION_IDLE);
            else ChangeAnimationState(ANIMATION_WALK);
        }
        else // vertical movement animations
        {
            if (pManager.velocityY > 0.1f) ChangeAnimationState(ANIMATION_JUMP);
            else if (pManager.velocityY < -0.1f) ChangeAnimationState(ANIMATION_FALL);
        }

        // flip the character to the way he is facing
        if (pManager.movementX == 1 && !pManager.isFacingRight) Flip();
        else if (pManager.movementX == -1 && pManager.isFacingRight) Flip();
    }
    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        pManager.isFacingRight = !pManager.isFacingRight;
    }

    private IEnumerator Flashing()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}