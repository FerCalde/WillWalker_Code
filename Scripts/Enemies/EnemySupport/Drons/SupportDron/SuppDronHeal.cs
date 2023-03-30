using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppDronHeal : MonoBehaviour
{
    float timer;
    SupportDron refEnemy;
    [SerializeField] GameObject vfxCurar;

    // Start is called before the first frame update
    void Start()
    {
        refEnemy = GetComponent<SupportDron>();
    }
    // Update is called once per frame
    void Update()//poner un escudito tambien?? ver despues del playtesting.
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(refEnemy.targetToSupp.transform.position.x, refEnemy.alturaCurar, refEnemy.targetToSupp.transform.position.z), refEnemy.speedChase * Time.deltaTime);


        timer += Time.deltaTime; //CURACION FUNCIONALIDAD
        if (timer >= refEnemy.intervaloCuracion)
        {
            if (refEnemy.targetToSupp.GetComponent<VidaEnemyBase>().VidaActual + refEnemy.curacion < refEnemy.targetToSupp.GetComponent<VidaEnemyBase>().VidaMaxima)
            {
                vfxCurar.SetActive(true);
                refEnemy.targetToSupp.GetComponent<VidaEnemyBase>().VidaActual += refEnemy.curacion;
              

            }
            else
            {
                refEnemy.targetToSupp.GetComponent<VidaEnemyBase>().VidaActual = refEnemy.targetToSupp.GetComponent<VidaEnemyBase>().VidaMaxima;
                vfxCurar.SetActive(false);
            }
            timer = 0;
        }
    }
}
