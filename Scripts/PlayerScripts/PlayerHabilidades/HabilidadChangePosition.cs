using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadChangePosition : HabilidadClase
{
    [SerializeField] float speedSpectre = 2f;
    [SerializeField] float radiusEnemyDetection = 2.5f;
    [SerializeField] float maxDist = 10f;
    [SerializeField] Transform castTP;
    [SerializeField] GameObject CastCheck;
    RaycastHit hit;
    int layerEnemies;
    Transform playerPos;
    Vector3 enemyPos;
    [SerializeField] GameObject enemyChanger;
    [SerializeField] GameObject explosionElectrica;
    Mov mov;
    public GameObject sonidoRayos;

    [SerializeField] bool enemyTocado = false;
    void Start()
    {
        mov = GetComponent<Mov>();
        layerEnemies = 1 << LayerMask.NameToLayer("Enemy");
    }

    protected override void Update()
    {
        tiempoCooldownActual -= Time.deltaTime;
        if (tiempoCooldownActual <= 0)
        {
            tiempoCooldownActual = 0;
        }
        if (isActiveHability == true)
        {
            float dist = Vector3.Distance(transform.position, enemyPos);
            if (dist <= 2f)
            {
                DesactivarEfecto();
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(enemyPos.x, transform.position.y, enemyPos.z), speedSpectre * Time.deltaTime);
            }
        }

        tiempoDuracionActivaActual += Time.deltaTime;
        /*Debug.DrawRay(castTP.position, castTP.forward, Color.red, 8);
        if (Physics.SphereCast(castTP.position, radiusEnemyDetection, castTP.forward, out hit, maxDist))
        {
            Debug.Log(hit.transform.gameObject);

            if (hit.collider.GetComponent<VidaEnemyBase>() != null)
            {
                enemyChanger = hit.transform.gameObject;
            }
            else
            {
                enemyChanger = null;
            }


        }
        else
        {
            enemyChanger = null;
        }*/

    }

    /*protected override void AplicarEfecto()
    {
        //guardo las variables de las transform cuando detecto que hay un enemigo en rango
        playerPos.position = this.transform.position; 
        enemyPos.position = hit.transform.position;
        enemyChanger = hit.transform.gameObject;
        TeleportChange();
    }*/

    public override void Activar()
    {
        if (isHabilityUnlocked)//ArbolHabilidadChecker
        {

            if (tiempoCooldownActual <= 0)
            {
                if (enemyChanger != null)
                {
                    NuevoSonido(sonidoRayos, this.transform.position, 4f);
                    tiempoCooldownActual = tiempoCooldownMaximo;
                    playerPos = this.transform;
                    enemyPos = enemyChanger.transform.position;
                    tiempoDuracionActivaActual = 0;
                    isActiveHability = true;
                    TeleportChange();


                }

                /* if (Physics.SphereCast(transform.position, radiusEnemyDetection, transform.forward, out hit, maxDist, layerEnemies))
                 {
                     if (hit.collider.GetComponent<VidaEnemyBase>() != null)
                     {
                         playerPos.position = this.transform.position; //guardo las variables de las transform cuando detecto que hay un enemigo en rango
                         enemyPos.position = hit.transform.position;
                         enemyChanger = hit.transform.gameObject;
                         TeleportChange();
                     }
                 }*/
            }
            
        }
    }

    void TeleportChange()
    {
        print("Telepor");
        if (habilityCostTime)
        {
            GetComponent<VidaJugador>().HabilityDamage(costeHabilidadUtilizar); //HABILIDAD CUESTA TIEMPO
        }
        mov.ActivarDesactivarMovimiento(false);
        //this.transform.Translate(enemyPos.position);
        //this.transform.position = enemyPos.position;
        enemyChanger.transform.position = playerPos.position;
        //Instantiate(explosionElectrica, playerPos.position, playerPos.rotation);

    }
    public void EnemyGPS(GameObject goEnemy)
    {
        if (Physics.Raycast(castTP.position, goEnemy.transform.position - castTP.position, out hit, maxDist))
        {
            if (isActiveHability == false && hit.collider.gameObject == goEnemy)
            {
                enemyChanger = goEnemy;
            }
            else
            {
                enemyChanger = null;
            }
        }
        else
        {
            enemyChanger = null;
        }
       

        //enemyPos.position = goEnemy.transform.position;
    }
    public void EnemyNoGPS()
    {
        enemyChanger = null;
    }
    void DesactivarEfecto()
    {
        Instantiate(explosionElectrica, transform.position, transform.rotation);
        isActiveHability = false;
        mov.ActivarDesactivarMovimiento(true);
        //enemyPos = null;
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }
}
