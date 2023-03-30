using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocoChase : MonoBehaviour
{
    EnemyLoco loco;
    bool canMolotov = true;
    public GameObject molotov;
    public GameObject manoPoint;
    public float multiplier;
    public float minDistanceToPlayer;
    bool enVision;
    float timer;
    [SerializeField] GameObject soniDisparo;
   
    public float distance2Shoot;
    //public float distance2Molo;
    //Start is called before the first frame update
    void Start()
    {
        loco = GetComponent<EnemyLoco>();
     
        if (loco.oneMollyRewind)
        {
            if (!loco.oneMollyRewind)
            {
                if (!GetComponent<AplicarEfectosTemporales>().tashed)
                {
                    if (canMolotov)
                    {
                        Instantiate(molotov, manoPoint.transform.position, Quaternion.identity);
                        canMolotov = false;
                    }
                }
             
                loco.mollyRewindAlready = true;
            }
            
        }
        else
        {
            if (!GetComponent<AplicarEfectosTemporales>().tashed)
            {
                if (canMolotov)
                {
                    Instantiate(molotov, manoPoint.transform.position, Quaternion.identity);
                    canMolotov = false;
                }
            }
          
        }
        
        loco.agente.isStopped = false;
        loco.miAnim.SetTrigger("Shoot");
        loco.miAnim.SetTrigger("run");
        loco.miAnim.ResetTrigger("Idle");
        loco.miAnim.ResetTrigger("muerte");
    }

    // Update is called once per frame
    void Update()
    {

        //loco.agente.SetDestination(loco.player.transform.position);

        float hearingDistance = Vector3.Distance(transform.position, loco.player.transform.position);
        //Debug.Log(hearingDistance);
        if (hearingDistance > minDistanceToPlayer)
        {

            //Debug.Log("Avanza");
            GetComponent<LocoShoot>().Shoot();
            loco.agente.speed = 3.5f;
            loco.agente.SetDestination(loco.player.transform.position);


        }
        if (hearingDistance < minDistanceToPlayer)
        {
           
            //Debug.Log("Retrocede");
            loco.agente.speed = 4.5f;
            Vector3 runTo = transform.position + (Vector3.Normalize(transform.position - loco.player.transform.position) * multiplier);
            //debugEmptyGameObject.transform.position = new Vector3(runTo.x, transform.position.y, runTo.z);
            loco.agente.SetDestination(runTo/*new Vector3(runTo.x, transform.position.y, runTo.z)*/); 
            //Debug.Log(runTo); Preguntar si se cambia esto a fuincionalidad que pilla un punto y va huyendo al tiurar el molotov y una rafaga. Meter estado de cargando molotov? 
            //agente.speed = 0;

        }


    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }

    //void VerPlayer()
    //{
    //    RaycastHit hit;
    //    if(Physics.Raycast(loco.raycastSpot.transform.position, transform.forward, out hit, Mathf.Infinity))
    //    {
    //        if (hit.collider.gameObject.CompareTag("ModeloPlayer"))
    //        {
    //            enVision = true;
    //        }
    //        else
    //        {
    //            enVision = false;
    //        }
    //    }
    //    Debug.DrawRay(loco.raycastSpot.transform.position, transform.forward);
    //    Debug.Log(hit.collider.name);
    //    if (!enVision)
    //    {
    //        timer += Time.deltaTime;
    //    }
    //    else
    //    {
    //        timer = 0;
    //    }
    //    if (timer >= tiempoVisión)
    //    {
    //        loco.lastSeenPlayer = hit.transform.position;
    //        loco.stateMachine.ChangeState("Retroceder");
    //    }
    //}
}
