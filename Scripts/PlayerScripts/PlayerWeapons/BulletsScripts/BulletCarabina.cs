using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCarabina : BulletBase
{
    protected override void OnTriggerEnter(Collider collision)
    {
        if (collision.tag != "Player")
        {
            InstanciarParticulasFeel();
            if (collision.tag == "Enemy")
            {
                AplicarEfecto(collision);
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
}
