using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunBoss : MonoBehaviour
{
    BossBehaviour bbh;
    NavMeshAgent nav;
    GameObject playerRef;
    Vector3 destination;
    VidaBoss vida;

    [SerializeField] int carreras;
    int cantidadCarreras = 0;
    [SerializeField] float dañoCarrera;
    [SerializeField] float tiempoStun = 3f;
    [SerializeField] ParticleSystem vfxCorrer;
    [SerializeField] ParticleSystem vfxCorrer2;
    [SerializeField] GameObject soniTaser;
    [SerializeField] float timeToNewDestination;
    [SerializeField] GameObject soniactivte;
    float timeDestination;
    void Start()
    {
        cantidadCarreras = 0;
        timeDestination = 0f;
        vida = gameObject.GetComponent<VidaBoss>();
        vida.bossNoTakeDamage = true;
        playerRef = GameObject.FindGameObjectWithTag("Player");
        bbh = gameObject.GetComponent<BossBehaviour>();
        nav = gameObject.GetComponent<NavMeshAgent>();
        nav.speed = bbh.acelerateSpeed;
        destination = playerRef.transform.position;
        nav.SetDestination(destination);
    }
    void Update()
    {
        float distToPoint = Vector3.Distance(destination, transform.position);
        float distToPlayer = Vector3.Distance(playerRef.transform.position, transform.position);
        if (distToPoint <= 1)
        {
            
            if (cantidadCarreras < carreras)
            {
                
                bbh.anim.SetTrigger("Idle");
                bbh.anim.ResetTrigger("Carga");
                nav.speed = 0f;
                timeDestination += Time.deltaTime;
                if(timeDestination >= timeToNewDestination)
                {

                    vfxCorrer.Play();
                    SetDestination();
                    timeDestination = 0;
                    
                    vfxCorrer2.Play();
                }
            }
            else
            {
                vida.bossNoTakeDamage = false;
                bbh.mortero = true;
                bbh.carreritas = false;
                
                
                
            }
        }
        else
        {
            bbh.anim.SetTrigger("Carga");
            bbh.anim.ResetTrigger("Idle");
        }
        if (distToPlayer <= 4)
        {
            bbh.mortero = true;
            bbh.carreritas = false;
            vida.bossNoTakeDamage = false;
            playerRef.GetComponentInChildren<TasherEffect>().stunTime = tiempoStun;
            playerRef.GetComponentInChildren<TasherEffect>().timer = tiempoStun;
            playerRef.GetComponentInChildren<TasherEffect>().tashed = true;
            NuevoSonido(soniTaser, this.transform.position, 2f);
            playerRef.GetComponent<VidaJugador>().TakeDamage(dañoCarrera);
          
        }
    }
    void SetDestination()
    {
        NuevoSonido(soniactivte, transform.position, 2f);
        transform.LookAt(new Vector3(playerRef.transform.position.x, transform.position.y, playerRef.transform.position.z));
        destination = playerRef.transform.position;
        nav.SetDestination(destination);
        nav.speed = bbh.acelerateSpeed;
        cantidadCarreras++;
        
        
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }
}
