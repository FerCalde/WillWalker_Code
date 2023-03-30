using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mov : MonoBehaviour
{
    [SerializeField] GameObject playerMesh;
    [SerializeField] Collider colPlayer;
    public DashCast DC;
    Vector3 pointDash;
    bool dashActive;
    //public Vida Vi;
    Vector3 moveDir = Vector3.zero;
    CharacterController P;
    Camera cam;
    Animator Anim;
    public float gravity = 10f;
    public float speed;
    float speedI;
    float H;
    float V;

    [SerializeField] float costeTiempoDash = 3f; //Damage que produce realizar un Dash
    bool Dashdelay;
    public float Ddelay = 1.5f;
    float TiToDash;
    public bool canMove = false;
   // public Image DelayHUD;

    public Image delayUI;

    public ParticleSystem particleTP;
    public ParticleSystem particleBeginTP;
    float TimeParticula = 0.5f;
    float TimePI;
    bool ParticulaActive = false;

    [HideInInspector] public Transform ShootPoint;
    [SerializeField] AudioSource cmpAudioSource;
    [SerializeField] AudioClip audioClipPasos;
   
    
    public GameObject sonidoDash;

    Rigidbody cmpRigidbody;

    void Awake()
    {
        P = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
        speedI = speed;
        TimePI = TimeParticula;
        cmpAudioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        cmpRigidbody = GetComponentInChildren<Rigidbody>();
        cam = Camera.main;       
        
    }
    void Update()
    {

        
        if (TiToDash < Ddelay)
        {
            TiToDash += Time.deltaTime;
            Dashdelay = true;
        }
        else
        {
            Dashdelay = false;


        }
        if (dashActive == true)
        {

            float dist = Vector3.Distance(transform.position, pointDash);
            if (dist < 0.05f)
            {
                dashActive = false;
                P.enabled = true;
                colPlayer.enabled = true;
                playerMesh.SetActive(true);
                particleBeginTP.Play();
            }
            else
            {
                colPlayer.enabled = false;
                transform.position = Vector3.MoveTowards(transform.position, pointDash, 50 * Time.deltaTime);
                P.enabled = false;
            }
        }
        if (canMove)
        {
            if (Input.GetKeyDown("space"))
            {
                if (Dashdelay == false)
                {
                    if (DC.dash == true)
                    {
                        particleTP.Play();
                        playerMesh.SetActive(false);
                        
                        ParticulaActive = true;
                        TiToDash = 0f;
                        pointDash = DC.DashP.position;
                        NuevoSonido(sonidoDash, this.transform.position, 2f);
                        //GetComponent<VidaJugador>().TakeDamage(costeTiempoDash); QUITAR VIDA CUANDO SE HACE DASH
                        dashActive = true;
                        Dashdelay = true;

                    }
                }
            }
            else
            {
                if (P.isGrounded)
                {
                    moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    Anim.SetFloat("ASpeed", Input.GetAxis("Vertical"));
                    Anim.SetFloat("LSpeed", Input.GetAxis("Horizontal"));
                    moveDir = transform.TransformDirection(moveDir);
                    // cmpAudioSource.Play();
                   
                    moveDir *= speed;
                   
                    if (moveDir.magnitude < 0.3f)
                    {
                       cmpAudioSource.Pause();
                    }


                }
                else
                {
                    moveDir.y -= gravity * Time.deltaTime;
                }
                P.Move(moveDir * Time.deltaTime);

            }
        }
        
        if (ParticulaActive == true)
        {
            
            TimeParticula -= Time.deltaTime;
            if (TimeParticula <= 0)
            {
                ParticulaActive = false;
                TimeParticula = TimePI;
            }
        }
        else
        {
            particleBeginTP.Stop();
            particleTP.Stop();
        }
        //DelayHUD.fillAmount = (TiToDash / Ddelay) / 2;
        //delayUI.fillAmount = (TiToDash / Ddelay);
    }
    public void AnimEventStep()
    {
        if (moveDir.magnitude >= 0.3f)
        {
            cmpAudioSource.clip = audioClipPasos;
            cmpAudioSource.Play();
        }
      
    }
       // Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }
    private void LateUpdate()
    {
        
    }
    public void ActivarDesactivarMovimiento(bool active)
    {
        P.enabled = active;
        colPlayer.enabled = active;
        playerMesh.SetActive(active);
        canMove = active;
    }
}
