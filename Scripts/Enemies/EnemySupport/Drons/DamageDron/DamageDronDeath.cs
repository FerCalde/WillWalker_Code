using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDronDeath : Death
{
    SupportDamageDron refEnemy;
    // Start is called before the first frame update
    protected override void Start()
    {
        gameObject.SetActive(false);
        base.Start();
    }
}
