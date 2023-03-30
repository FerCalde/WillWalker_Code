using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosDeRuta : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
}
