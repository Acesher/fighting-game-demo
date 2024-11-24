using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public int attackDamage;
    public float stunDuration;
    public float knockUpForce = 0f;
    public float knockBackForce = 0f;
    public string playerTag;

    public GameObject hitEffect;
    public AudioClip hitSound;
    public float hitSoundVolume = 1f;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == playerTag)
        {
            float knockBackValue = knockBackForce;

            // determine the knockback direction (left or right)
            if (!transform.parent.GetComponent<PlayerManager>().isFacingRight)
            {
                knockBackValue = -knockBackValue;
            }

            // apply damage
            float damageBoost = transform.parent.GetComponent<PlayerManager>().damageBoostMultiplier;
            otherCollider.GetComponent<PlayerHealth>().TakeDamage(attackDamage * damageBoost, stunDuration);

            // apply knockback/knockup
            otherCollider.GetComponent<PlayerMovement>().addForce(new Vector2(knockBackValue, knockUpForce));

            // hit effect
            Vector3 hitPos = otherCollider.transform.position;
            hitPos.y += 0.45f; // offset for accurate position

            Instantiate(hitEffect, hitPos, otherCollider.transform.rotation);

            // hit sound: use PlayClipAtPoint since we are deactivating the script on the next line (if use .Play() it will be disable so can't play the sound)
            AudioSource.PlayClipAtPoint(hitSound, new Vector3(0, 0, 0), hitSoundVolume);

            // after hit, deactivate the collider to prevent hitting twice in some situations
            gameObject.SetActive(false);
            //GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}