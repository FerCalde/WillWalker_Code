using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideMissile : MonoBehaviour
{
    [SerializeField] float speedBalaMax;
    [SerializeField] float speedBalaMin;
    GameObject playerRef;
    [SerializeField] GameObject explosion;
    [HideInInspector]public float timeToExplote;
    float dist;
    float time;
    float speedBala;
    float randomRoot;
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        randomRoot = Random.Range(0.1f, 0.9f);
        speedBala = Random.Range(speedBalaMin, speedBalaMax);
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= timeToExplote)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        dist = Vector3.Distance(playerRef.transform.position, transform.position);
        if (dist < 1f)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
        transform.position += transform.forward * speedBala * Time.deltaTime;
        LookPlayer();
    }
    void LookPlayer()
    {
        Vector3 lookVector = playerRef.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, randomRoot);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
           
            Destroy(gameObject);
        }
        else
        {
            if (other.gameObject.tag != "IgnoreBala")
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            
        }
        
    }
}
