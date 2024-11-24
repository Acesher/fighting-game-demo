using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    public GameObject voidDieEffect;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        PlayerHealth targetHealth = otherCollider.GetComponent<PlayerHealth>();

        if (targetHealth != null)
        {
            targetHealth.HitVoid();
            Instantiate(voidDieEffect, otherCollider.transform.position, otherCollider.transform.rotation * Quaternion.Euler(0f, 0f, 90f)); // rotate 90 degree
        }
    }
}
