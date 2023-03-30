using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TryMenuSpawner : MonoBehaviour
{
 
    public void SelectPersonaje()
    {
        PlayerPrefs.SetInt("Personajillo", 0);
        CargaEscena();
    }
    public void SelectPersonajeSam()
    {
        PlayerPrefs.SetInt("Personajillo", 1);
        CargaEscena();
    }

    public void SelectPersonajeFor()
    {
        PlayerPrefs.SetInt("Personajillo", 2);
        CargaEscena();
    }
    public void SelectPersonajeHac()
    {
        PlayerPrefs.SetInt("Personajillo", 3);
        CargaEscena();
    }

    void CargaEscena()
    {
        //SceneManager.LoadScene("TrySpawner");
        GetComponent<LoadAsync>().LevelLoader(87);
    }

}
