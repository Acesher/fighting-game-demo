using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoost : MonoBehaviour
{
    //public GameObject collectEffect;
    public AudioClip collectSound;
    public int boostMultiplier;
    public float boostTimeSeconds;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.layer == 7) // player layer
        {
            otherCollider.GetComponent<PlayerPowerUp>().ApplyDamageBoost(boostMultiplier, boostTimeSeconds);

            Destroy(gameObject);

            AudioSource.PlayClipAtPoint(collectSound, new Vector3(0, 0, 0));
            //Instantiate(collectEffect, otherCollider.transform.position, otherCollider.transform.rotation);
        }
    }
}
