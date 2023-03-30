using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Carabina : ArmaBaseSemiAutomatica
{
    // Start is called before the first frame update

    public GameObject sonidoPistola;


    [SerializeField] bool shotMakeDamage = true;
    [SerializeField] float damageShotTime = 1.5f;
    
    public float contador;
    float time;


    public override void Disparar()
    {
        if (Time.time > tiempoProximoDisparo)
        {
            tiempoProximoDisparo = Time.time + tiempoEntreDisparo;

            if (GetComponentInParent<VidaBase>().Inmune == false)
            {
                currentAmmo -= 1;
                if (shotMakeDamage)
                {
                    GetComponentInParent<VidaJugador>().HabilityDamage(damageShotTime);
                }
            }
            InstanciarProyectil();

            BulletScreen();

            cmpAnimator.SetTrigger("Shooting");

            //PULIDO 

            //SoundVFX(vfxSoundDisparo);
            NuevoSonido(sonidoPistola, this.transform.position, 2f);
            ParticleVFX();
            CameraShaker.Instance.ShakeOnce(cameraShakeModifier.x, cameraShakeModifier.y, cameraShakeModifier.z, cameraShakeModifier.w);
            
            NuevoSonido(sonidoRecarga, this.transform.position, 2f);
        }
    }


    void Update()
    {
        if (Time.time > tiempoProximoDisparo)
        {
            currentAmmo = 1;
            BulletScreen();
        }
        else
        {
            currentAmmo = 0;
        }
    }

    public override void Recargar()
    {
        //base.Recargar();
    }

    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }

}
