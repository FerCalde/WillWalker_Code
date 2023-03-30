using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocoRetroceder : MonoBehaviour
{
    EnemyLoco loco;
    
    // Start is called before the first frame update
    void Start()
    {
        loco = GetComponent<EnemyLoco>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(loco.raycastSpot.transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("ModeloPlayer"))
            {
                loco.stateMachine.ChangeState("Chase");
            }
            else
            {
                loco.agente.SetDestination(loco.lastSeenPlayer);
            }
            
        }
        if (loco.agente.remainingDistance < 0.1f && !loco.agente.pathPending)
        {
            loco.stateMachine.ChangeState("Idle");
        }
    }
}
