using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppDronGoToHeal : MonoBehaviour
{
    SupportDron refEnemy;
   

    // Start is called before the first frame update
    void Start()
    {
        refEnemy = GetComponent<SupportDron>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(refEnemy.targetToSupp.transform.position.x, refEnemy.alturaCurar, refEnemy.targetToSupp.transform.position.z), refEnemy.speedChase * Time.deltaTime);
        if (transform.position.y >= refEnemy.alturaCurar)
        {
            
            refEnemy.stateMachine.ChangeState("Healing");
            
        }
      
    }
}
