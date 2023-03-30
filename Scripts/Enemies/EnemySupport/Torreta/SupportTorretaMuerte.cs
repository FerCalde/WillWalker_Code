using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportTorretaMuerte : Death
{
    [SerializeField]GameObject explosion;
    protected override void Start()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(GetComponent<SupportTorreta>().padre.gameObject);
        
        base.Start();
       
    }
}
