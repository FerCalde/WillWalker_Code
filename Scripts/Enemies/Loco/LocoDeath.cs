using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocoDeath : Death
{
    EnemyLoco refEnemy;
    // Start is called before the first frame update
    protected override void Start()
    {
        
        base.Start();
        refEnemy = GetComponent<EnemyLoco>();
        refEnemy.agente.isStopped = true;

        refEnemy.miAnim.SetTrigger("muerte");
        refEnemy.miAnim.ResetTrigger("Idle");
        refEnemy.miAnim.ResetTrigger("run");
        refEnemy.miAnim.ResetTrigger("Shoot");
    }
}
