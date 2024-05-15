using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponent
{
    [SerializeField] private float maxHealth;
    private float currenthealth;

    protected override void Awake()
    {
        base.Awake();

        currenthealth = maxHealth;
    }

    public void DeacreseHealth(float amount)
    {
        currenthealth -= amount;

        if(currenthealth <= 0 )
        {
            currenthealth = 0;
            Debug.Log("Dead");
        }
    }

    public void IncreaseHealth(float amount)
    {
        currenthealth = Mathf.Clamp(currenthealth + amount, 0, maxHealth);
    }
}
