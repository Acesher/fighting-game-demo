using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject bar;
    public Text healthText;

    RectTransform rect;
    Image image;

    private Color32 yellow = new Color32(255, 255, 48, 255);

    void Start()
    {
        rect = bar.GetComponent<RectTransform>();
        image = bar.GetComponent<Image>();
    }

    public void SetHealthBar(float currHealth, float healthBarVal)
    {
        healthText.text = currHealth.ToString();
        rect.localScale = new Vector3(healthBarVal / 100, 1f);

        if (healthBarVal <= 25) image.color = Color.red;
        else if (healthBarVal <= 75) image.color = yellow;
        else image.color = Color.green;
    }
}
