using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossBehaviour : MonoBehaviour
{
    public int fase = 1;
    NavMeshAgent nav;
    public float normalSpeed = 3.5f;
    public float acelerateSpeed = 7f;
    [SerializeField] float actualSpeed;
    public Animator anim;

    /*[HideInInspector]*/ public bool combateIniciado = false;
    StateMachine stM;
    [SerializeField] string actualState;
    [HideInInspector] public bool vulnerable = false;
    [HideInInspector] public bool vulnerableMissiles = false;
    [HideInInspector] public bool carreritas = false;
    [HideInInspector] public bool mortero = false;
    [HideInInspector] public bool muerte = false;
    [SerializeField] AudioSource cmpAudioSource;
    [SerializeField] AudioClip audioClipPasos;
    Vector3 moveDir = Vector3.zero;

    [SerializeField] GameObject shields;
    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        stM = gameObject.GetComponent<StateMachine>();
        shields.SetActive(false);
    }
    void Update()
    {
        Debug.Log(stM.currentState);
        actualSpeed = nav.speed;
        actualState = stM.currentState;
        if (fase > 0)
        {
            if (combateIniciado)
            {
                if (muerte == false)
                {
                    if (vulnerable == false)
                    {
                        anim.SetTrigger("Movimiento");
                        stM.ChangeState("Chase&Shoot");
                        shields.SetActive(true);
                    }
                    else
                    {

                        if (vulnerableMissiles)
                        {
                            shields.SetActive(false);
                            anim.SetTrigger("Misiles");
                            stM.ChangeState("ShootMissiles");
                        }
                        else
                        {

                            if (fase > 1 && carreritas == true)
                            {
                                shields.SetActive(false);
                                anim.SetTrigger("Carga");
                                stM.ChangeState("RunToPlayer");
                            }
                            else if (fase > 2 && mortero)
                            {
                                shields.SetActive(true);
                                anim.SetTrigger("Idle");
                                stM.ChangeState("Mortero");
                            }
                            else
                            {
                                shields.SetActive(false);
                                anim.SetTrigger("Idle");
                                stM.ChangeState("Iddle");
                                
                            }
                        }
                        
                    }
                }
                else
                {
                    nav.speed = 0f;
                    anim.ResetTrigger("Movimiento");
                    anim.ResetTrigger("Misiles");
                    anim.ResetTrigger("Carga");
                    anim.ResetTrigger("Idle");
                    stM.ChangeState("Muerte");
                }
            }
        }
        
    }
   public void AnimEventStep()
    {
        if (nav.speed >= 0.3f)
        {
            cmpAudioSource.clip = audioClipPasos;
            cmpAudioSource.Play();
        }

    }
}
