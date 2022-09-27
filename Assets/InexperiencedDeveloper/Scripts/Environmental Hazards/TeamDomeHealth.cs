using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamDomeHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;

    private void Start()
    {

        health = maxHealth;
        slider.value = CalculateHealth();

    }

    private void Update()
    {

        slider.value = CalculateHealth();

        if(health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if(health <=0)
        {
            Destroy(gameObject);
        }

    }

    float CalculateHealth()
    {

        return health / maxHealth;

    }




}
