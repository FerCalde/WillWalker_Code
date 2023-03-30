using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mejoras : MonoBehaviour
{
    [SerializeField] GameObject[] descripciones;
    [SerializeField] GameObject[] datoPuntos;
    [SerializeField] string nameMejoras;
    void Update()
    {
        if (PlayerPrefs.GetInt(nameMejoras) > 0)
        {
            descripciones[0].SetActive(true);
        }
        if (PlayerPrefs.GetInt(nameMejoras) > 1)
        {
            descripciones[1].GetComponent<Animator>().enabled = true;
        }
        if (PlayerPrefs.GetInt(nameMejoras) > 2)
        {
            descripciones[2].GetComponent<Animator>().enabled = true;
        }
        if (PlayerPrefs.GetInt(nameMejoras) > 3)
        {
            descripciones[3].GetComponent<Animator>().enabled = true;
        }
    }
    private void OnMouseOver()
    {
        if (PlayerPrefs.GetInt(nameMejoras) == 0)
        {
            datoPuntos[0].SetActive(true);
        }
        if (PlayerPrefs.GetInt(nameMejoras) == 1)
        {
            datoPuntos[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt(nameMejoras) == 2)
        {
            datoPuntos[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt(nameMejoras) == 3)
        {
            datoPuntos[3].SetActive(true);
        }
    }
    void OnMouseExit()
    {
        datoPuntos[0].SetActive(false);
        datoPuntos[1].SetActive(false);
        datoPuntos[2].SetActive(false);
        datoPuntos[3].SetActive(false);
    }
    public void Desactivar()
    {
        datoPuntos[0].SetActive(false);
        datoPuntos[1].SetActive(false);
        datoPuntos[2].SetActive(false);
        datoPuntos[3].SetActive(false);
    }
}
