using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseShoot : MonoBehaviour
{
    BossBehaviour bbh;
    NavMeshAgent nav;
    GameObject playerRef;
    [SerializeField] GameObject shootPoint;
    [SerializeField] GameObject bossBullet;
    float distToPlayer;
    [SerializeField]float maxCloseToPlayer = 4f;
    [SerializeField] float cadence = 0.5f;
    float timeShoot = 0f;
    [SerializeField] int disparosMax;
    [SerializeField] int disparosMin;
    
    int disparosCambio;
    int disparosRealizados;

    [SerializeField] int disparosPorRafaga;
    int disparosRafaga;
    float timeRafagas;
    [SerializeField] float waitRafaga;
    public GameObject disparoBoss;
    void Start()
    {

        playerRef = GameObject.FindGameObjectWithTag("Player");
        bbh = gameObject.GetComponent<BossBehaviour>();
        nav = gameObject.GetComponent<NavMeshAgent>();
        disparosCambio = Random.Range(disparosMin, disparosMax);
    }
    void Update()
    {
        nav.SetDestination(new Vector3(playerRef.transform.position.x, transform.position.y, playerRef.transform.position.z));
        if (disparosRealizados >= disparosCambio)
        {
            bbh.vulnerable = true;
            bbh.vulnerableMissiles = true;
        }
        distToPlayer = Vector3.Distance(transform.position, new Vector3(playerRef.transform.position.x, transform.position.y, playerRef.transform.position.z));
        if (distToPlayer < maxCloseToPlayer)
        {
            nav.speed = 0f;
        }
        else 
        {
            nav.speed = bbh.normalSpeed;
        }
        LookPlayer();
        Shoot(cadence);
    }
    void LookPlayer()
    {
        Vector3 lookVector = playerRef.transform.position - transform.position;
        lookVector.y = 0f;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1f);
    }
    void Shoot(float refresh)
    {
        if (timeRafagas >= waitRafaga)
        {
            if (disparosRafaga < disparosPorRafaga)
            {
                timeShoot += Time.deltaTime;
                if (timeShoot >= refresh)
                {
                    timeShoot = 0f;
                    disparosRealizados++;
                    disparosRafaga++;
                    float randomRot = Random.Range(shootPoint.transform.rotation.y - 0.4f, shootPoint.transform.rotation.y + 0.4f);
                    Instantiate(bossBullet, shootPoint.transform.position, new Quaternion(shootPoint.transform.rotation.x, randomRot, shootPoint.transform.rotation.z, shootPoint.transform.rotation.w));
                    NuevoSonido(disparoBoss, this.transform.position, 1f);
                }
            }
            else
            {
                disparosRafaga = 0;
                timeRafagas = 0f;
            }
        }
        else
        {
            timeRafagas += Time.deltaTime;
        }
        
        
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }
}
