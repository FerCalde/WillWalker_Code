using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppData : SingletonPersistent<AppData>
{
    [Header("Mejoras")]
    public int mejorasClaseDefault = 1;
    public int mejorasClaseSamurai = 0;
    public int mejorasClaseForastero = 0;
    public int mejorasClaseHacker = 0;
    [Space]
    public int puntosMejora = 0;

    [Header("Niveles")]
    public int nivelesCompleted = 0;

    [Header("Clases")]
    public int claseActual = 0;
    public int claseSeleccionada = 0;

    bool steamBuild = false;


    [SerializeField] public int[] isBonusCompleted = new int[20];



    void Start()
    {
        /*if (steamBuild)
        {
            SteamBuild();
        }*/


        LoadBonusArray();

        LoadCurrentsMejoras();
        LoadPuntosMejora();
    }

    /*void SteamBuild()
    {
        PlayerPrefs.SetInt("MejorasClaseDefault", 4);
        PlayerPrefs.SetInt("MejorasClaseSamurai", 4);
        PlayerPrefs.SetInt("MejorasClaseForastero", 4);
        PlayerPrefs.SetInt("MejorasClaseHacker", 4);
        PlayerPrefs.SetInt("NivelesCompletados", 6);
    }*/
    //DATA MEJORAS
    public void LoadCurrentsMejoras()
    {
        mejorasClaseDefault = PlayerPrefs.GetInt("MejorasClaseDefault");
        mejorasClaseSamurai = PlayerPrefs.GetInt("MejorasClaseSamurai");
        mejorasClaseForastero = PlayerPrefs.GetInt("MejorasClaseForastero");
        mejorasClaseHacker = PlayerPrefs.GetInt("MejorasClaseHacker");
    }

    public void SaveCurrentsMejoras()
    {
        PlayerPrefs.SetInt("MejorasClaseDefault", mejorasClaseDefault);
        PlayerPrefs.SetInt("MejorasClaseSamurai", mejorasClaseSamurai);
        PlayerPrefs.SetInt("MejorasClaseForastero", mejorasClaseForastero);
        PlayerPrefs.SetInt("MejorasClaseHacker", mejorasClaseHacker);

    }

    public void ResetCurrentsMejoras()
    {
        mejorasClaseDefault = 1;
        mejorasClaseSamurai = 0;
        mejorasClaseForastero = 0;
        mejorasClaseHacker = 0;

        SaveCurrentsMejoras();
        LoadCurrentsMejoras();
    }

    //UNLOCK MEJORAS
    public void UnlockMejoraClaseDefault()
    {
        LoadCurrentsMejoras();

        mejorasClaseDefault++;
        SaveCurrentsMejoras();
    }
    public void UnlockMejoraClaseSamurai()
    {
        LoadCurrentsMejoras();
        mejorasClaseSamurai++;
        SaveCurrentsMejoras();
    }
    public void UnlockMejoraClaseForastero()
    {
        LoadCurrentsMejoras();
        mejorasClaseForastero++;
        SaveCurrentsMejoras();
        
    }
    public void UnlockMejoraClaseHacker()
    {
        LoadCurrentsMejoras();
        mejorasClaseHacker++;
        SaveCurrentsMejoras();
    }

    //PUNTOS MEJORAS 
    public void GastarPuntoMejora(int puntosGastados)
    {
        if (puntosMejora > 0)
        {
            puntosMejora -= puntosGastados;

            SavePuntosMejora();
            SaveCurrentsMejoras();
            LoadPuntosMejora();
            LoadCurrentsMejoras();
        }


    }
    public void WinPuntoMejora()
    {
        LoadPuntosMejora();

        puntosMejora++;

        SavePuntosMejora();
        LoadPuntosMejora();
    }

    public void LoadPuntosMejora()
    {
        puntosMejora = PlayerPrefs.GetInt("PuntosMejora");
    }
    public void SavePuntosMejora()
    {
        PlayerPrefs.SetInt("PuntosMejora", puntosMejora);
    }

    public void ResetPuntosMejora()
    {
        PlayerPrefs.SetInt("PuntosMejora", 0);
    }


    //NIVELES DATA
    public void LoadCurrentLevels()
    {
        nivelesCompleted = PlayerPrefs.GetInt("NivelesCompletados");
    }
    public void SaveCurrentGame(int nivelesCompletados)
    {
        PlayerPrefs.SetInt("NivelesCompletados", nivelesCompletados);
        LoadCurrentLevels();
    }

    public void SaveLevelIsCompleted(int isNew)
    {
        PlayerPrefs.SetInt("isNivelCompleted", isNew);
    }

    //CLASES DATA
    public void SaveCurrentClase(int claseSelected)
    {
        //PlayerPrefs.SetInt("ClaseActual", claseSelected);
        claseSeleccionada = claseSelected;
        LoadCurrentClase();
    }
    public void LoadCurrentClase()
    {
        claseActual = PlayerPrefs.GetInt("ClaseActual");
    }




    //BonusChecker
    public void LoadBonusArray()
    {
        //isBonusCompleted = new int[] { PlayerPrefs.GetInt("Bonus0"), PlayerPrefs.GetInt("Bonus1"), PlayerPrefs.GetInt("Bonus0") };
        for (int i = 0; i <= (isBonusCompleted.Length-1); i++)
        {
            isBonusCompleted[i] = PlayerPrefs.GetInt("Bonus" + i.ToString());
        }
    }

    public void BonusCogido(int nivel, int cantidad)
    {
        //isBonusCompleted[nivel] = cantidad;
        if(isBonusCompleted[nivel] != cantidad)
        {
            PlayerPrefs.SetInt("Bonus" + nivel.ToString(), cantidad);
            WinPuntoMejora();
            LoadBonusArray();

        }
    }

    public void ResetBonusCogidos()
    {
        for (int i = 0; i < (isBonusCompleted.Length - 1); i++)
        {
            PlayerPrefs.SetInt("Bonus" + i.ToString(), 0);
            //isBonusCompleted[i] = PlayerPrefs.GetInt("Bonus" + i);
        }
        LoadBonusArray();
    }


}

