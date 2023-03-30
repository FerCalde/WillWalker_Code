using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CopJoggoBonito : MonoBehaviour
{
    CopAiming refAiming;
    CopEnemy refEnemigo;
    private Transform playerTransform;
    private NavMeshAgent agente;
    [SerializeField] float distanceTiroteo;
    [SerializeField] Transform[] puntosAleatorios;
    float time;
    [SerializeField] float timeAmenaza;
    public bool amenazado = false;
    void Start()
    {
        refAiming = GetComponent<CopAiming>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        refEnemigo = GetComponent<CopEnemy>();
        agente = transform.GetComponent<NavMeshAgent>();
        
    }
    private void Update()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) >= distanceTiroteo)
        {
            agente.SetDestination(puntosAleatorios[2].position);
        }
        else
        {
            
            if (amenazado == true)
            {
                time += Time.deltaTime;
                if (time >= timeAmenaza)
                {
                    amenazado = false;
                }
            }
            else
            {
                time = 0f;
            }

        }
        
        
    }
    public void ActivarAmenza()
    {

        if (amenazado == false)
        {
            agente.isStopped = true;
            int random = Random.Range(0, 2);
            agente.isStopped = false;
            //print(random);
            agente.SetDestination(puntosAleatorios[random].position);
            
            amenazado = true;
        }
    }
    
}