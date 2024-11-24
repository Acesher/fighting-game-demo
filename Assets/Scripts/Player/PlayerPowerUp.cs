using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    public PlayerManager pManager;
    public GameObject damageBoostEffect;

    private float damageBoostTime = 0;

    void Update()
    {
        if (damageBoostTime <= 0)
        {
            pManager.damageBoostMultiplier = 1;
            damageBoostEffect.SetActive(false);
        }
        else if (damageBoostTime > 0) damageBoostTime -= 1 * Time.deltaTime;
    }

    public void ApplyDamageBoost(float boostMultiplier, float time)
    {
        pManager.damageBoostMultiplier = boostMultiplier;
        damageBoostTime = time;

        damageBoostEffect.SetActive(true);
    }
}
