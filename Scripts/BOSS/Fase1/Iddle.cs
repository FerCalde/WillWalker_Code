using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Iddle : MonoBehaviour
{
    BossBehaviour bbh;
    NavMeshAgent nav;
    [SerializeField] float timeNoAcction;
    float time;
    void Start()
    {
        bbh = gameObject.GetComponent<BossBehaviour>();
        nav = gameObject.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        time += Time.deltaTime;
        if(timeNoAcction <= time)
        {
            bbh.vulnerable = false;
        }
    }
}
