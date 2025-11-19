using UnityEngine;

public class SearchState : BaseState
{
    private float searchTimer; 
    private float moveTimer;
    public override void Enter()
    {
        enemy.Agent.SetDestination(enemy.LastKnownPos);
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            // enemy.transform.localRotation = Quaternion.Euler(0, 143f, 0);
            stateMachine.ChangeState(new AttackState());
        }

        if(enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;
            if(moveTimer > Random.Range(3, 5))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 10));
                moveTimer = 0;
            }
            if(searchTimer > Random.Range(3, 10))
            {
                Debug.Log("Lost Player");
                enemy.enemyAnimator.SetBool("attackMod", false);
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public override void Exit()
    {
        
    }
}
