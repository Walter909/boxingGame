using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public Health playerHealth;
    public Image fillImage;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //handling lower health
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        float fillValue = playerHealth.currentHealth / playerHealth.maxHealth;

        if (fillValue < slider.maxValue / 2 && fillValue > slider.maxValue / 3)
        {
            fillImage.color = Color.yellow;
        }
        else if (fillValue < slider.maxValue / 3)
        {
            //purple
            fillImage.color = new Color(143, 0, 254, 1);
        }

        slider.value = fillValue;
    }
}
