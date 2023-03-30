using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDronIdle : MonoBehaviour
{
    SupportDamageDron refEnemy;
    float timer;
    [SerializeField] float time2Chase;
    // Start is called before the first frame update
    void Start()
    {

        refEnemy = GetComponent<SupportDamageDron>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time2Chase)
        {
            refEnemy.stateManager.ChangeState("Chase");
        }
    }
}
