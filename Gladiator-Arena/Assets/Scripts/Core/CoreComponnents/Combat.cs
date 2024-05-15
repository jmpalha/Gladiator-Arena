using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnowbackable
{
    [SerializeField] private float maxKnockBackTime = 0.2f;

    private bool isKnowbackActive = false;
    private float knockbackStartTime;

    public override void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(float amount)
    {
        core.Stats.DeacreseHealth(amount);
    }

    public void Knockback(Vector2 angle, float strenght, int direction)
    {
        core.Movement.SetVelocity(strenght, angle, direction);
        core.Movement.CanSetVelocity = false;
        isKnowbackActive = true;
        knockbackStartTime = Time.time;
    }

    private void CheckKnockback()
    {
        if (!isKnowbackActive && (core.Movement.CurrentVelocity.y <= 0.01f && core.CollisionSenses.Ground) || Time.time >= knockbackStartTime + maxKnockBackTime)
        {
            isKnowbackActive = false;
            core.Movement.CanSetVelocity = true;
        }
    }
}
