using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Heal : MonoBehaviour
{
    //public GameObject collectEffect;
    public AudioClip collectSound;
    public int healAmount;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.layer == 7) // player layer
        {
            otherCollider.GetComponent<PlayerHealth>().Heal(healAmount);
            Destroy(gameObject);

            AudioSource.PlayClipAtPoint(collectSound, new Vector3(0, 0, 0));
            //Instantiate(collectEffect, otherCollider.transform.position, otherCollider.transform.rotation);
        }
    }
}
