using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : CoreComponent
{
    [SerializeField] private float maxHealth;
    public float currenthealth;

    public HealthBar _healthBar;

    protected override void Awake()
    {
        base.Awake();

        currenthealth = maxHealth;
    }

    public void DeacreseHealth(float amount)
    {
        currenthealth -= amount;
        _healthBar.UpdateHealthBar(maxHealth, currenthealth);

        if (currenthealth <= 0 )
        {
            Debug.Log(currenthealth);
            currenthealth = 0;
            Death();
        }
    }

    public void IncreaseHealth(float amount)
    {
        currenthealth = Mathf.Clamp(currenthealth + amount, 0, maxHealth);
    }

    public void Death()
    {

        GM.RemoveLife();
    }
}
