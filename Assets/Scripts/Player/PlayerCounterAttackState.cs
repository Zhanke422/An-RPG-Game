using UnityEngine;

public class PlayerCounterAttackState : PlayerState
{
    private bool canCreatedClone;
    public PlayerCounterAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        canCreatedClone = true;
        stateTimer = player.counterAttackDuration;
        player.anim.SetBool("SuccessfulCounterAttack", false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        //stop move
        player.SetZeroVelocity();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                if (hit.GetComponent<Enemy>().CanBeStunned())
                {
                    stateTimer = 100; // any big value > 1
                    player.anim.SetBool("SuccessfulCounterAttack", true);

                    player.skill.parry.UseSkill(); // going to use restore health on parry

                    if (canCreatedClone)
                    {
                        canCreatedClone = false;
                        player.skill.parry.MakeMirageOnParry(hit.transform);
                    }

                }
            }
        }

        if (stateTimer < 0 || triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
