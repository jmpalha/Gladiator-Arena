
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerAttackSate PrimaryAttackState { get; private set; }
    public PlayerAttackSate SecondaryAttackState { get; private set; }

    [SerializeField]
    private PlayerData playerData;
    #endregion

    public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public PlayerInventory Inventory { get; private set; }

    private float saveDespawnTime = 5f;
    private float speedDespawnTime = 5f;
    private bool speedPotionOn = false;
    private float hitDespawnTime = 5f;
    private bool hitPotionOn = false;
    private float jumpDespawnTime = 5f;
    private bool jumpPotionOn = false;
    private int increaseDamage = 1;

    public AudioSource hitSound;



    [SerializeField]  public int weaponID;

    private Vector2 workspace;

    private void Awake()
    {
        Core = GetComponentInChildren<Core>();

        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "wallSlide");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, "inAir");
        DashState = new PlayerDashState(this, StateMachine, playerData, "slide");
        PrimaryAttackState = new PlayerAttackSate(this, StateMachine, playerData, "attack",hitSound);
        SecondaryAttackState = new PlayerAttackSate(this, StateMachine, playerData, "attack",hitSound);
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        Inventory = GetComponent<PlayerInventory>();

        PrimaryAttackState.SetWeapon(Inventory.waepons[weaponID]);
        //SecondaryAttackState.SetWeapon(Inventory.waepons[(int)CombatInputs.primary]);

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        if(speedPotionOn){
            speedDespawnTime -= Time.deltaTime;

            if(speedDespawnTime < 0){
                MoveState.setNewMoveVelocityIncrease(1);
                speedDespawnTime = saveDespawnTime;
                speedPotionOn = false;
            }
        }

        if(hitPotionOn){
            hitDespawnTime -= Time.deltaTime;

            if(hitDespawnTime < 0){
                increaseDamage = 1;
                hitDespawnTime = saveDespawnTime;
                hitPotionOn = false;
            }
        }

        if(jumpPotionOn){
            jumpDespawnTime -= Time.deltaTime;

            if(jumpDespawnTime < 0){
                JumpState.setNewJumpVelocityIncrease(1);
                jumpDespawnTime = saveDespawnTime;
                jumpPotionOn = false;
            }
        }

        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void setWeapon(int id)
    {
        PrimaryAttackState.SetWeapon(Inventory.waepons[id]);
    }

    public void setHitPotionOn(){
        if(!hitPotionOn){
            increaseDamage = 2;
            hitPotionOn = true;
        }else{
            hitDespawnTime += saveDespawnTime;
        }
    }

    public void setSpeedPotionOn(){
        if(!speedPotionOn){
            MoveState.setNewMoveVelocityIncrease(3);
            speedPotionOn = true;
        }else{
            speedDespawnTime += saveDespawnTime;
        }
    }

    public void setJumpPotionOn(){
        if(!jumpPotionOn){
            JumpState.setNewJumpVelocityIncrease(2);
            jumpPotionOn = true;
        }else{
            jumpDespawnTime += saveDespawnTime;
        }

    }

    public int getIncreaseDamage(){
        return increaseDamage;
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    public virtual void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();


}
