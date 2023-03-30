using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocoMolotov : MonoBehaviour
{
    public GameObject molotov;
    public GameObject molotovModelo;
    public GameObject fuego;
    GameObject player;
    public float distanceBehind;
    public float speed;
    public float accel;
    float distance2Player;
    public float tiempoTrayecto;
    Vector3 normal;
    Rigidbody miRb;
    public float velocityX;
    //public GameObject testingGO;
    float timer=0;
    float lifeTimer = 0;
    bool canExplode = true;
    public float dps;
    public float duracionFuego;
    bool fireOn = false;
    Vector3 destinationPoint;
    [SerializeField]GameObject sonidoFuego;
   
    // Start is called before the first frame update
    void Start()
    {
        
        fuego.SetActive(false);
        player = GameManager.Instance.goPlayer;
        destinationPoint = player.transform.position + Vector3.Normalize( player.transform.position -transform.position) * distanceBehind;
        distance2Player = Vector3.Distance(transform.position, destinationPoint);
        //distance2Player = Vector3.Distance(transform.position, destinationPoint);
        miRb = GetComponent<Rigidbody>();

        normal = destinationPoint - transform.position; 
        //normal = destinationPoint - transform.position;

        //testingGO = GameObject.FindGameObjectWithTag("Test"); Debug gameobject por si acaso
        //testingGO.transform.position = destinationPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameManager.Instance.goPlayer;
        }
        else
        {
            if (fireOn)
            {
                lifeTimer += Time.deltaTime;
                if (lifeTimer > duracionFuego)
                {
                    Destroy(gameObject);
                }
            }
            if (canExplode)
            {
                MirarPlayer();
                timer += Time.deltaTime;
                //Debug.Log(timer);
                velocityX = distance2Player / tiempoTrayecto;
                //velocityX = speed + accel * tiempoTrayecto;
                miRb.velocity = normal * velocityX/* * Time.deltaTime */;

                if (Vector3.Distance(transform.position, destinationPoint) <= 0.5)
                {
                    canExplode = false;
                    Debug.Log("Entra");
                    timer = 0;
                    Explosion();

                }
            }
        }
     //Debug.DrawLine(player.transform.position,Vector3.Normalize(player.transform.position - transform.position));
     //Debug.Log(Vector3.Distance(transform.position, player.transform.position) +distanceBehind);
   
        
    }
    void Explosion()
    {
        fuego.SetActive(true);
        NuevoSonido(sonidoFuego, this.transform.position, 5f);
        molotov.SetActive(false);
        molotovModelo.SetActive(false);
        miRb.velocity *= 0;
        fireOn=true;
    }
    void MirarPlayer()
    {

        Vector3 lookVector = normal;
        lookVector.y = 0;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.05f);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Mov>() != null)
        {
            timer = Time.deltaTime / dps;
            other.GetComponent<VidaJugador>().TakeDamage(timer);
        }
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }

}
