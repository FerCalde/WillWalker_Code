using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClasesManager : MonoBehaviour
{
    [SerializeField] Button[] buttonClases;

    [SerializeField] GameObject panelMisionInfo;

    int ableClaseDefault, ableClaseSamurai, ableClaseForastero, ableClaseHacker;
    List<int> allClasesAbles = new List<int>();

    //VARIABLES ANTIGUAS
    int clasesDisponibles = 1;
    int clasesTotal = 4;
    int claseActual = 1;

    /*
    void Start()
    {
        int levelComplete = PlayerPrefs.GetInt("NivelesCompletados");
        clasesDisponibles += levelComplete;
        if(clasesDisponibles>= clasesTotal)
        {
            clasesDisponibles = clasesTotal;
        }
        /*
        if (levelComplete >= 2)
        {
            clasesDisponibles = clasesTotal;
        }
        if (levelComplete == 0)
        {
            clasesDisponibles = 1;
        }
        if (levelComplete == 1)
        {
            clasesDisponibles = 2;
        }
        if (levelComplete == 2)
        {
            clasesDisponibles = 3;
        }
        
    for(int i=0; (i <= buttonClases.Length-1); i++)
    {
        if (i <= (clasesDisponibles-1))
        {
            buttonClases[i].interactable = true;
        }
        else
        {
            buttonClases[i].interactable = false;
        }
    }
}
*/ //Antiguo Método Unlock Players según los niveles completos
    /*
    public void ResetClases()
    {
        clasesDisponibles = 1;
        PlayerPrefs.SetInt("ClasesDisponibles", clasesDisponibles);
    }*/

    void Start()
    {
        AppData.Instance.LoadCurrentsMejoras(); //Primero cargo los datos de las Mejoras Realizadas
        ableClaseDefault = AppData.Instance.mejorasClaseDefault;
        ableClaseSamurai = AppData.Instance.mejorasClaseSamurai;
        ableClaseForastero = AppData.Instance.mejorasClaseForastero;
        ableClaseHacker = AppData.Instance.mejorasClaseHacker;


        allClasesAbles.Add(ableClaseDefault);
        allClasesAbles.Add(ableClaseSamurai);
        allClasesAbles.Add(ableClaseForastero);
        allClasesAbles.Add(ableClaseHacker);

        //Solo necesito saber que sea Mayor que 0, porque significaria que esa clase está desbloqueada
        for (int i = 0; (i <= buttonClases.Length - 1); i++)
        {

            if (allClasesAbles[i] > 0)
            {
                buttonClases[i].interactable = true;
            }
            else
            {
                buttonClases[i].interactable = false;
            }
           
        }
    }
    public void SelectClase(int claseSeleccionada)
    {
        AppData.Instance.SaveCurrentClase(claseSeleccionada);
        
        //claseActual = claseSeleccionada;
        //LevelManager.Instance.UpdateClaseSeleccionada(claseSeleccionada);
        //PlayerPrefs.SetInt("ClaseActual", claseActual);
        
        //InfoMisionHUDCity cmpHUDmisioninfo = panelMisionInfo.GetComponent<InfoMisionHUDCity>();
        //cmpHUDmisioninfo.SetCurrentClassInfo( GetComponent<LevelManager>().text_armas[claseActual], GetComponent<LevelManager>().text_habilidades[claseActual]);
    }

}

