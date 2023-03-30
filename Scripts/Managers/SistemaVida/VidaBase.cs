using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VidaBase : Singleton {
    
    [SerializeField] protected float vidaMaxima = 100;
    [SerializeField]  protected float vidaActual;
    [SerializeField] protected bool hited = false;
    [SerializeField] protected bool hitedByEnemy = false;

    bool inmuneTemp = false;
    protected bool inmune = false;
    float tiempoInmune = 0;
       
    public bool Inmune
    {
        get { return inmune; }
    }
    public float VidaMaxima
    {
        get { return vidaMaxima; }
    }

    public float VidaActual
    {
        get { return vidaActual; }
        set { vidaActual = value; }
    }
    public bool Hited
    {
        get { return hited; }
        set { hited = value; }
    }
    public bool HitedByEnemy
    {
        get { return hitedByEnemy; }
        set { hitedByEnemy = value; }
    }

    protected Animator cmpAnimator;


    protected float cantDamageRecibida;


    protected override void Awake()
    {
        base.Awake();
        
        cmpAnimator = GetComponent<Animator>();
    }
    
  
    protected virtual void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void ActivarInmunidadTemporal(float tiempoInmunidad)
    {
        inmuneTemp = true;
        inmune = true;
        tiempoInmune = tiempoInmunidad;
    }

    protected virtual void Update()
    {
        if(inmuneTemp)
        {
            tiempoInmune -= Time.deltaTime;
            if(tiempoInmune <= 0) { inmune = false; inmuneTemp = false; }
        }
    }

    public virtual void TakeDamage(float damage)
    {
        
        if(!inmune)
        {
            vidaActual -= damage;
            cantDamageRecibida = damage;
            if (vidaActual <= 0)
            {
                StartCoroutine(Morir());
            }
            Hited = true;
            HitedByEnemy = true;
        }
    }

    

    public virtual IEnumerator Morir()
    {
        yield return 0;
    }


    public void DamageHabilidad(float damage)
    {
        vidaActual -= damage;
    }
}
