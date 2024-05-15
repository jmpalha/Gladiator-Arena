using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    public Rigidbody2D RB { get; private set; }

    public int FacingDirection { get; private set; }

    public bool CanSetVelocity { get;  set; }

    public Vector2 CurrentVelocity { get; private set; }
    private Vector2 workspace;

    protected override void Awake()
    {
        base.Awake();

        RB = GetComponentInParent<Rigidbody2D>();
        FacingDirection = 1;
        CanSetVelocity = true;
    }

    public override void LogicUpdate()
    {
        CurrentVelocity = RB.velocity;
    }

    #region Set Functions

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        setFinalVelocity();
    }

    public void SetVelocity(float velocity, Vector2 direction)
    {
        workspace = direction * velocity;
        setFinalVelocity();
    }
    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        setFinalVelocity();
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        setFinalVelocity();
    }

    private void setFinalVelocity()
    {
        if(CanSetVelocity )
        {
            RB.velocity = workspace;
            CurrentVelocity = workspace;
        }
    }

    #endregion

    private void Flip()
    {
        FacingDirection *= -1;

        RB.transform.Rotate(0.0f, 180.0f, 0, 0f);
    }
    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection) { Flip(); }
    }

}
