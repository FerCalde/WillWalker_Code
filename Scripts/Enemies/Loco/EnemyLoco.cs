using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoco : MonoBehaviour
{
    [HideInInspector] public GameObject player;
    [SerializeField] Collider col;
    [HideInInspector] public StateMachine stateMachine;
    [HideInInspector] public Vector3 lastSeenPlayer;
    [HideInInspector] public UnityEngine.AI.NavMeshAgent agente;
    [HideInInspector] public Animator miAnim;
    public GameObject raycastSpot;
    [HideInInspector] public bool oneMollyRewind = false;
    [HideInInspector] public bool mollyRewindAlready = false;
    // Start is called before the first frame update
    void Awake()
    {
        //player = GameManager.Instance.goPlayer;

        stateMachine = GetComponent<StateMachine>();
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        miAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameManager.Instance.goPlayer;
        }
        else
        {
            if (RewindManagment.isRewinding == true) 
            {
                oneMollyRewind = true;
            }
            else
            {
                oneMollyRewind = false;
                mollyRewindAlready = false;
            }
            if (!GetComponent<AplicarEfectosTemporales>().tashed)
            {
                if (stateMachine.currentState.Contains("Chase"))
                {
                    MirarPlayer();
                }
                if (GetComponent<VidaEnemyBase>().VidaActual <= 0)
                {
                    col.enabled = false;
                    stateMachine.ChangeState("Death");
                }
                else
                {
                    col.enabled = true;
                }
            }

            else
            {
                stateMachine.ChangeState("Idle");
            }
        }

    }
    void MirarPlayer()
    {

        Vector3 lookVector = player.transform.position - transform.position;
        lookVector.y = 0;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.05f);
    }
}
