using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool CanDash { get; private set; }

    private float lastDashTime;

    private Vector2 dashDirection;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        CanDash = false;
        player.InputHandler.UseDashInput();

        dashDirection = Vector2.right * player.FacingDirection;
        startTime = Time.time;
    }

    public override void Exit()
    {
        base.Exit();

        if(player.CurrenctVelocity.y > 0) 
        {
            player.SetVelocityY(player.CurrenctVelocity.y * playerData.dashEndYMultiplier);
        }
    }

    public override void LogicUpdate()
    {
        Debug.Log("ok");
        base.LogicUpdate();

        if(!isExitingState)
        {
            player.RB.drag = playerData.drag;
            player.SetVelocity(playerData.dashVelocity, dashDirection);

            if(Time.time >= startTime + playerData.dashTime) 
            {
                player.RB.drag = 0f;

                lastDashTime = Time.time;

                isAbilityDone = true;

            }
        }
    }

    public bool CheckIfCanDash()
    {
        return CanDash && Time.time >= lastDashTime + playerData.dashCooldown;
    }

    public void ResetCanDash() => CanDash = true;

}
