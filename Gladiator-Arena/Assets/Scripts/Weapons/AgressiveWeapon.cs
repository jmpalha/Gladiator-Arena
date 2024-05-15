using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AgressiveWeapon : Weapon
{
    protected SO_AgressiveWeaponData agressiveWeaponData;

    private List<IDamageable> detectedDamageable = new List<IDamageable>();
    private List<IKnowbackable> detectedKnowbackable = new List<IKnowbackable>();

    protected override void Awake()
    {
        base.Awake();

        if(weaponData.GetType() == typeof(SO_AgressiveWeaponData))
        {
            agressiveWeaponData = (SO_AgressiveWeaponData)weaponData;
        }
        else
        {
            Debug.LogError("Wrong data for the weapon");
        }
    }
    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {

        WeaponAttackDetails details = agressiveWeaponData.AttackDetails[attackCounter];

        foreach(IDamageable item in detectedDamageable.ToList())
        {
            item.Damage(details.damageAmount);
        }

        foreach (IKnowbackable item in detectedKnowbackable.ToList())
        {
            item.Knockback(details.knockbackAngle, details.knockbackStrength, core.Movement.FacingDirection);
        }
    }

    public void AddToDetected(Collider2D colision)
    {
        IDamageable damageable = colision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageable.Add(damageable);
        }

        IKnowbackable knowbackable = colision.GetComponent<IKnowbackable>();

        if (knowbackable != null)
        {
            detectedKnowbackable.Add(knowbackable);
        }

    }

    public void RemoveFromDetected(Collider2D colision)
    {
        IDamageable damageable = colision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageable.Remove(damageable);
        }

        IKnowbackable knowbackable = colision.GetComponent<IKnowbackable>();

        if (knowbackable != null)
        {
            detectedKnowbackable.Remove(knowbackable);
        }


    }


}
