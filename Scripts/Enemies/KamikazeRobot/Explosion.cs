using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float dañoExplo = 20f;
    bool doOnce = false;
    //EXPLOSION DE ENEMIGO SUICIDA RESTA VIDA
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.layer == 8)
        {
            if (doOnce == false)
            {
                col.gameObject.GetComponentInParent<VidaJugador>().TakeDamage(dañoExplo);
                doOnce = true;
            }
           
        }
        if (col.gameObject.tag == "Enemy")
        {
            if (col.gameObject.layer != 12 && col.gameObject.GetComponent<VidaEnemyBase>() != null)
            {
                col.gameObject.GetComponent<VidaEnemyBase>().TakeDamage(dañoExplo * 5);
            }
        }
    }
}
