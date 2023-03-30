using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtomsLevelUp : MonoBehaviour
{
    [SerializeField] GameObject[] Buttoms; 
    void Start()
    {
        Time.timeScale = 1f;
        AppData.Instance.LoadCurrentsMejoras();
        if (PlayerPrefs.GetInt("MejorasClaseDefault") > 3)
        {
            Buttoms[0].GetComponent<Button>().enabled = false;
            Buttoms[0].GetComponent<Animator>().enabled = true;
        }

        if (PlayerPrefs.GetInt("MejorasClaseSamurai") > 3)
        {
            Buttoms[1].GetComponent<Button>().enabled = false;
            Buttoms[1].GetComponent<Animator>().enabled = true;
        }

        if (PlayerPrefs.GetInt("MejorasClaseForastero") > 3)
        {
            Buttoms[2].GetComponent<Button>().enabled = false;
            Buttoms[2].GetComponent<Animator>().enabled = true;
        }

        if (PlayerPrefs.GetInt("MejorasClaseHacker") > 3)
        {
            Buttoms[3].GetComponent<Button>().enabled = false;
            Buttoms[3].GetComponent<Animator>().enabled = true;
        }
    }
    public void MejorarSeñorTiempo()
    {
        Buttoms[0].GetComponent<Mejoras>().Desactivar();
        if (PlayerPrefs.GetInt("MejorasClaseDefault") == 0)
        {
            AppData.Instance.UnlockMejoraClaseDefault();
        }
        if (PlayerPrefs.GetInt("MejorasClaseDefault") == 1)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 1 && PlayerPrefs.GetInt("MejorasClaseDefault") < 4)
            {
                AppData.Instance.UnlockMejoraClaseDefault();
                AppData.Instance.GastarPuntoMejora(1);
            }
        }
        else if (PlayerPrefs.GetInt("MejorasClaseDefault") == 2)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 3 && PlayerPrefs.GetInt("MejorasClaseDefault") < 4)
            {
                AppData.Instance.UnlockMejoraClaseDefault();
                AppData.Instance.GastarPuntoMejora(3);
            }
        }
        else if (PlayerPrefs.GetInt("MejorasClaseDefault") == 3)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 4 && PlayerPrefs.GetInt("MejorasClaseDefault") < 4)
            {
                AppData.Instance.UnlockMejoraClaseDefault();
                AppData.Instance.GastarPuntoMejora(4);
                Buttoms[0].GetComponent<Button>().enabled = false;
                Buttoms[0].GetComponent<Animator>().enabled = true;
            }
        }


    }
    public void MejorasSamurai()
    {
        Buttoms[1].GetComponent<Mejoras>().Desactivar();
        if (PlayerPrefs.GetInt("MejorasClaseSamurai") == 0)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 2 && PlayerPrefs.GetInt("MejorasClaseSamurai") < 4)
            {
                AppData.Instance.UnlockMejoraClaseSamurai();
                AppData.Instance.GastarPuntoMejora(2);
            }
        }
        else if (PlayerPrefs.GetInt("MejorasClaseSamurai") == 1)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 1 && PlayerPrefs.GetInt("MejorasClaseSamurai") < 4)
            {
                AppData.Instance.UnlockMejoraClaseSamurai();
                AppData.Instance.GastarPuntoMejora(1);
            }
        }
        else if (PlayerPrefs.GetInt("MejorasClaseSamurai") == 2)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 3 && PlayerPrefs.GetInt("MejorasClaseSamurai") < 4)
            {
                AppData.Instance.UnlockMejoraClaseSamurai();
                AppData.Instance.GastarPuntoMejora(3);
            }
        }
        else if (PlayerPrefs.GetInt("MejorasClaseSamurai") == 3)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 4 && PlayerPrefs.GetInt("MejorasClaseSamurai") < 4)
            {
                AppData.Instance.UnlockMejoraClaseSamurai();
                AppData.Instance.GastarPuntoMejora(4);
                Buttoms[1].GetComponent<Button>().enabled = false;
                Buttoms[1].GetComponent<Animator>().enabled = true;
            }
        }
    }
    public void MejorasForastero()
    {
        Buttoms[2].GetComponent<Mejoras>().Desactivar();
        if (PlayerPrefs.GetInt("MejorasClaseForastero") == 0)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 2 && PlayerPrefs.GetInt("MejorasClaseForastero") < 4)
            {
                AppData.Instance.UnlockMejoraClaseForastero();
                AppData.Instance.GastarPuntoMejora(2);
            }
        }
        else if (PlayerPrefs.GetInt("MejorasClaseForastero") == 1)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 1 && PlayerPrefs.GetInt("MejorasClaseForastero") < 4)
            {
                AppData.Instance.UnlockMejoraClaseForastero();
                AppData.Instance.GastarPuntoMejora(1);
            }
        }
        else if (PlayerPrefs.GetInt("MejorasClaseForastero") == 2)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 3 && PlayerPrefs.GetInt("MejorasClaseForastero") < 4)
            {
                AppData.Instance.UnlockMejoraClaseForastero();
                AppData.Instance.GastarPuntoMejora(3);
            }
        }
        else if (PlayerPrefs.GetInt("MejorasClaseForastero") == 3)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 4 && PlayerPrefs.GetInt("MejorasClaseForastero") < 4)
            {
                AppData.Instance.UnlockMejoraClaseForastero();
                AppData.Instance.GastarPuntoMejora(4);
                Buttoms[2].GetComponent<Button>().enabled = false;
                Buttoms[2].GetComponent<Animator>().enabled = true;
            }
        }
    }
    public void MejorasHacker()
    {
        Buttoms[3].GetComponent<Mejoras>().Desactivar();
        if (PlayerPrefs.GetInt("MejorasClaseHacker") == 0)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 2 && PlayerPrefs.GetInt("MejorasClaseHacker") < 4)
            {
                AppData.Instance.UnlockMejoraClaseHacker();
                AppData.Instance.GastarPuntoMejora(2);
            }
        }
        else if (PlayerPrefs.GetInt("MejorasClaseHacker") == 1)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 1 && PlayerPrefs.GetInt("MejorasClaseHacker") < 4)
            {
                AppData.Instance.UnlockMejoraClaseHacker();
                AppData.Instance.GastarPuntoMejora(1);
            }
        }
        else if (PlayerPrefs.GetInt("MejorasClaseHacker") == 2)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 3 && PlayerPrefs.GetInt("MejorasClaseHacker") < 4)
            {
                AppData.Instance.UnlockMejoraClaseHacker();
                AppData.Instance.GastarPuntoMejora(3);
            }
        }
        else if (PlayerPrefs.GetInt("MejorasClaseHacker") == 3)
        {
            if (PlayerPrefs.GetInt("PuntosMejora") >= 4 && PlayerPrefs.GetInt("MejorasClaseHacker") < 4)
            {
                AppData.Instance.UnlockMejoraClaseHacker();
                AppData.Instance.GastarPuntoMejora(4);
                Buttoms[3].GetComponent<Button>().enabled = false;
                Buttoms[3].GetComponent<Animator>().enabled = true;
            }
        }
    }
    public void SumarPuntos()
    {
        AppData.Instance.WinPuntoMejora();
    }
    public void ResetearPuntos()
    {
        AppData.Instance.ResetCurrentsMejoras();
    }
}