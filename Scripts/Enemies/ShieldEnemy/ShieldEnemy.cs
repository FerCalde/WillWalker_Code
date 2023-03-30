﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShieldEnemy : MonoBehaviour
{
    StateMachine stMachine;
    public List<GameObject> EnemiesCover;
    public Vector3 protectPoint;
    VidaEnemyBase vida;
    public ShieldWork shield;
    [SerializeField] GameObject shieldEntero;
    [SerializeField] GameObject tasher;
    Collider col;
    private NavMeshAgent agente;
    AplicarEfectosTemporales efectos;
    void Start()
    {
        efectos = GetComponent<AplicarEfectosTemporales>();
        vida = GetComponent<VidaEnemyBase>();
        stMachine = GetComponent<StateMachine>();
        col = GetComponent<Collider>();
        agente = transform.GetComponent<NavMeshAgent>();
    }
    void Update()
    {

        if (vida.VidaActual <= 0)
        {
            shieldEntero.SetActive(false);
            stMachine.ChangeState("Death");
            col.enabled = false;
            tasher.SetActive(false);
            agente.isStopped = true;
        }
        else
        {
            col.enabled = true;
            if (!efectos.tashed)
            {
                if (shield.escudoReset == false)
                {
                    shieldEntero.SetActive(true);
                    if (EnemiesCover.Count > 0)
                    {
                        if (EnemiesCover[0] != null)
                        {
                            protectPoint = EnemiesCover[0].transform.position;
                            stMachine.ChangeState("Patrol");
                        }
                        else
                        {
                            stMachine.ChangeState("Iddle");
                            if (EnemiesCover.Count > 0)
                            {
                                EnemiesCover.RemoveAt(0);
                            }

                        }
                    }
                    else
                    {
                        stMachine.ChangeState("Iddle");
                    }

                }
                else
                {
                    stMachine.ChangeState("Shoot");
                }
            }
            else
            {
                shieldEntero.SetActive(false);
                stMachine.ChangeState("Iddle");
            }

            
           
            
        } 
    }
}
