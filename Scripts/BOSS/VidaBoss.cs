using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBoss : VidaEnemyBase
{
    [SerializeField] GameObject cupulaInvulnerable;
    [HideInInspector]public bool bossNoTakeDamage = false;
    [SerializeField] GameObject powerUpVida;
    [SerializeField] int powerUpsCantidad;
    [SerializeField] float timePowerUp;
    [SerializeField] float vidaSumarPlayer = 25f;
    [SerializeField] int hitsToPowerUpdefault;
    [SerializeField] int hitsToPowerUpsamurai;
    [SerializeField] int hitsToPowerUpforastero;
    [SerializeField] int hitsToPowerUphacker;
    int claseActual;

    

    [SerializeField] float vidaMaxVSdefault;
    [SerializeField] float vidaMaxVSsamurai;
    [SerializeField] float vidaMaxVSforastero;
    [SerializeField] float vidaMaxVShacker;
    int hits;
    int hitsToPowerUp;
    [SerializeField] GameObject[] fxDaños;
    [SerializeField] ParticleSystem takeDamage;
    //[SerializeField] GameObject finLevel;

    [SerializeField] SkinnedMeshRenderer[] cmpSkinnedMeshRenderer;
    [SerializeField] Material colorDamageBoss;

    [SerializeField] Material regularColorBoss;
    protected override void Start()
    {
        //finLevel.SetActive(false);
        hits = 0;
        claseActual = AppData.Instance.claseSeleccionada;
        if (claseActual == 0)
        {
            vidaActual = vidaMaxVSdefault;
            vidaMaxima = vidaMaxVSdefault;
            hitsToPowerUp = hitsToPowerUpdefault;
        }
        if (claseActual == 1)
        {
            vidaActual = vidaMaxVSsamurai;
            vidaMaxima = vidaMaxVSsamurai;
            hitsToPowerUp = hitsToPowerUpsamurai;
        }
        if (claseActual == 2)
        {
            vidaActual = vidaMaxVSforastero;
            vidaMaxima = vidaMaxVSforastero;
            hitsToPowerUp = hitsToPowerUpforastero;
        }
        if (claseActual == 3)
        {
            vidaActual = vidaMaxVShacker;
            vidaMaxima = vidaMaxVShacker;
            hitsToPowerUp = hitsToPowerUphacker;
        }
    }
    protected override void Update()
    {
        //FX BOSSSSS
        if(vidaActual/ vidaMaxima <= 0.75f)
        {
            fxDaños[0].SetActive(true);
            fxDaños[1].SetActive(true);
        }
        if (vidaActual / vidaMaxima <= 0.5f)
        {
            fxDaños[2].SetActive(true);
            fxDaños[3].SetActive(true);
        }
        if (vidaActual / vidaMaxima <= 0.25f)
        {
            fxDaños[4].SetActive(true);
            fxDaños[5].SetActive(true);
            fxDaños[6].SetActive(true);
        }
        if (bossNoTakeDamage == false)
        {
            cupulaInvulnerable.SetActive(false);
        }
        else
        {
            cupulaInvulnerable.SetActive(true);
        }
        if (vidaActual <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<VidaJugador>().SetInvulnerable(true);
        }
    }
    IEnumerator ChangeColor()
    {
        for (int i = 0; i < cmpSkinnedMeshRenderer.Length; i++)
        {
            cmpSkinnedMeshRenderer[i].material = colorDamageBoss;
        }
        //regularColor = cmpSkinnedMeshRenderer.material;
        //cmpSkinnedMeshRenderer.material = colorDamage;
        //print(regularColor);
        yield return new WaitForSeconds(1);
        for (int i = 0; i < cmpSkinnedMeshRenderer.Length; i++)
        {
            cmpSkinnedMeshRenderer[i].material = regularColorBoss;
        }
        //cmpSkinnedMeshRenderer.material = regularColor;
        //print("colorRegularPuta");

    }
    public override void TakeDamage(float damage)
    {
        if (GetComponent<BossBehaviour>().combateIniciado)
        {
            Debug.Log("takeDamage");
            if (bossNoTakeDamage == false)
            {
                takeDamage.Play();
                vidaActual -= damage;
                if (hitsToPowerUp > hits)
                {
                    hits++;
                }
                else
                {
                    Drops(powerUpsCantidad);
                    hits = 0;
                }
                StartCoroutine(ChangeColor());
            }

            if (vidaActual <= 0)
            {
                GetComponent<BossBehaviour>().muerte = true;
            }
        }
        
    }
    void Drops(int drops)
    {
        for (int i = 0; i < drops; ++i)
        {
            float randomX = Random.Range(-10f, 10f);
            float randomZ = Random.Range(-10f, 10f);
            Vector3 spawnPos = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            GameObject newPowerUp = Instantiate(powerUpVida, spawnPos, transform.rotation);
            newPowerUp.GetComponent<TimePowerUp>().sumarVida = vidaSumarPlayer;
            newPowerUp.GetComponent<TimePowerUp>().timeToUse = timePowerUp;
        }
    }
}
