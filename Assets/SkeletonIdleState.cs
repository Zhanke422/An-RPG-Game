using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : SkeletonGroundedState
{
    public SkeletonIdleState(Enemy _enemyBase, EnemyStateMachine stateMachine, string _aniBoolName, Enemy_Skeleton enemy) : base(_enemyBase, stateMachine, _aniBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = 1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}