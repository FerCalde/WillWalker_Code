using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppDronChase : MonoBehaviour
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

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(refEnemy.targetToSupp.transform.position.x, refEnemy.alturaBase, refEnemy.targetToSupp.transform.position.z), refEnemy.speedChase * Time.deltaTime);
        if (Vector3.Distance(transform.position, refEnemy.targetToSupp.transform.position) <= refEnemy.distance2Heal)
        {
            refEnemy.stateMachine.ChangeState("GoToHeal");
        }

    }
}
