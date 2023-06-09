using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    float distanceToPlayer;

    public EnemyAttackState(EnemyController _enemy) : base(_enemy)
    {

    }
    public override void OnStateEnter()
    {
        Debug.Log("Enemy will attack the player");
    }

    public override void OnStateExit()
    {
        Debug.Log("Enemy will not attack the player");
    }

    public override void OnStateUpdate()
    {
        if(enemy.player != null)
        {
            distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.player.position);

            if(distanceToPlayer > 2)
            {
                enemy.ChangeState(new EnemyFollowState(enemy));
            }

            enemy.agent.destination = enemy.player.position;
        }
        else
        {
            //Go back to the idle state
            enemy.ChangeState(new EnemyIdleState(enemy));
        }
    }
}
