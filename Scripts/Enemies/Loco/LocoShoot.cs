using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocoShoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject firePoint;
    public GameObject firePoint2;
    float timer;
    [SerializeField] float cadence;
    [SerializeField] float timeBetweenBursts;
    [SerializeField] int bulletPerBurst;
    [SerializeField] GameObject soniDisparo;
 

    int bulletCont;
    bool firstBullet;

    
    // Start is called before the first frame update
    void Start()
    {
        NuevoSonido(soniDisparo, this.transform.position, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        
        //Debug.Log("entra disparar");
        timer += Time.deltaTime;
        if (!firstBullet)
        {
          
            Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
            Instantiate(bulletPrefab, firePoint2.transform.position, transform.rotation);
            firstBullet = true;
            bulletCont++;

        }
        if (timer >= cadence && bulletCont < bulletPerBurst)
        {
            Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
            Instantiate(bulletPrefab, firePoint2.transform.position, transform.rotation);
            bulletCont++;
            timer = 0;
        }
        if (timer >= timeBetweenBursts && bulletCont >= bulletPerBurst)
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
