using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PanelesManager : MonoBehaviour
{
    [Header("Nivel 1")]
    public GameObject panelNivel1;
    public Image claseDefaultImg;
    public Image claseSamuraiImg;
    public Image claseForasteroImg;
    public Image claseHackerImg;




    [SerializeField] [TextArea] string[] weaponsClase;
    [SerializeField] Text textWeaponsClase;
    [SerializeField] [TextArea] string[] habilityClase;
    [SerializeField] Text textHabilityClase;


    [Header("AnimacionesBotones")]

    [SerializeField] GameObject animClaseDefault, animClaseSamurai, animClaseForastero, animClaseHacker;


    // Start is called before the first frame update
    void Start()
    {
        panelNivel1.SetActive(false);
        UpdateTextsClase(0);
    }


    #region Nivel 1
    public void AbrirNivel1()
    {
        panelNivel1.SetActive(true);
    }
    public void CerrarNivel1()
    {
        panelNivel1.SetActive(false);
    }
    public void ButtonDefault()
    {
        /*
        claseIzqImg.color = Color.red;
        claseCentroImg.color = Color.white;
        claseDerImg.color = Color.white;
        claseHackerImg.color = Color.white;
        */

        animClaseDefault.SetActive(true);
        animClaseSamurai.SetActive(false);
        animClaseForastero.SetActive(false);
        animClaseHacker.SetActive(false);


        UpdateTextsClase(0);
    }



    public void ButtonSamurai()
    {
        /*
        claseDefaultImg.color = Color.white;
        claseSamuraiImg.color = Color.red;
        claseForasteroImh.color = Color.white;
        claseHackerImg.color = Color.white;
        -*/

        animClaseSamurai.SetActive(true);
        animClaseDefault.SetActive(false);
        animClaseForastero.SetActive(false);
        animClaseHacker.SetActive(false);

        UpdateTextsClase(1);
    }

    public void ButtonForastero()
    {
        /*
        claseDefaultImg.color = Color.white;
        claseSamuraiImg.color = Color.white;
        claseForasteroImh.color = Color.red;
        claseHackerImg.color = Color.white;
        */

        animClaseForastero.SetActive(true);
        animClaseDefault.SetActive(false);
        animClaseSamurai.SetActive(false);
        animClaseHacker.SetActive(false);

        UpdateTextsClase(2);

    }

    public void ButtonHacker()
    {
        /*
        claseDefaultImg.color = Color.white;
        claseSamuraiImg.color = Color.white;
        claseForasteroImh.color = Color.white;
        claseHackerImg.color = Color.red;
        */

        animClaseHacker.SetActive(true);
        animClaseDefault.SetActive(false);
        animClaseSamurai.SetActive(false);
        animClaseForastero.SetActive(false);


        UpdateTextsClase(3);

    }
    void UpdateTextsClase(int claseSelect)
    {
        textWeaponsClase.text = weaponsClase[claseSelect];
        textHabilityClase.text = habilityClase[claseSelect];
        //UpdateClaseWeapons(claseSelect);
        //UpdateClaseHability(claseSelect);
    }
   /* void UpdateClaseWeapons(int claseSelect)
    {
    }
    void UpdateClaseHability(int claseSelect)
    {
    }*/

    #endregion
}
