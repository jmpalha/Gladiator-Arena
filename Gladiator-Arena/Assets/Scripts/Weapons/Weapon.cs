using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] protected SO_WeaponData weaponData;

    protected Animator baseAnimator;
    protected Animator weaponAnimator;

    protected PlayerAttackSate state;

    protected Core core;

    protected int attackCounter;

    protected virtual void Awake()
    {

        baseAnimator = transform.Find("Base").GetComponent<Animator>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();

        gameObject.SetActive(false);
    }
    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        if(attackCounter >= weaponData.amountOfAttacks)
        {
            attackCounter = 0;
        }

        baseAnimator.SetBool("attack", true);
        weaponAnimator.SetBool("attack", true);

        baseAnimator.SetInteger("attackCounter", attackCounter);
        weaponAnimator.SetInteger("attackCounter", attackCounter);
    }

    public virtual void ExitWeapon()
    {
        baseAnimator.SetBool("attack", false);
        weaponAnimator.SetBool("attack", false);

        attackCounter++;

        gameObject.SetActive(false);
    }

    #region Animationg Triggers

    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    }

    public virtual void AnimationStartMovementTrigger()
    {
        state.SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);
    }

    public virtual void AnimationStopMovementTrigger()
    {
        state.SetPlayerVelocity(0f);
    }

    public virtual void AnimationActionTrigger()
    {

    }

    #endregion

    public void InitializeWeapon(PlayerAttackSate state, Core core)
    {
        this.state = state;
        this.core = core;
    }
}
