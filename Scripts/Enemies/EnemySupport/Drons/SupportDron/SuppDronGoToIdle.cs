using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppDronGoToIdle : MonoBehaviour
{
    SupportDron refEnemy;
    public float speed=5;
    [SerializeField]VidaEnemyBase[] enemies;
    float distanciaIn;
    public bool buscaAlgo=false;
    bool primerValido=false;

    // Start is called before the first frame update
    void Start()
    {
        refEnemy = GetComponent<SupportDron>();
        enemies = FindObjectsOfType<VidaEnemyBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (refEnemy.colmena==null)
        {
            Destroy(gameObject);
        }
        else
        {
            for (int i = 0; i < enemies.Length; i++)
            {

                if (enemies[i] != null && enemies[i].GetComponent<SupportDron>() == null && enemies[i].GetComponent<SupportTorreta>() == null && enemies[i].gameObject.activeSelf && !enemies[i].GetComponent<VidaEnemyBase>().supported)
                {
                    buscaAlgo = true;
                }
            }
            if (!buscaAlgo)
            {
                this.gameObject.SetActive(false);
                //refEnemy.stateMachine.ChangeState("Destroy");
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, refEnemy.alturaBase, transform.position.z), speed * Time.deltaTime);
                if (transform.position.y <= refEnemy.alturaBase)
                {
                    BuscarObjetivo();
                    refEnemy.stateMachine.ChangeState("Chase");
                }
            }

        }


    }
    void BuscarObjetivo()
    {

        Debug.Log(enemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            if (!enemies[i].GetComponent<VidaEnemyBase>().supported&& enemies[i].GetComponent<VidaEnemyBase>().VidaActual>0&& enemies[i].GetComponent<SupportDron>() == null && enemies[i].GetComponent<SupportTorreta>() == null)
            {
                if (!primerValido)
                {
                    distanciaIn = Vector3.Distance(transform.position, enemies[i].transform.position);
                    primerValido = true;
                }
                if (Vector3.Distance(transform.position, enemies[i].transform.position) <= distanciaIn)
                {
                    refEnemy.targetToSupp = enemies[i].gameObject;
                }
            }


        }
        if (!refEnemy.targetToSupp.activeSelf)
        {
            this.gameObject.SetActive(false);
            //refEnemy.stateMachine.ChangeState("Destroy");
        }
        else
        {
            refEnemy.targetToSupp.GetComponent<VidaEnemyBase>().supported = true;
        }
    }
}
