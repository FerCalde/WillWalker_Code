using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDronChase : MonoBehaviour
{
    private Transform playerTransform;
    private UnityEngine.AI.NavMeshAgent agente;
    public float minDistanceToPlayer;
    public float multiplier;

    SupportDamageDron refEnemy;
    Animator miAnim;
    public GameObject debugEmptyGameObject;



    // Start is called before the first frame update
    void Start()
    {
        refEnemy = GetComponent<SupportDamageDron>();

        agente = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerTransform = FindObjectOfType<Mov>().transform;
        miAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
       
        float hearingDistance = Vector3.Distance(transform.position, playerTransform.position);
        //Debug.Log(hearingDistance);
        if (hearingDistance > minDistanceToPlayer)
        {
            agente.speed = 6;
            agente.SetDestination(playerTransform.position);


        }
        if (hearingDistance < minDistanceToPlayer)
        {
            Vector3 runTo = transform.position + ((transform.position - playerTransform.position) * multiplier);
            //debugEmptyGameObject.transform.position = new Vector3(runTo.x, transform.position.y, runTo.z);
            agente.SetDestination(new Vector3(runTo.x,transform.position.y,runTo.z));
            //Debug.Log(runTo);
            //agente.speed = 0;
          
        }
  
        //if (hearingDistance <= minDistanceToPlayer- idleRange && hearingDistance <= minDistanceToPlayer + idleRange)
        //{
        //    agente.speed = 1;
        //}
        //if(hearingDistance > minDistanceToPlayer + idleRange)
        //{
        //    agente.speed = 3.5f;
        //    agente.SetDestination(playerTransform.position);


        //}
        //if (hearingDistance < minDistanceToPlayer - idleRange)
        //{
        //    agente.speed = 4.5f;
        //    agente.isStopped = false;
        //    Vector3 runTo = transform.position + ((transform.position - playerTransform.position) * multiplier);

        //    agente.SetDestination(runTo);
        //}
    }



}
