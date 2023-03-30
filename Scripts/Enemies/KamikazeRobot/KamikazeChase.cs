using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KamikazeChase : MonoBehaviour
{
    NavMeshAgent kamiNav;
    GameObject player;
    Kamikaze kamiBehaviour;
    VidaEnemyBase vida;
    Animator miAnim;

    void Start()
    {
        miAnim = GetComponent<Animator>();
        Animaciones();
        vida = GetComponent<VidaEnemyBase>();
        kamiNav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        kamiBehaviour = GetComponent<Kamikaze>();
        kamiNav.isStopped = false;
    }
    void Animaciones()
    {
        miAnim.ResetTrigger("Idle");
        miAnim.SetTrigger("Chase");
        miAnim.ResetTrigger("Explote");
    }

    // Update is called once per frame
    void Update()
    {
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (kamiBehaviour.distanceToExplote > distanceToPlayer)
        {
            if (!RewindManagment.isRewinding)
            {
                vida.TakeDamage(180f);
                kamiBehaviour.exploteByDist = true;
            }
            
        }
        else
        {
            kamiNav.SetDestination(player.transform.position);
            //Debug.Log("FollowPlayer");
        }
    }
}
