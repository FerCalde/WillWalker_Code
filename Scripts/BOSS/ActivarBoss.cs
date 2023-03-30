using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarBoss : MonoBehaviour
{
    [SerializeField] BossBehaviour bbh;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 8)
        {
            bbh.combateIniciado = true;
            Destroy(gameObject);
        }
    }
}
