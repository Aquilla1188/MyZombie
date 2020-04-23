using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeState : IenemyState
{
    private float attackTimer;
    private float attackCooldown=0.5f;
    private bool canAttack = true;



    private Enemy enemy;
    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Excute()
    {
        if (enemy.Target !=null)
        {
            if (enemy.InMeleeRange)
            {
                MainAttack();
            }
            else
            {
                enemy.Move();
            }
        }
        else
        {
            enemy.ChangeState(new IdleState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
       
    }

    private void MainAttack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            canAttack = true;
            attackTimer = 0;
            enemy.MyAnimator.SetFloat("speed", 0);
        }
        if (canAttack)
        {
            canAttack = false;
            enemy.MyAnimator.SetTrigger("attack");

        }
    }
}
