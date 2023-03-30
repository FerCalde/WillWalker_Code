using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SupportTorretaActivada : MonoBehaviour
{
    SupportTorreta supportEnemy;
    StateMachine stateManager;
    int layerMask = 1 << 8 | 1 << 9;
    public GameObject dronSupport;
    public GameObject dronAttack;
    public GameObject trampillaSupport;
    public GameObject trampillaAttack;
    VidaEnemyBase[] enemies;
    public GameObject dronInstance;
    Mov playerRef;
    public GameObject SonidoActivacion;
    int dronesActuales;


    float distanciaIn;
    public bool buscaAlgo = false;
    bool primerValido = false;

    // Start is called before the first frame update
    void Start()
    {
        supportEnemy = GetComponent<SupportTorreta>();
        stateManager = GetComponent<StateMachine>();
        enemies=FindObjectsOfType<VidaEnemyBase>();
        playerRef = FindObjectOfType<Mov>();
        enemies = enemies.OrderBy((d) => (d.transform.position - transform.position).sqrMagnitude).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(enemies);
        for (int i = 0; i < supportEnemy.totalDronsLimit; i++)
        {
            
            if (Vector3.Distance(supportEnemy.centro.transform.position, playerRef.transform.position) < supportEnemy.rango && !enemies[i].supported && enemies[i].GetComponent<SupportDron>()==null && enemies[i].GetComponent<SupportTorreta>() == null && dronesActuales<supportEnemy.totalDronsLimit)
            {
                
                dronInstance=Instantiate(dronSupport, trampillaSupport.transform.position, Quaternion.identity);

                //if (!primerValido)
                //{
                //    distanciaIn = Vector3.Distance(transform.position, enemies[i].transform.position);
                //    primerValido = true;
                //}
                //if (Vector3.Distance(transform.position, enemies[i].transform.position) <= distanciaIn)
                //{
                //    dronInstance.GetComponent<SupportDron>().targetToSupp = enemies[i].gameObject;
                //}
                dronInstance.GetComponent<SupportDron>().targetToSupp=enemies[i].gameObject;
                dronInstance.GetComponent<SupportDron>().colmena = gameObject;

                enemies[i].supported = true;
                dronesActuales++;
                if (dronesActuales >= supportEnemy.totalDronsLimit)
                {
                    supportEnemy.empty = true;
                }
                NuevoSonido(SonidoActivacion, transform.position, 0.5f);
            }
       
        }
        //if (Vector3.Distance(supportEnemy.centro.transform.position,playerRef.transform.position) < supportEnemy.rango && !supportEnemy.attackDronON)
        //{
        //    Debug.Log("entra a instanciacion");
        //    supportEnemy.dronContainer = Instantiate(dronAttack, trampillaAttack.transform.position, Quaternion.identity);
        //    supportEnemy.attackDronON = true;
        //    NuevoSonido(SonidoActivacion, transform.position, 0.5f);
        //}
        //stateManager.ChangeState("Idle");

        //if (enemies == null)
        //{
        //    Destroy(this.gameObject);
        //}
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }
    //void FixedUpdate()
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(transform.position, supportEnemy.rango, layerMask);
    //    if (hitColliders != null)
    //    {
    //        for (int i = 0; i < hitColliders.Length; i++)
    //        {
    //            if (hitColliders[i].gameObject.layer == 8 && !supportEnemy.attackDronON)
    //            {
    //                supportEnemy.dronContainer = Instantiate(dronAttack, trampillaAttack.transform.position, Quaternion.identity);
    //                supportEnemy.attackDronON = true;
    //            }
    //            if (hitColliders[i].gameObject.layer == 9)
    //            {
    //                supportEnemy.dronContainer = Instantiate(dronSupport, trampillaSupport.transform.position, Quaternion.identity);
    //            }
    //        }
    //    }

    //}
}
