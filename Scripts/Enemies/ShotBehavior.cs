﻿using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {
    Rigidbody rb;
    public float speed = 50;
    public int damage = 20;
    public GameObject sfxExplosion;
    bool dañarEnemigo;
	void Start () {
       
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed * 100);

    }
    private void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.layer == 8) 
        {
            NuevoSonido(sfxExplosion, this.transform.position, 1f);
            col.gameObject.GetComponentInParent<VidaJugador>().TakeDamage(damage);
            //V.Tempo -= 8f;
            
        }
        if (dañarEnemigo == true)
        {
            if (col.gameObject.tag == "Enemy")
            {
                if (col.gameObject.layer == 12)
                {
                    col.gameObject.GetComponentInParent<VidaEnemyBase>().TakeDamage(damage * 2);
                }
                else
                {
                    col.gameObject.GetComponentInParent<VidaEnemyBase>().TakeDamage(damage * 10000);
                }
                
            }
        }
        
        if (col.gameObject.tag != "BalaEnemigo")
        {
            if (col.gameObject.tag == "RebotaBalas")
            {
                rb.velocity = Vector3.zero;
                transform.position = col.gameObject.transform.position;
                rb.AddForce(col.transform.forward * speed * 100);
                dañarEnemigo = true;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        bool modificarPitch = true;
        GameObject obj = Instantiate(sonido, pos, Quaternion.identity);
        if (modificarPitch)
        {
            obj.GetComponent<AudioSource>().pitch *= 1 + Random.Range(-0.2f, 0.2f);
        }
        Destroy(obj, 3f);
    }
    //private void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "Enemy")
    //    {
    //        //col.gameObject.GetComponent<CopEnemy>().vida-=20;
    //        Debug.Log("entraColision");

    //    }
    //}
    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.gameObject.CompareTag("Enemy"))
    //    {
    //        Debug.Log("QuitaVida");
    //        hit.gameObject.GetComponent<CopEnemy>().vida -= damage;
    //        Destroy(hit.gameObject);

    //    }
    //    Debug.Log("entraColision");
    //}

}
