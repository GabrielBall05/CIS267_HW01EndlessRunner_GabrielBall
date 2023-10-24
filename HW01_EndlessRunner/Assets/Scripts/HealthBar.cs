using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //I watched a tutorial for the health bar
    [SerializeField] private Slider slider;

    public void updateHealthbar(float curHealth, float maxHealth)
    {
        slider.value = curHealth / maxHealth;
    }
}
