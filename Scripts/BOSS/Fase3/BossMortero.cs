using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMortero : MonoBehaviour
{
    BossBehaviour boss;
    UnityEngine.AI.NavMeshAgent agent;
    GameObject playerRef;
    public GameObject prefabBulletUp;
    public GameObject prefabBulletDown;
    public GameObject firePoint;
    public float numBullets;
    public float cadencia;
    public float tiempoEspera;
    public float tiempoRecarga;
    public float alturaFall;
    bool firstBullet=true;
    bool canStart=true;
    bool waiting = true;
    float timer;
    int balasActualesUp;
    int balasActualesDown;
    [SerializeField] int balasMax;
    bool finishCicle = false;
    int currentBullets;
    bool checkCharge;
    public GameObject sonidoMisile;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        boss = gameObject.GetComponent<BossBehaviour>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      
            StartShooting();
        
    }
    void StartShooting()
    {
        
        if (balasActualesUp < numBullets &&canStart)
        {
            
            timer += Time.deltaTime;
            if (firstBullet)
            {
                Instantiate(prefabBulletUp,firePoint.transform.position, Quaternion.identity);
                NuevoSonido(sonidoMisile, this.transform.position, 2f);
                balasActualesUp++;
                currentBullets++;
                firstBullet = false;
            }
            if (timer >= cadencia)
            {
                Instantiate(prefabBulletUp, firePoint.transform.position, Quaternion.identity);
                //NuevoSonido(sonidoMisile, this.transform.position, 2f);
                balasActualesUp++;
                currentBullets++;
                timer = 0;
            }
        }
        if(balasActualesUp>=numBullets)
        {
            canStart = false;
            WaitToFall();
        }
        
    }
    void WaitToFall()
    {
        timer += Time.deltaTime;
        if (timer >= tiempoEspera&&waiting)
        {
            canStart = false;
            firstBullet = true;
            
            timer = 0;
            waiting = false;
           
        }
        if(!waiting)
        {
            Falling();

        }
    }
    void Falling()
    {
        if (balasActualesDown < numBullets)
        {
            Debug.Log(balasActualesUp + " Balas Callendo");
            timer += Time.deltaTime;
            if (firstBullet)
            {
                Instantiate(prefabBulletDown, new Vector3(playerRef.transform.position.x,alturaFall,playerRef.transform.position.z), Quaternion.identity);

                balasActualesDown++;
                firstBullet = false;
            }
            if (timer >= cadencia)
            {
                Instantiate(prefabBulletDown, new Vector3(playerRef.transform.position.x, alturaFall, playerRef.transform.position.z), Quaternion.identity);
                balasActualesDown++;
                timer = 0;
            }
        }
        else
        {
            Debug.Log(balasActualesUp + " Balas Recargando");
            Recharge();
        }
    }
    void Recharge()
    {
        if (balasMax - currentBullets <= numBullets)
        {
            numBullets = balasMax - currentBullets;
            finishCicle = true;
        }
        if (finishCicle  && balasMax - currentBullets == 0)
        {
            boss.mortero = false;
        }
        
        timer += Time.deltaTime;

        Debug.Log(" Recargando");
        if (timer >= tiempoRecarga)
        {
            canStart = true;
            firstBullet = true;
            waiting = true;
            balasActualesUp = 0;
            balasActualesDown = 0;
            timer = 0;
            

        }



    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }
}
