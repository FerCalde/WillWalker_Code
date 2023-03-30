using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBoss : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag =="BalaPlayer")
        {
            if (col.gameObject.GetComponent<BulletBoomerang>() == null)
            {
                Destroy(col.gameObject);
            }
           
        }

    }
}
