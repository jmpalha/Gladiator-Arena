using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSate : PlayerAbilityState
{

    private Weapon weapon;

    private float velocityToSet;
    private bool setVelocity;

    public PlayerAttackSate(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        setVelocity = false;

        weapon.EnterWeapon();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(setVelocity)
        {
            core.Movement.SetVelocityX(velocityToSet * core.Movement.FacingDirection);
        }

    }

    public override void Exit()
    {
        base.Exit();

        weapon.ExitWeapon();
    }

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        weapon.InitializeWeapon(this, core);
    }

    public void SetPlayerVelocity(float velocity)
    {

        core.Movement.SetVelocityX(velocity * core.Movement.FacingDirection);

        velocityToSet = velocity;
        setVelocity = true; 
    }

    #region Animationg Triggers

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }
    #endregion
}
