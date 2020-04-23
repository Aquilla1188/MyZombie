using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IenemyState
{
    private Enemy enemy;
    private float idleTimer, idleDuration=5f;
    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Excute()
    {
        Idle();
        if(enemy.Target != null)
        {
            enemy.ChangeState(new PatrolState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }

    private void Idle()
    {
        enemy.MyAnimator.SetFloat("speed", 0);
        idleTimer += Time.deltaTime;

        if(idleTimer >= idleDuration)
        {
            enemy.ChangeState(new PatrolState());
        }
    }


}
