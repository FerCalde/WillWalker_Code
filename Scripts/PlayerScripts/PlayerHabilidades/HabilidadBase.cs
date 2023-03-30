using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadBase : Singleton
{
    Sprite icono = null;
    [SerializeField] protected float tiempoCooldownMaximo = 10f;
    protected float tiempoCooldownActual;

    public Sprite Icono { get => icono; }
    public float TiempoReutilizacionActual { get => tiempoCooldownActual; }
    public float TiempoReutilizacionMaximo { get => tiempoCooldownMaximo; }

    [SerializeField] protected float tiempoDuracionActivadoMaximo = 3f;
    protected float tiempoDuracionActivaActual;
    public float TiempoDuracionActual { get => tiempoDuracionActivaActual; }
    public float TiempoDuracionActivadoMaximo { get => tiempoDuracionActivadoMaximo; }

    public bool isActiveHability = false;
    [SerializeField] protected bool habilityCostTime = true;
    [SerializeField] protected float costeHabilidadUtilizar = 10f;
    //[SerializeField] float costeHabilidad = 10f;

    [SerializeField] GameObject sonidoHabilidad;

    [SerializeField]protected bool isHabilityUnlocked = false; //Arbol de Habilidades

    public virtual void Activar()
    {
        if (isHabilityUnlocked)
        {
            if (tiempoCooldownActual <= 0)
            {
                if (habilityCostTime)
                {
                    GetComponent<VidaBase>().DamageHabilidad(costeHabilidadUtilizar); //HABILIDAD CUESTA TIEMPO
                }
                isActiveHability = true;
                AplicarEfecto();
                tiempoCooldownActual = tiempoCooldownMaximo;
            }
        }
    }

    protected virtual void Update()
    {
        tiempoCooldownActual -= Time.deltaTime;
        if (tiempoCooldownActual <= 0) tiempoCooldownActual = 0;

    }

    protected virtual void AplicarEfecto()
    {

    }

    protected void NuevoSonido()
    {
        Destroy(Instantiate(sonidoHabilidad, this.transform.position, Quaternion.identity), 2f);
    }

    public void UnlockHability()
    {
        isHabilityUnlocked = true;
    }

}
