using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKey(KeyCode.R) && player.skill.blackhole.blackholeUnlocked)
        {
            stateMachine.ChangeState(player.blackholeState);
        }

        if (Input.GetKey(KeyCode.Mouse1) && HasNoSword() && player.skill.sword.swordUnlocked)
        {
            stateMachine.ChangeState(player.aimSwordState);
        }

        if (Input.GetKey(KeyCode.Q) && player.skill.parry.parryUnlocked)
        {
            stateMachine.ChangeState(player.counterAttackState);
        }

        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.J))
        {
            stateMachine.ChangeState(player.primaryAttackState);
        }

        if (!player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.airState);
        }

        if (Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.jumpState);
        }
    }

    private bool HasNoSword()
    {
        if (!player.sword)
        {
            return true;
        }
        player.sword.GetComponent<Sword_Skill_Controller>().ReturnSword();
        return false;
    }
}
