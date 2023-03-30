using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMorteroBaja : MonoBehaviour
{
    Rigidbody miRb;
    public float speed;
    public float damage;
    [SerializeField] LayerMask layerMask;
    float distSueloInicial;
    float distSuelo;
    public GameObject circuloExterior;
    public GameObject circuloInterior;
    public GameObject sonidoExplosion;

    bool enSuelo;
    float t;

    // Start is called before the first frame update
    void Start()
    {

        miRb = GetComponent<Rigidbody>();
 

        miRb.AddForce(-1 * transform.up * speed * 100);
        Vector3 spawnPoint = transform.position;
        
        //layerMask = 1 << LayerMask.NameToLayer("Suelo"); //layer del suelo
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity, layerMask))
        {
            
            distSueloInicial = spawnPoint.y - hit.point.y;
            circuloExterior.transform.position = new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z);
            enSuelo = true;
            
        }
    }   

        // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity, layerMask))
        {

            //Debug.Log(hit.collider.gameObject.name);
            distSuelo = transform.position.y - hit.point.y;


        }
        if (enSuelo)
        {
            t = (distSueloInicial - distSuelo) / distSueloInicial;
            

            circuloInterior.transform.localScale = new Vector3(Mathf.Lerp(0, 1, t), Mathf.Lerp(0, 1, t), circuloInterior.transform.localScale.z);
           
            //if (timer >= tiempoCaida)
            //{
            //    Destroy(circuloExterior.gameObject);
            //}
        }
    }
    private void OnCollisionEnter(Collision col)
    {
       
        if (col.gameObject.tag == "Player")
        {
            NuevoSonido(sonidoExplosion, this.transform.position, 2f);
            col.gameObject.GetComponentInParent<VidaJugador>().TakeDamage(damage);
            //vfxExplosion.Play();
            gameObject.SetActive(false);
            //V.Tempo -= 8f;
            //vfxExplosion.Play();
            circuloExterior.gameObject.SetActive(false);

        }
        
        if (col.gameObject.layer == 10)
        {

            NuevoSonido(sonidoExplosion, this.transform.position, 2f);
            gameObject.SetActive(false);
            
            //vfxExplosion.Play();
            circuloExterior.gameObject.SetActive(false);

        }
        //gameObject.SetActive(false);
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }
}
