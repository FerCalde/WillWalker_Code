using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootMissiles : MonoBehaviour
{
    [SerializeField] float cadence = 0.5f;
    float timeShoot = 0f;
    BossBehaviour bbh;
    NavMeshAgent nav;
    [SerializeField] int cantidadMisilesQseLanzan;
    [SerializeField] GameObject shootPoint;
    [SerializeField] GameObject missiles;
    int disparosRealizados = 0;
    [SerializeField] float tiempoMisil;
    float time = 0f;
    GameObject playerRef;
    public GameObject misilesBoss;
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        bbh = gameObject.GetComponent<BossBehaviour>();
        nav = gameObject.GetComponent<NavMeshAgent>();
        nav.speed = 0f;
    }
    void Update()
    {
        if (disparosRealizados <= cantidadMisilesQseLanzan)
        {
            Shoot(cadence);
        }
        if(disparosRealizados >= cantidadMisilesQseLanzan)
        {
            
            time += Time.deltaTime;
            if(time >= tiempoMisil)
            {
                Debug.Log("eueueueueue");
                bbh.vulnerableMissiles = false;
                bbh.carreritas = true;
            }
        }
        LookPlayer();


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
        timeShoot += Time.deltaTime;
        if (timeShoot >= refresh)
        {
            NuevoSonido(misilesBoss, this.transform.position, 1f);
            disparosRealizados++;
            GameObject misil = Instantiate(missiles, shootPoint.transform.position, shootPoint.transform.rotation);
            misil.GetComponent<GuideMissile>().timeToExplote = tiempoMisil;
            timeShoot = 0f;
        }
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }

}
