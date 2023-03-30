using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadDeadEye : HabilidadClase
{
    VidaJugador vida;
    [SerializeField] float ralenti = 0.4f;
    [SerializeField] Root root;
    Mov mov;
    [SerializeField] EnemyInfo enemyInfo;
    public List<GameObject> enemigosLista;
    public int maxEnemigosMarcados;
    public int enemigosMarcados;
    public bool ejecutarDeadEye = false;
    Quaternion rotInicial;
    [SerializeField] GameObject fx_Explote;
    public bool deadEyeAviable = false;
    [SerializeField]GameObject character;
    [SerializeField] float deadEyeWaitShoot;
    [SerializeField] ParticleSystem muzzleSmoke;
    float timewaitingShoot;
    public GameObject soniDeadEYE;
    [SerializeField] GameObject RayDeadEye;
    WeaponController wp;
    //bugcontrolTIME
    bool callOnce = false;
    bool deadeyeBUGCONTROL = false;
    

    void Start()
    {
        wp = GetComponent<WeaponController>();
        vida = GetComponent<VidaJugador>();
        RayDeadEye.SetActive(false);
        muzzleSmoke.Stop();
        rotInicial = transform.rotation;
        mov = GetComponent<Mov>();
    }
    protected override void Update()
    {
        if (deadeyeBUGCONTROL == true)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = ralenti;
            }
            tiempoDuracionActivaActual += Time.deltaTime;
            
        }
        tiempoCooldownActual -= Time.deltaTime;
        if (tiempoCooldownActual <= 0)
        {
            tiempoCooldownActual = 0;
        }
        if (tiempoDuracionActivaActual >= tiempoDuracionActivadoMaximo || enemigosMarcados >= maxEnemigosMarcados)
        {
            DesactivarEfecto();
        }
        
        if (ejecutarDeadEye == true)
        {
            
            
            DeadEye();
                

        }
        else
        {
            callOnce = false;
        }
    }

    public override void Activar()
    {
        if (isHabilityUnlocked)//CHecker ArbolHabilidades
        {
            if (tiempoCooldownActual <= 0)
            {
                if (!isActiveHability)
                {
                    if (habilityCostTime)
                    {
                        GetComponent<VidaJugador>().HabilityDamage(costeHabilidadUtilizar); //HABILIDAD CUESTA TIEMPO
                    }
                    //startPositionTransform.position = newEspectro2.transform.position;
                    deadeyeBUGCONTROL = true;
                    //NuevoSonido();
                    AplicarEfecto();
                    tiempoDuracionActivaActual = 0;
                    wp.BusyState();
                    isActiveHability = true;
                }
            }

        }
        
    }

    protected void DesactivarEfecto()
    {
        deadEyeAviable = false;
        ejecutarDeadEye = true;
        isActiveHability = false;
        enemigosMarcados = 0;
    }

    protected override void AplicarEfecto()
    {
        GetComponent<VidaJugador>().ActivarInmunidadTemporal(2f);
        NuevoSonido();
        tiempoCooldownActual = tiempoCooldownMaximo;
        Time.timeScale = ralenti;
        deadEyeAviable = true;
        RayDeadEye.SetActive(true);
    }
    void DeadEye()
    {
        if (callOnce == false)
        {
            Time.timeScale = 1f;

            callOnce = true;
        }
        if (enemigosLista.Count > 0)
        {
            deadeyeBUGCONTROL = false;
            RayDeadEye.SetActive(false);
            mov.canMove = false;
            root.canRot = false;
            if (enemigosLista[0] == null)
            {
                timewaitingShoot = 0f;
                enemigosLista.RemoveAt(0);
            }
            if (enemigosLista[0].activeSelf == false)
            {
                timewaitingShoot = 0f;
                enemigosLista.RemoveAt(0);
            }
            if (enemigosLista[0]!= null)
            {
                timewaitingShoot += Time.deltaTime;
                if (timewaitingShoot >= deadEyeWaitShoot)
                {
                    Vector3 lookVector = enemigosLista[0].transform.position - character.transform.position;
                    lookVector.y = 0;
                    Quaternion rot = Quaternion.LookRotation(lookVector);
                    character.transform.rotation = Quaternion.Slerp(character.transform.rotation, rot, 0.1f);
                    
                    if (character.transform.rotation.y >=  rot.y - 2 && character.transform.rotation.y <= rot.y + 2) //enemyInfo.enemigoApuntado == enemigosLista[0] || )
                    {
                        
                        muzzleSmoke.Play();
                        if (timewaitingShoot >= deadEyeWaitShoot * 2)
                        {
                            Instantiate(fx_Explote, enemigosLista[0].transform.position, enemigosLista[0].transform.rotation);
                            //enemigosLista[0].GetComponentInParent<RewindLogic>().Destroy();
                            enemigosLista[0].GetComponentInParent<Transform>().gameObject.SetActive(false) ;
                            enemigosLista.RemoveAt(0);
                            timewaitingShoot = 0f;
                            if (PlayerPrefs.GetInt("MejorasClaseForastero") > 3)
                            {
                                vida.CurarVidaNoParticles(6f);
                            }
                        }
                        
                    }
                }
                
                
            }
            
        }
        else
        {
            
            RayDeadEye.SetActive(false);
            Debug.Log("quehacespasando por aqui");
            muzzleSmoke.Stop();
            mov.canMove = true;
            root.canRot = true;
            transform.rotation = rotInicial;
            
            wp.BusyState();
            deadeyeBUGCONTROL = false;
            ejecutarDeadEye = false;
        }
    }
   
    
}
