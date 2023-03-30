using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportDron : MonoBehaviour
{

    [HideInInspector]public UnityEngine.AI.NavMeshAgent agente;
    public float minDistanceToEnemy;
    public float alturaBase;
    public float alturaCurar;
    public float speedChase;
    public float distance2Heal;
    public GameObject colmena;


    [HideInInspector] public Animator miAnim;

    [HideInInspector] public StateMachine stateMachine;

    public GameObject targetToSupp;
    
    public float curacion;
    public float intervaloCuracion;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        miAnim = GetComponent<Animator>();
        transform.position = new Vector3(transform.position.x, alturaBase, transform.position.z);

        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (RewindManagment.isRewinding && targetToSupp == null)
        {
            Destroy(gameObject);
        }
        //Debug.Log(Vector3.Angle(transform.forward, targetToSupp.transform.forward));
        //transform.position = new Vector3(transform.position.x, alturaBase, transform.position.z);
        if (targetToSupp != null)
        {
            MirarPlayer();
            if (targetToSupp.GetComponent<VidaEnemyBase>().VidaActual <= 0)
            {

                targetToSupp = null;
                stateMachine.ChangeState("GoToIdle");
            }
        }
        
        if (!stateMachine.currentState.Contains("Healing") && !stateMachine.currentState.Contains("GoToHeal") && colmena==null)
        {
          
            Destroy(gameObject);
        }
     

    }
    void MirarPlayer()
    {

        Vector3 lookVector = targetToSupp.transform.position - transform.position;
        lookVector.y = 0;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.05f);
    }
}
