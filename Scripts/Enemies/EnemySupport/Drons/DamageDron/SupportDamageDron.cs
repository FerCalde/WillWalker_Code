using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportDamageDron : MonoBehaviour
{
    Mov playerRef;
    [HideInInspector] public StateMachine stateManager;
    [HideInInspector] public Animator miAnim;

    public bool ready2Go; //Poner en true cuando se termine de hacer elk vfx de la iniciación. De momento pongo un timer

    // Start is called before the first frame update
    void Start()
    {
        playerRef = FindObjectOfType<Mov>();
        stateManager = GetComponent<StateMachine>();
        miAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stateManager.currentState.Contains("Idle"))
        {
            MirarPlayer();
        }
        if (GetComponent<VidaEnemyBase>().VidaActual <= 0)
        {
            stateManager.ChangeState("Death");
        }
        
    }
    void MirarPlayer()
    {

        Vector3 lookVector = playerRef.transform.position - transform.position;
        lookVector.y = 0;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.05f);
    }
}
