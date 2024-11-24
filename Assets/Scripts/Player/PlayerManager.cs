using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Inputs")]
    public KeyCode RightKeyCode;
    public KeyCode LeftKeyCode;
    public KeyCode JumpKeyCode;
    public KeyCode comboKeyCode;
    public KeyCode attack1KeyCode;
    public KeyCode attack2KeyCode;
    public KeyCode dashKeyCode;
    public KeyCode shootKeyCode;

    [Header("Attributes")]
    public float dashForce = 0f;
    public float moveForce = 6f;
    public float jumpForce = 10f;
    public float maxHealth = 100f;
    public float damageBoostMultiplier = 1;
    public int extraJumps = 1;

    [Header("Animations")]
    public float movementX;
    public float velocityY;
    public bool isGrounded, isHurt, isDeath;
    public bool defaultFacingLeft;
    public bool isFacingRight = true;

    public bool[] combo;
    public float comboTransitionTime = 1f;
    public bool isAttacking1, isAttacking2;
    public bool isDashing, isShooting;

    private void Start()
    {
        combo = new bool[3];
    }
}
