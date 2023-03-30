using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaAttack : MonoBehaviour
{
    [HideInInspector] public bool parryUnlock = false;
    [SerializeField] float speedDash;
    HabilidadKatana habilidad;
    Mov movimiento;
    [SerializeField]Transform salidaDash;
    [SerializeField] Transform limitDashEspada;
    [SerializeField] GameObject dashEspada;
    bool attack = false;
    bool block = false;
    [SerializeField] Root rot;
    [SerializeField] GameObject blockPose;
    [SerializeField] float timerBlock = 0.2f;
    float timerAttack = 0.1f;
    float time = 0f;

    [SerializeField] float cooldownAttack = 2f;
    float timeLastAttack = 0f;
    bool hadAttack = false;

    [SerializeField] float cooldownBlock = 1f;
    float timeLastBlock = 0f;
    bool hadBlock = false;

    [SerializeField] GameObject sfxKatanaAtack;
    [SerializeField] GameObject sfxKatanaDefend;
    void Start()
    {
        movimiento = GetComponent<Mov>();
        habilidad = GetComponent<HabilidadKatana>();
        blockPose.SetActive(false);
    }
    void Update()
    {
        if (attack == true)
        {
            time += Time.deltaTime;
            if (time >= timerAttack)
            {
                PararAttack();
                attack = false;
            }
            else
            {
                Attack();
            }
        }
        if (block == true)
        {
            time += Time.deltaTime;
            if (time >= timerBlock)
            {
                PararDefensa();
                block = false;
            }
        }
        if (hadAttack == true)
        {
            timeLastAttack += Time.deltaTime;
            if (timeLastAttack >= cooldownAttack)
            {
                hadAttack = false;
            }
        }
        if (hadBlock == true)
        {
            timeLastBlock += Time.deltaTime;
            if (timeLastBlock >= cooldownBlock)
            {
                hadBlock = false;
            }
        }
        if (habilidad.katanaHabilidad == true)
        {
            if (!attack && !block)
            {
                if (hadAttack == false)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        time = 0f;
                        attack = true;
                        
                    }
                }
                
            }
            if (parryUnlock == true)
            {
                if (!attack && !block)
                {
                    if (hadBlock == false)
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse1))
                        {
                            time = 0f;
                            block = true;
                            Defense();

                        }
                    }
                }
            }
            
        }
    }
    void Attack()
    {
        
        timeLastAttack = 0f;
        hadAttack = true;
        
        NuevoSonido(sfxKatanaAtack, this.transform.position, 2f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(limitDashEspada.position.x, transform.position.y, limitDashEspada.position.z), speedDash * Time.deltaTime);
        movimiento.canMove = false;
        rot.canRot = false;
    }
    void PararAttack()
    {
        GetComponent<Animator>().SetTrigger("Shooting");
        Instantiate(dashEspada, salidaDash.position, salidaDash.rotation);
        movimiento.canMove = true;
        rot.canRot = true;
    }
    void Defense()
    {
        timeLastBlock = 0f;
        hadBlock = true;
        GetComponent<Animator>().SetTrigger("Defense");
        movimiento.canMove = false;
        blockPose.SetActive(true);
        NuevoSonido(sfxKatanaDefend, this.transform.position, 2f);
    }
    void PararDefensa()
    {
        movimiento.canMove = true;
        blockPose.SetActive(false);
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }
}
