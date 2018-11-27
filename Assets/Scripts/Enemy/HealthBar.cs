using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    private const int LOW_HP = 50;
    [SerializeField]
    private Image image;
    [SerializeField]
    private RectTransform healthBarRect;
    [SerializeField]
    private Text healthBarText;
    [SerializeField]
    private Color colorLowHealth;

    private void Start()
    {
        
    }

    public void SetHealth(float currentHealt, float maxHealth)
    {
        float _value = currentHealt / maxHealth;
        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.z);

        if(currentHealt <= LOW_HP)
        {
            image.color = colorLowHealth;
        }

        healthBarText.text = $"{currentHealt} / {maxHealth} HP";
    }
}
