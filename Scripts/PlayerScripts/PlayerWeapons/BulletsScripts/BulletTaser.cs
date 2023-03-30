using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTaser : BulletBase
{

    int cantRebotes = 0;
    [SerializeField] float tiempoStunAlEnemigo = 2;
    [SerializeField] float ralentiStunEnemigo = 0;
    [SerializeField] GameObject prefabAreaTaser;
    [SerializeField] GameObject prefabAreaExplosionTaser;


    protected override void OnTriggerEnter(Collider collision)
    {
        if (collision.tag != "Player" && collision.tag != "BalaPlayer")
        {
            InstanciarParticulasFeel();
            if (collision.tag == "Enemy")
            {
                InstanciarTaserExplosion();
            }
            if (collision.tag != "IgnoreBala")
            {
                if (chocaPared.Length != 0)
                {
                    NuevoSonido(chocaPared[Random.Range(0, chocaPared.Length - 1)], this.transform.position, 5f);
                }

            }
        }
    }

    void InstanciarTaserExplosion()
    {
        if (PlayerPrefs.GetInt("MejorasClaseHacker") > 3)
        {
            Instantiate(prefabAreaExplosionTaser, this.transform.position, this.transform.rotation);
        }
        else
        {
            Instantiate(prefabAreaTaser, this.transform.position, this.transform.rotation);
        }
        
        BulletColisiona();
    }

    /*
        protected override void OnTriggerEnter(Collider collision)
        {
            if (collision.tag != "Player" && collision.tag != "BalaPlayer")
            {
                InstanciarParticulasFeel();
                if (collision.tag == "Enemy")
                {
                    if (collision.GetComponent<AplicarEfectosTemporales>() != null)
                    {
                        collision.GetComponent<AplicarEfectosTemporales>().InicioTaserEffect(tiempoStunAlEnemigo, ralentiStunEnemigo);
                        //collision.GetComponent<AplicarEfectosTemporales>().GrenadeSlowerEffect(ralentiStunEnemigo);
                        //AplicarEfectosTemporales enemyTocado = collision.GetComponent<AplicarEfectosTemporales>();
                        //ApplyTaserEffect(enemyTocado);
                        cantRebotes++;
                    }
                }
                if (collision.tag != "IgnoreBala")
                {
                    if (chocaPared.Length != 0)
                    {
                        NuevoSonido(chocaPared[Random.Range(0, chocaPared.Length - 1)], this.transform.position, 5f);
                    }
                    // SoundVFX(ChocaPared);
                    //BulletColisiona();
                }
            }
        }


        void ApplyTaserEffect(AplicarEfectosTemporales enemyTocado)
        {
            //StartCoroutine(enemyTocado.AplicarEfectoTemporal(tiempoStunAlEnemigo, ralentiStunEnemigo));
            print("Tocado ENEMY TASEEEER");
        }

        void ChaseEnemyNear()
        {

        }*/
}
