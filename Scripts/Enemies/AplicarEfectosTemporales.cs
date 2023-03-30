using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AplicarEfectosTemporales : MonoBehaviour
{

    [SerializeField] float tempoActual;
    bool isEffectApply = false;

    float speedActual; //Diferentes velocidades para modificarlas y luego restablecerlas
    float speedWalk = 3.5f; //SPEED ANDAR 
    NavMeshAgent cmpAgent;
    float temporizadorEffect = 0;

    //VariablesParaTasher
    float timeTashed;
    float maxTimeTashed;
    public bool tashed;
    [SerializeField] ParticleSystem rallostasher;
    float damageTasher;

    void Start()
    {
        cmpAgent = GetComponent<NavMeshAgent>();
        speedActual = speedWalk;
        cmpAgent.speed = speedActual;
        rallostasher.Stop();
    }

    /* void Update()
     {
        if (tempoActual >= Time.time)
         {
             isEffectApply = true;
         }
         else
         {
             isEffectApply = false;
             if (tempoActual != 0)
             {
                 isEffectApply = false;
             }
         }

         if (!isEffectApply)
         {
             RestablecerSpeed();
         }
         //cmpAgent.speed = speedActual;
     }*/

    void Update()
    {
        temporizadorEffect -= Time.deltaTime;
        if (temporizadorEffect <= 0)
        {
            speedActual = speedWalk;
            temporizadorEffect = 0;
        }
        cmpAgent.speed = speedActual;
        if (tashed)
        {
            cmpAgent.speed = 0f;
            timeTashed += Time.deltaTime;
            if (timeTashed >= maxTimeTashed)
            {
                StopTashed();
            }
        }
    }
    public void IniciarEfecto(float tiempoEfecto, float speedRalentizada)
    {
        //print("EMPIEZA EFECTTT");
        tempoActual = Time.time + tiempoEfecto;
        RalentizarSpeed(speedRalentizada);
    }

    public void InicioTaserEffect(float tiempoStunTaser, float speedRalenti)
    {
        speedActual = speedRalenti;
        cmpAgent.speed = speedActual;
        temporizadorEffect = tiempoStunTaser;
    }
    public void EfectoTriggerEnter(float speedRalenti)
    {
        //speedWalk = cmpAgent.speed;

        speedActual = speedRalenti;
        //print("SALISTE DEL TRIGGER");
    }
    public void EfectoTriggerExit()
    {
        RestablecerSpeed();
    }

    void RalentizarSpeed(float speedRalentizada)
    {
        speedActual = speedRalentizada; //Valor para el navMesh
        cmpAgent.speed = speedRalentizada;
        print("Bajoo " + cmpAgent.speed);
    }

    void RestablecerSpeed()
    {
        speedActual = speedWalk;
        cmpAgent.speed = speedActual;
        print("RestanlecerSpeed "+ cmpAgent.speed);
    }

    public IEnumerator AplicarEfectoTemporal(float tiempoDuracionEfecto, float speedRalentizada)
    {
        print("CAMBIO SPEED");
        speedActual = speedRalentizada;
        cmpAgent.speed = speedActual;
        yield return new WaitForSeconds(tiempoDuracionEfecto);

        EfectoTriggerExit();
        //StopCoroutine(AplicarEfectoTemporal(tiempoDuracionEfecto, speedRalentizada));
    }

    public void GrenadeSlowerEffect(float speedRalentizada)
    {
        speedActual = speedRalentizada;
        cmpAgent.speed = speedRalentizada;
    }

    //TASHER
    public void Tashed(float timeTasher, float damage)
    {
        damageTasher = damage;
        maxTimeTashed = timeTasher;
        timeTashed = 0f;
        tashed = true;
        rallostasher.Play();
        
    }
    void StopTashed()
    {
        cmpAgent.speed = speedWalk;
        GetComponent<VidaEnemyBase>().TakeDamage(damageTasher);
        rallostasher.Stop();
        tashed = false;
    }

}
