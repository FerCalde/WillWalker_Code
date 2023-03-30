using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopEnemy : MonoBehaviour
{
    GameObject playerRef;
    [SerializeField] bool onlyChase = false;
    public float distancePlayer;
    public float distanceMin;
    public float distance2Chase;
    public float distance2Shoot;
    public float distance2Retreat;
    [HideInInspector]public Vector3 posInicial;
    StateMachine refStateManager;
    public int m_lastPatrolPoint = -1;
    private UnityEngine.AI.NavMeshAgent agente;

    public float cantidadConoVision;
    public float angle2Player;
    public bool viendoPlayer;
    public bool identificadoPlayer;
    [SerializeField][Tooltip("Entre 0 y 1")] float velocidadRotacion;
    VidaEnemyBase vidaEnemy;
    Collider col;
    Animator miAnim;
    AplicarEfectosTemporales efectos;
    
    // Start is called before the first frame update
    void Start()
    {
        efectos = GetComponent<AplicarEfectosTemporales>();
        playerRef = GameManager.Instance.goPlayer;
        refStateManager = GetComponent<StateMachine>();
        vidaEnemy = GetComponent<VidaEnemyBase>();
        posInicial = transform.position;
        col = GetComponent<Collider>();
        agente = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        miAnim = GetComponent<Animator>();
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
            distancePlayer = Vector3.Distance(playerRef.transform.position, transform.position);
            miAnim.SetFloat("Blend", agente.velocity.magnitude / agente.speed);


            if (vidaEnemy.VidaActual <= 0)
            {
                refStateManager.ChangeState("Death");
                col.enabled = false;
                agente.isStopped = true;
            }
            else
            {
                col.enabled = true;
                agente.enabled = true;
                if (!efectos.tashed)
                {
                    if (!refStateManager.currentState.Contains("Patrol") && !refStateManager.currentState.Contains("Idle"))
                    {
                        Vector3 lookVector = playerRef.transform.position - transform.position;
                        lookVector.y = 0;
                        Quaternion rot = Quaternion.LookRotation(lookVector);
                        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1f);
                        //Debug.Log("X= " + transform.rotation.x + "y= " + transform.rotation.y + "z= " + transform.rotation.z);
                        //Debug.DrawLine(this.transform.position,playerRef.transform.position);
                    }
                    if (onlyChase)
                    {
                        viendoPlayer = true;
                    }
                    else
                    {
                        FOV(cantidadConoVision);
                    }
                    
                }
                else
                {
                    refStateManager.ChangeState("Idle");
                }


            }
        }

    }
    public void FOV(float coneLength )
    {
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green, 8);
        Vector3 lookVector = playerRef.transform.position - transform.position;
        angle2Player = Vector3.Angle(lookVector, transform.forward*50);
        if (angle2Player < coneLength)
        {
            viendoPlayer = true;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 8))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance*200, Color.yellow);
                identificadoPlayer = true;
            }
            else
            {
                if (distancePlayer <= distanceMin)
                {
                    identificadoPlayer = true;
                }
                else
                {
                    identificadoPlayer = false;
                }
                
            }
        }
        else
        {
            if(distancePlayer <= distanceMin)
            {
                viendoPlayer = true;
            }
            else
            {
                viendoPlayer = false;
            }
            
        }
   

    }
    public void endHit()
    {
        refStateManager.ChangeState("Chase");
    }
    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.gameObject.CompareTag("BalaPlayer"))
    //    {
    //        vida -= hit.gameObject.GetComponent<ShotBehavior>().damage;
    //        Destroy(hit.gameObject);
    //    }
    //    Debug.Log("entraColision");
    //}
}
