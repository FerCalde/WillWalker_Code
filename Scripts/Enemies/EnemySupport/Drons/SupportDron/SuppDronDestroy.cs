using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppDronDestroy : Death
{
    SupportDron refEnemy;
    // Start is called before the first frame update
    protected override void Start()
    {
        refEnemy = GetComponent<SupportDron>();
        refEnemy.targetToSupp.GetComponent<VidaEnemyBase>().supported = false;
        base.Start();
    }

 
}
