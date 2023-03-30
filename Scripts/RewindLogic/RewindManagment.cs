using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RewindManagment : HabilidadBase
{
    public static bool isRewinding = false;
    public static float recordTime = 5f;
    public static float delayRewind = 5f;
    static float currentDelayRewind = 0f;
    InputManager sonidoManager;

    public float CurrentDelayRewind { get => currentDelayRewind; }

    public static void StartRewinding()
    {
        if (Time.time >= currentDelayRewind)
        {
            isRewinding = true;
            currentDelayRewind = Time.time + delayRewind;

            GameObject.FindObjectOfType<RewindManagment>().GetComponent<RewindManagment>().Activar();
            if (GameObject.FindObjectOfType<UIRewindHUD>() != null)
            {
                GameObject.FindObjectOfType<UIRewindHUD>().GetComponent<UIRewindHUD>().GetCooldownRewind(currentDelayRewind);
            }
        }
    }

    public static void StopRewinding()
    {
        //print("StopREWIND");
        if (isRewinding == true)
        {
            //print("en el IF Entro");
            GameObject.FindObjectOfType<RewindManagment>().GetComponent<RewindManagment>().DesactivarTimer();
            isRewinding = false;            
        }
    }

    private void Start()
    {
        recordTime = tiempoDuracionActivadoMaximo;
        delayRewind =  tiempoCooldownMaximo;
        //print(recordTime);
    }

    protected override void Update()
    {

        //print(isRewinding);
       // print(currentDelayRewind);
        if (isActiveHability)
        {
            tiempoDuracionActivaActual += Time.deltaTime;
        }
        if (!isActiveHability)
        {
            tiempoCooldownActual -= Time.deltaTime;
        }
        if (tiempoCooldownActual <= 0)
        {
            tiempoCooldownActual = 0;
        }
    }

    public override void Activar()
    {
        if (habilityCostTime)
        {
            GetComponent<VidaJugador>().HabilityDamage(costeHabilidadUtilizar); //HABILIDAD CUESTA TIEMPO
        }
        NuevoSonido();
        tiempoDuracionActivaActual = 0;
        isActiveHability = true;
    }

    public void DesactivarTimer()
    {
        //print("en el VoID Entro");
        tiempoCooldownActual = delayRewind;
        isActiveHability = false;
    }
}
