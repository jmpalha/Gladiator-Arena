using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTestDummy : MonoBehaviour, IDamageable
{
    private Animator anim;

    private float maxHealth;
    private float currHealth;

    [SerializeField] private HealthBar _healthBar;

    public void Damage(float amount)
    {
        currHealth -= amount;
        _healthBar.UpdateHealthBar(maxHealth, currHealth);

        Debug.Log("Dummy took" + amount + "of damage");

        if (currHealth <= 0) { Destroy(gameObject); }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        maxHealth = 100;
        currHealth = maxHealth;
        _healthBar.UpdateHealthBar(maxHealth, currHealth);
    }
}
