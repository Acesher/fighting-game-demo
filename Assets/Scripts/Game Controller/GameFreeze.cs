using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFreeze : MonoBehaviour
{
    public float freezeDuration = 0.08f;
    private float duration = 0f;
    private bool isFrozen = false;

    // Update is called once per frame
    void Update()
    {
        if (duration > 0 && !isFrozen)
        {
            StartCoroutine(StartFreeze());
        }
    }

    public void Freeze()
    {
        duration = freezeDuration;
    }

    IEnumerator StartFreeze()
    {
        isFrozen = true;
        var lastTime = Time.timeScale; // store current time
        Time.timeScale = 0f; // freeze time

        // if use WaitForSeconds we stuck forever, since WaitForSeconds is effected by Time.timescaled and we paused it
        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = lastTime; // set time back to before the freeze
        duration = 0f;
        isFrozen = false;
    }
}
