using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppDronIdle : MonoBehaviour
{
    SupportDron refEnemy;


    [SerializeField] float speed=10;
    // Start is called before the first frame update
    void Start()
    {
        
        refEnemy = GetComponent<SupportDron>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, refEnemy.alturaBase, transform.position.z), speed * Time.deltaTime);

        if (transform.position.y >= refEnemy.alturaBase)
        {
            refEnemy.stateMachine.ChangeState("Chase");
        }
        //transform.position = Vector3.MoveTowards(starPos, new Vector3(transform.position.x, refEnemy.alturaBase, transform.position.z),tiempoPreparar*Time.deltaTime);
        //t = Time.deltaTime / tiempoPreparar;
        //transform.position = new Vector3(transform.position.x, Mathf.Lerp(starPosY, refEnemy.alturaBase, t),transform.position.z);
        //if (t>=1)
        //{
        //    refEnemy.stateMachine.ChangeState("Chase");
        //}
    }
}
