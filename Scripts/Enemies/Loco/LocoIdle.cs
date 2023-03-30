using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocoIdle : MonoBehaviour
{
    EnemyLoco loco;
    public float distance2Chase;
    // Start is called before the first frame update
    void Start()
    {
        loco = GetComponent<EnemyLoco>();
        loco.agente.isStopped=true;
        loco.miAnim.ResetTrigger("Shoot");
        loco.miAnim.ResetTrigger("run");
        loco.miAnim.ResetTrigger("muerte");
        loco.miAnim.SetTrigger("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (loco.player != null)
        {
            float distance2Player = Vector3.Distance(transform.position, loco.player.transform.position);
            if (distance2Player <= distance2Chase)
            {
                loco.stateMachine.ChangeState("Chase");
            }
        }
   
    }
}
