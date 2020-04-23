using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IenemyState
{
    private Enemy enemy;
    private float PatrolTimer, patrolDuration = 10f;
    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Excute()
    {
       
        Patrol();
       // enemy.Move();
        if (enemy.Target != null)
        {
            enemy.ChangeState(new MeleeState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }

    private void Patrol()
    {
 
        PatrolTimer += Time.deltaTime;

        if (PatrolTimer >= patrolDuration)
        {
            enemy.ChangeState(new IdleState());
        }
    }
}
