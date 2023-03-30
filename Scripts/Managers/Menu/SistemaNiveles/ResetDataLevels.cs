using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDataLevels : MonoBehaviour
{
    [SerializeField] GameObject panelBorrarDatosJuego;

    bool doOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        panelBorrarDatosJuego.SetActive(false);
    }

    public void ResetGame()
    {
        if(doOnce == false)
        {
            AppData.Instance.ResetCurrentsMejoras(); //RESET ARBOL HABILIDADES
            AppData.Instance.SaveCurrentGame(0); //RESET NIVELES COMPLETADOS
            AppData.Instance.ResetBonusCogidos();
            AppData.Instance.ResetPuntosMejora();

            panelBorrarDatosJuego.SetActive(false);

            GetComponent<LoadAsync>().LevelLoader(4);
            doOnce = true;
        }
        
    }
    public void OpenPanel()
    {
        panelBorrarDatosJuego.SetActive(true);
    }
    public void ClosePanel()
    {

        panelBorrarDatosJuego.SetActive(false);
    }

    
    

}
