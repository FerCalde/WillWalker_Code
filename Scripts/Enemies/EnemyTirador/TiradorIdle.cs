﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiradorIdle : MonoBehaviour
{
    EnemyTirador refEnemigo;
    GameObject playerRef;
    private UnityEngine.AI.NavMeshAgent agente;
    StateMachine refStateManager;
    Animator miAnim;

 
    //// Start is called before the first frame update
    void Start()
    {
        
        refStateManager = GetComponent<StateMachine>();
        refEnemigo = GetComponent<EnemyTirador>();
        agente = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerRef = GameManager.Instance.goPlayer;
        miAnim = GetComponent<Animator>();
        agente.isStopped = true;
        Animaciones();
    }
    void Animaciones()
    {
        miAnim.SetTrigger("Idle");
        miAnim.ResetTrigger("Aiming");
        miAnim.ResetTrigger("Reload");
        miAnim.ResetTrigger("Death");
        miAnim.ResetTrigger("Shooting");
    }
    // Update is called once per frame
    void Update()
    {
        if (playerRef == null)
        {
            playerRef = GameManager.Instance.goPlayer;
        }
        else
        {
            float hearingDistance = Vector3.Distance(transform.position, playerRef.transform.position);

            if (hearingDistance < refEnemigo.distance2Apuntar)
            {
                refStateManager.ChangeState("Apuntar");

            }
        }
        //meter rotacion hacia el player si no lo hace directo.

    
        
    }

}
