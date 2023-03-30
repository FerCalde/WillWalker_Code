using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserAreaExplosion : MonoBehaviour
{
    [Header("Afectan Enemigo")]

    [SerializeField] float damageBullet = 10f;
    [Tooltip("TIempo que estan taseados los enemigos")] [SerializeField] float tiempoTasearEnemigos = 1f; //TIempo que estan taseados los enemigos

    [Header("Configuracion Explosion")]

    [Tooltip("tiempo que dura activa la explosion")] [SerializeField] float tiempoAreaExplosionActiva = 0.3f; //tiempo que dura activa la explosion
    [SerializeField] float radiusSpherecast;

    // Start is called before the first frame update
    void Start()
    {
        radiusSpherecast = (this.transform.localScale.x * GetComponent<SphereCollider>().radius); //ajuste esfera al radio del trigger para un mejor debug
        Destroy(this.gameObject, tiempoAreaExplosionActiva);
        //radiusSpherecast = GetComponent<SphereCollider>().radius; ANTIGUA! Linea de referencia NO BORRAR
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "BalasPlayer")
        {
            if (other.CompareTag("Enemy"))
            {
                if (other.GetComponent<AplicarEfectosTemporales>() != null)
                {
                    other.GetComponent<AplicarEfectosTemporales>().Tashed(tiempoTasearEnemigos, damageBullet);
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" && other.tag != "BalasPlayer")
        {
            if (other.CompareTag("Enemy"))
            {
                if (other.GetComponent<AplicarEfectosTemporales>() != null)
                {
                    other.GetComponent<AplicarEfectosTemporales>().Tashed(tiempoTasearEnemigos, damageBullet);
                }
            }
        }


    }
    /*
    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && other.tag != "BalasPlayer")
        {
            if (other.CompareTag("Enemy"))
            {
                //SphereExplosion();
                print(other.name);

                if (other.GetComponent<AplicarEfectosTemporales>() != null)
                {
                    other.GetComponent<AplicarEfectosTemporales>().EfectoTriggerExit();
                }
            }
        }
    }
    */
    void SphereExplosion()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radiusSpherecast);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                if (hitCollider.GetComponent<AplicarEfectosTemporales>() != null)
                {
                    hitCollider.GetComponent<AplicarEfectosTemporales>().Tashed(tiempoTasearEnemigos, damageBullet);
                    print(hitCollider.name + " nombreTocado " + " Puedo aplicar efecto si eres un enemigo");
                }
            }
        }
    }


}
