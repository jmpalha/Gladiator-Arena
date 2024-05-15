using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTestDummy : MonoBehaviour, IDamageable
{
    private Animator anim;

    private float maxHealth;
    private float currHealth;

    public void Damage(float amount)
    {
        currHealth -= amount;

        Debug.Log("Dummy took" + amount + "of damage");

        if (currHealth <= 0) { Destroy(gameObject); }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        maxHealth = 100;
        currHealth = maxHealth;
    }
}
