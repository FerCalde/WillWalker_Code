using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDronShoot : MonoBehaviour
{
    Transform playerTransform;
    SupportDamageDron refEnemy;
    public GameObject bulletPrefab;
    public GameObject firePoint;
    float timer;
    [SerializeField] float cadence;
    [SerializeField] float timeBetweenBursts;
    [SerializeField] int bulletPerBurst;
    [SerializeField] LayerMask layerMask;
    bool canShoot;
    int bulletCont;
    bool firstBullet;
    public float distanceToShoot;
    public GameObject sueloPoint;
    public GameObject sonidoDisparo;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<Mov>().transform;
        refEnemy = GetComponent<SupportDamageDron>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity, layerMask))
        {
            sueloPoint.transform.position = hit.point;
       
        }
        //Debug.Log(Vector3.Angle(sueloPoint.transform.forward, playerTransform.forward));
        float hearingDistance = Vector3.Distance(sueloPoint.transform.position, playerTransform.position);
        if (hearingDistance <= distanceToShoot)
        {

            Shoot();
           
        }
    }
    public void Shoot()
    {
      
        //Debug.Log("entra disparar");
        timer += Time.deltaTime;
        if (!firstBullet)
        {

            Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
            firstBullet = true;
            bulletCont++;
            NuevoSonido(sonidoDisparo, this.transform.position, 0.2f);

        }
        if (timer >= cadence && bulletCont < bulletPerBurst) 
        {
            Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
            bulletCont++;
            timer = 0;
        }
        if (timer >= timeBetweenBursts&& bulletCont >= bulletPerBurst)
        {
            bulletCont = 0;
            firstBullet = false;
            timer = 0;
        }
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }



}
