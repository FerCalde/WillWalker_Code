using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportTorretaIdle : MonoBehaviour
{
    SupportTorreta supportEnemy;
    StateMachine stateManager;
    int layerMask = 1 << 8 | 1 << 9;
    bool activable = false;
    


    // Start is called before the first frame update
    void Start()
    {
        supportEnemy = GetComponent<SupportTorreta>();
        stateManager = GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(supportEnemy.centro.transform.position, supportEnemy.rango,layerMask);



        if (hitColliders.Length != 0&& !supportEnemy.empty)
        {
            stateManager.ChangeState("Activada");
            
            //Debug.Log("Detectado");

            //for (int i = 0; i < hitColliders.Length; i++)
            //{
            //    if (!hitColliders[i].GetComponent<VidaEnemyBase>().supported)
            //    {
            //        activable = true;
            //    }
            //}
            //if (activable)
            //{
                
            //}
        }
   
    }
    //void OnDrawGizmosSelected()
    //{
    //    // Draw a yellow sphere at the transform's position
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(supportEnemy.centro.transform.position, supportEnemy.rango);
    //}
}
