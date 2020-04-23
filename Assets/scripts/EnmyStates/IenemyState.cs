using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IenemyState 
{
    void Excute();
    void Enter(Enemy enemy);
    void Exit();
    void OnTriggerEnter(Collider2D other);

}
