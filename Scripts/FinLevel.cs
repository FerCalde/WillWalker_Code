using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinLevel : SingletonTemporal<FinLevel>
{
    public Text time;
    public Text kills;
    public Text respesct;
    public Text textofinal;
    public Text scoreTotal;
    public GameObject CANVAS;
    bool final = false;
    float timer = 0f;
    float sumaTotal = 0;
    [SerializeField] GameManager gameManager;
     public GameObject press;

    [SerializeField] bool posibilidadBonus = true;

    bool varSebusca = false;
    [SerializeField] GameObject canvasPuntuacion;

    [SerializeField] float puntosFailNivel, puntosMidNivel, puntosExitoNivel;

    [SerializeField] int currentLevelPos;

    void Start()
    {

        CANVAS.SetActive(false);
        gameManager = GameManager.Instance;
        press = GameObject.FindGameObjectWithTag("Press");
        press.SetActive(false);
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 8)
        {

            ActiveEndGamePanel();
        }
    }



    public void ActiveEndGamePanel()
    {
        final = true;
        float V = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaJugador>().VidaActual;
        int vida = Mathf.RoundToInt(V);
        time.text = " " + Mathf.RoundToInt(V).ToString();
        float k = gameManager.contadorKillsEnemy;
        kills.text = " " + k.ToString();

        float r = CombosKillManager.Instance.puntosCurrent;

        sumaTotal = r + vida;

        respesct.text = " " + Mathf.RoundToInt(sumaTotal).ToString();

        CANVAS.SetActive(true);
        canvasPuntuacion.SetActive(false);
        if (posibilidadBonus == true)
        {
            if (sumaTotal >= puntosExitoNivel)
            {
                scoreTotal.text = "S";
                textofinal.text = "Awesome YOU GET THE BONUS";
                AppData.Instance.BonusCogido(currentLevelPos, 1);

            }
            if (sumaTotal < puntosExitoNivel && sumaTotal >= puntosMidNivel)
            {
                scoreTotal.text = "A";
                textofinal.text = "Very Good";
            }
            if (sumaTotal < puntosMidNivel && sumaTotal >= puntosFailNivel)
            {
                scoreTotal.text = "B";
                textofinal.text = "Good";
            }
            if (sumaTotal < puntosFailNivel)
            {
                scoreTotal.text = "C";
                textofinal.text = "Not Bad";
            }
        }
        else
        {
            scoreTotal.text = "GG";
            textofinal.text = "Not Reward Today";
        }

        gameManager.FinLevelPauseTime();


    }
}
