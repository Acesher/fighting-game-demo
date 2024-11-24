using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coconut : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public GameObject hitEffect;
    public AudioClip hitSound;
    public float hitSoundVolume = 1f;

    public int hitDamage;
    public float stunDuration;
    public float speed = 0f;

    private float damageBoost;

    void Start()
    {
        rigidBody.velocity = transform.right * speed;
        damageBoost = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerManager>().damageBoostMultiplier;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.layer == 7) // player layer
        {
            otherCollider.GetComponent<PlayerHealth>().TakeDamage(hitDamage * damageBoost, stunDuration);

            // hit sound: use PlayClipAtPoint since we are deactivating the script on the next line (if use .Play() it will be disable so can't play the sound)
            AudioSource.PlayClipAtPoint(hitSound, new Vector3(0, 0, 0), hitSoundVolume);
        }

        Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}