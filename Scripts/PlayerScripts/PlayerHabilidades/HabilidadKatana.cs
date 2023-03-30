using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadKatana : HabilidadClase
{
    public bool katanaHabilidad;
    [SerializeField] GameObject katanaFunda;
    [SerializeField] GameObject katana;
    public ParticleSystem circuloNaranja;
    public ParticleSystem beamUp;
    public ParticleSystem RegenerarKatana;
    [SerializeField] GameObject SonidoHabilidad;
    Animator cmpAnimator;
    WeaponController cmpWeaponController;

    void Start()
    {
        cmpAnimator = GetComponent<Animator>();
        cmpWeaponController = GetComponent<WeaponController>();
    }
    protected override void Update()
    {
        tiempoCooldownActual -= Time.deltaTime;
        if (tiempoCooldownActual <= 0)
        {
            tiempoCooldownActual = 0;
        }

        tiempoDuracionActivaActual += Time.deltaTime;
        if (tiempoDuracionActivaActual >= tiempoDuracionActivadoMaximo)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {

                if (katanaHabilidad)
                {
                    tiempoCooldownActual = tiempoCooldownMaximo;
                    DesactivarEfecto();
                }

                tiempoDuracionActivaActual = tiempoDuracionActivadoMaximo;
            }

        }

    }
    protected void DesactivarEfecto()
    {
        katana.SetActive(false);
        katanaFunda.SetActive(true);
        katanaHabilidad = false;
        isActiveHability = katanaHabilidad;
        cmpWeaponController.BusyState();
        cmpWeaponController.OcultarActivarArma();
        cmpWeaponController.CheckerAnimator();
        tiempoCooldownActual = tiempoCooldownMaximo;
        circuloNaranja.Stop();
        beamUp.Stop();
        RegenerarKatana.Stop();
    }
    protected override void AplicarEfecto()
    {
        cmpWeaponController.OcultarActivarArma();
        AnimatorLayerChanger();
        cmpWeaponController.BusyState();
        katana.SetActive(true);
        katanaFunda.SetActive(false);
        katanaHabilidad = true;
        circuloNaranja.Play();
        beamUp.Play();
        RegenerarKatana.Play();
        NuevoSonido(SonidoHabilidad, this.transform.position, 2f);
    }
    public override void Activar()
    {
        if (isHabilityUnlocked)
        {
            if (tiempoCooldownActual <= 0)
            {

                if (!isActiveHability)
                {
                    if (habilityCostTime)
                    {
                        GetComponent<VidaJugador>().HabilityDamage(costeHabilidadUtilizar); //HABILIDAD CUESTA TIEMPO
                    }
                    isActiveHability = true;
                    AplicarEfecto();
                    tiempoDuracionActivaActual = 0;
                }
            }
        }
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }

    void AnimatorLayerChanger()
    {
        cmpAnimator.SetLayerWeight(4, 1f);
        cmpAnimator.SetLayerWeight(1, 0f);
        cmpAnimator.SetLayerWeight(2, 0f);
        cmpAnimator.SetLayerWeight(3, 0f);
    }

}
