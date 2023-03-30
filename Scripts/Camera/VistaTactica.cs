using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaTactica : MonoBehaviour
{
    GameObject canvasHudPlayer;
    [SerializeField] GameObject cMCam;
    [SerializeField] Text cuentaTras;
    [SerializeField] Text cuentaTrasDos;
    WeaponController wC;//si no puedes disparar borra esta variable y todo lo que salga en rojo
    Mov mov;
    VidaJugador vJ;
    [SerializeField] float tiempo;
    Cinemachine.CinemachineBrain mainCamera;
    int tiempoAContar = 10;
    void Awake()
    {
        //EN EL AWAKE ES MEJOR OBTENER SOLO REFERENCIAS A COMPONENTES DEL PROPIO GAMEOBJECT, NO BUSCAR EN OTROS. PARA COGER COMPONENTES DE OTRO GAME OBJECT PRODUCE MENOS BUGS QUE LO HAGAMOS EN EL START
        /*
        wC = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>();
        mov = GameObject.FindGameObjectWithTag("Player").GetComponent<Mov>();
        vJ = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaJugador>();
        */
    }
    void Start()
    {
        ((GameManager)GameManager.Instance).SetPlayerRef += Setvars;

        

        cMCam.SetActive(false);

        

    }
    public void Setvars(GameObject varsPlayer)
    {
        Debug.Log("Equilicua");
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasHudPlayer == null)
        {

            wC = GameManager.Instance.goPlayer.GetComponent<WeaponController>();
            mov = GameManager.Instance.goPlayer.GetComponent<Mov>();
            vJ = GameManager.Instance.goPlayer.GetComponent<VidaJugador>();
            canvasHudPlayer = GameObject.FindGameObjectWithTag("CanvasPlayer");
            canvasHudPlayer.SetActive(false);
        }
        tiempo -= Time.deltaTime;

        if (tiempo > 10)
        {
            cuentaTras.text = "";
            cuentaTrasDos.text = "";
        }
        else
        {

            int tiempoInt = Mathf.RoundToInt(tiempo);
            if (tiempoAContar > tiempoInt)
            {
                cuentaTrasDos.fontSize += 50;
                cuentaTras.fontSize += 50;

                tiempoAContar = tiempoInt;
            }
            cuentaTras.text = tiempoInt.ToString();
            cuentaTrasDos.text = tiempoInt.ToString();
        }
        if (Input.GetKeyDown("space"))
        {
            FinTacticVision();
        }
        if (tiempo <= 0)
        {
            FinTacticVision();
        }


    }
    void FinTacticVision()
    {
        cMCam.SetActive(true);
        canvasHudPlayer.SetActive(true);
        mov.canMove = true;
        vJ.vistaTactic = false;
        Destroy(gameObject);
    }
}
