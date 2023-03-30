using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Kamikaze : MonoBehaviour
{
    public Vector3 start;

    NavMeshAgent kami;
    GameObject player;

    VidaEnemyBase vida;
    public bool onlyChase;
    public bool detected = false;
    public bool exploteByDist = false;

    [SerializeField] float distDetect;
    Vector3 lookForPlayer;
    StateMachine refStateManager;

    Animator Anim;
    public float distanceToExplote;
    public GameObject explo;

    public AudioSource cmpAudioSource;
    public AudioClip gritoLoco, explosion;
    public Renderer rend;
    public GameObject sonidoGrito;
    Collider col;
    AplicarEfectosTemporales efectos;

    bool bugSonidoControl = false;

    void Start()
    {
        efectos = GetComponent<AplicarEfectosTemporales>();
        start = transform.position;
        col = GetComponent<Collider>();
        vida = GetComponent<VidaEnemyBase>();
        player = GameManager.Instance.goPlayer;
        kami = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
        cmpAudioSource = GetComponentInParent<AudioSource>();
        refStateManager = GetComponent<StateMachine>();

    }
    void Update()
    {
        if (player == null)
        {
            player = GameManager.Instance.goPlayer;

        }
        else
        {
            if (vida.VidaActual <= 0)
            {

                col.enabled = false;
                refStateManager.ChangeState("ExploteDeath");
            }
            else
            {
                rend.enabled = true;
                explo.SetActive(false);
                col.enabled = true;
                if(onlyChase)
                {
                    if (!efectos.tashed)
                    {
                        refStateManager.ChangeState("Chase");
                    }
                    else
                    {
                        refStateManager.ChangeState("Idle");
                    }
                        
                }
                else
                {
                    if (!efectos.tashed)
                    {
                        if (detected)
                        {
                            refStateManager.ChangeState("Chase");
                            if (bugSonidoControl == false)
                            {
                                //SoundVFX(gritoLoco);
                                if (sonidoGrito != null)
                                {
                                    NuevoSonido(sonidoGrito, this.transform.position, 1f);
                                }
                                bugSonidoControl = true;
                            }
                        }
                        else
                        {
                            if (vida.hitted)
                            {
                                refStateManager.ChangeState("LookForPlayer");
                            }
                        }
                    }
                    else
                    {
                        refStateManager.ChangeState("Idle");
                    }




                }
                Detection();
            }
                
        }
        

    }
    void Detection()
    {

        RaycastHit hit;
        Vector3 rayDir = player.transform.position - (transform.position);
        if (Physics.Raycast(transform.position, rayDir, out hit, distDetect))
        {
            if (hit.collider.gameObject.layer == 8)
            {
                // Debug.Log("esePlayerGuapoAhi");
                detected = true;

            }
        }
        else
        {
            detected = false;
        }
    }

    public void SoundVFX(AudioClip vfxSoundActual)
    {
        cmpAudioSource.clip = vfxSoundActual; //Cambia el clip del audio
        cmpAudioSource.Play();                //Reproduce el sonido.   
    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }
}
