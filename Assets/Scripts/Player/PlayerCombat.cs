using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerManager pManager;
    [Space(5)]
    [Header("Combo")]
    public GameObject combo1;
    public GameObject combo2;
    public GameObject combo3;

    [Space(5)]
    [Header("Skills")]
    public GameObject attack1;
    public GameObject attack2;

    [Space(10)]
    [Header("Special Skills")]
    public GameObject dash;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float comboTime;
    private int currentCombo = 0;

    void Start()
    {
        comboTime = pManager.comboTransitionTime;
    }

    void Update()
    {
        // reset currentCombo to the 1st one when timer runs out
        if (comboTime <= 0) currentCombo = 0;

        // during a combo -> countdown the timer
        if (currentCombo > 0) comboTime -= 1 * Time.deltaTime;

        if (!pManager.combo[0] && !pManager.combo[1] && !pManager.combo[2] && !pManager.isAttacking1 && !pManager.isAttacking2 && !pManager.isShooting && !pManager.isDashing)
        {
            if (Input.GetKeyDown(pManager.comboKeyCode) && pManager.isGrounded)
            {
                // for the 1st combo, there is no time constraint
                // for the 2nd and 3rd, the timer must > 0 to initiate another one
                if (currentCombo == 0 || (currentCombo > 0 && currentCombo < 3 && comboTime > 0))
                {
                    pManager.combo[currentCombo] = true;
                    currentCombo++;
                    comboTime = pManager.comboTransitionTime;
                }
            }

            if (Input.GetKeyDown(pManager.attack1KeyCode))
            {
                pManager.isAttacking1 = true;
            }
            if (Input.GetKeyDown(pManager.attack2KeyCode))
            {
                pManager.isAttacking2 = true;
            }

            if (Input.GetKeyDown(pManager.dashKeyCode))
            {
                pManager.isDashing = true;
            }
            if (Input.GetKeyDown(pManager.shootKeyCode))
            {
                pManager.isShooting = true;
            }
        }
    }

    public void DisableAllAttacks()
    {
        EndCombo1HitBox();
        EndCombo1Animation();

        EndCombo2HitBox();
        EndCombo2Animation();

        EndCombo3HitBox();
        EndCombo3Animation();

        EndAttack1HitBox();
        EndAttack1Animation();

        EndAttack2HitBox();
        EndAttack2Animation();

        EndDashingHitBox();
        EndDashingAnimation();

        EndShooting();
    }

    // Hitbox and Animations
    public void StartCombo1HitBox()
    {
        if (combo1 != null) combo1.SetActive(true);
    }
    public void EndCombo1HitBox()
    {
        if (combo1 != null) combo1.SetActive(false);
    }
    public void EndCombo1Animation()
    {
        pManager.combo[0] = false;
    }

    public void StartCombo2HitBox()
    {
        if (combo2 != null) combo2.SetActive(true);
    }
    public void EndCombo2HitBox()
    {
        if (combo2 != null) combo2.SetActive(false);
    }
    public void EndCombo2Animation()
    {
        pManager.combo[1] = false;
    }

    public void StartCombo3HitBox()
    {
        if (combo3 != null) combo3.SetActive(true);
    }
    public void EndCombo3HitBox()
    {
        if (combo3 != null) combo3.SetActive(false);
    }
    public void EndCombo3Animation()
    {
        pManager.combo[2] = false;
    }

    public void StartAttack1HitBox()
    {
        if (attack1 != null) attack1.SetActive(true);
    }
    public void EndAttack1HitBox()
    {
        if (attack1 != null) attack1.SetActive(false);
    }
    public void EndAttack1Animation()
    {
        pManager.isAttacking1 = false;
    }

    public void StartAttack2HitBox()
    {
        if (attack2 != null) attack2.SetActive(true);
    }
    public void EndAttack2HitBox()
    {
        if (attack2 != null) attack2.SetActive(false);
    }
    public void EndAttack2Animation()
    {
        pManager.isAttacking2 = false;
    }

    public void StartDashingHitBox()
    {
        if (dash != null) dash.SetActive(true);
    }
    public void EndDashingHitBox()
    {
        if (dash != null) dash.SetActive(false);
    }
    public void EndDashingAnimation()
    {
        pManager.isDashing = false;
    }

    public void StartShooting()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    public void EndShooting()
    {
        pManager.isShooting = false;
    }
}