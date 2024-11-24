using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerManager pManager;
    public PlayerCombat playerCombat;

    private CameraShake cameraShake;
    public HealthBar healthBar;
    
    public float currentHealth;
    private float stunDuration;

    private GameFreeze gameFreeze;

    void Start()
    {
        currentHealth = pManager.maxHealth;
        cameraShake = GameObject.FindGameObjectWithTag("GameController").GetComponent<CameraShake>();
        gameFreeze = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameFreeze>();
    }

    void Update()
    {
        if (pManager.isHurt)
        {
            stunDuration -= Time.deltaTime; // reduce the stun duration for every frame
            IsStunned(true);
        }

        if (stunDuration <= 0) // stun is over
        {
            pManager.isHurt = false;
            IsStunned(false);
        }
    }

    public void TakeDamage(float damage, float stunDuration)
    {  
        this.stunDuration = stunDuration;
        playerCombat.DisableAllAttacks();

        currentHealth -= damage;
        pManager.isHurt = true;

        gameFreeze.Freeze();
        cameraShake.Shake();
        updateHealBar(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    private void updateHealBar(float currHealth)
    {
        float healthBarVal = (currHealth * 100) / pManager.maxHealth;
        healthBar.SetHealthBar(currHealth, healthBarVal);
    }

    public void HitVoid()
    {
        currentHealth = 0;
        cameraShake.Shake();
        updateHealBar(currentHealth);
        
        Die();
    }

    public void Heal(float healAmount)
    {
        if (currentHealth + healAmount > 100)
        {
            currentHealth = 100;
        }
        else currentHealth += healAmount;

        updateHealBar(currentHealth);
    }

    private void IsStunned(bool stun) // disable player combat and movement
    {
        GetComponent<PlayerCombat>().enabled = !stun;
        GetComponent<PlayerMovement>().enabled = !stun;
    }

    private void Die()
    {
        pManager.isDeath = true;
        FindObjectOfType<GameController>().GameOver(gameObject.name);
    }
}