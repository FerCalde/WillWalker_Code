using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEspada : MonoBehaviour
{
    [SerializeField] ParticleSystem dash;
    [SerializeField] float duration = 3f;
    [SerializeField] float damage = 100f;
    [SerializeField] Collider colChekc;
    float tiempo;
    Rigidbody rb;
    void Awake()
    {
       /* var main = dash.main;
        main.duration = duration * 5;*/
    }
    void Start()
    {
        /*rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed * 100);*/
       
        dash.Play();
    }
    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= duration)
        {
            Destroy(gameObject);
        }
        if (tiempo >= 0.1f)
        {
            colChekc.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponentInParent<VidaEnemyBase>().TakeDamage(damage);
        }
    }
}
