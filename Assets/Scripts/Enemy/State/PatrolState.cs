using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    public float waittTimer;
    public override void Enter()
    {

    }

    public override void Perform()
    {
        PatrolCycle();
        if(enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }

    public override void Exit()
    {
        
    }

    public void PatrolCycle()
    {
        if(enemy.Agent.remainingDistance < 0.2f)
        {
            enemy.enemyAnimator.SetBool("walking", true);

            waittTimer += Time.deltaTime;
            if(waittTimer > 3)
            {
                if(waypointIndex < enemy.path.waypoints.Count - 1)
                    waypointIndex++;
                else
                    waypointIndex = 0;

                enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
                waittTimer = 0;
            }
            
        }
    }
}
