using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManagerMisiones : SingletonTemporal<ManagerMisiones>
{
    [Header("Mision 1")]
    public GameObject misionUnoPanel;
    public GameObject tituloObjetivoPlantillaPanel;
    public GameObject subObjetivoPlantilla;
    public int misionUnoObjetivos;
    public int misionUnoSubObjetivos;
    GameObject objetivoContenedor;
    public GameObject subObjetivoContenedor;
    public GameObject[] textContainers;

    [SerializeField] int nivelActual;

    
    
    // Start is called before the first frame update
    void Start()
    {
        textContainers = new GameObject[misionUnoSubObjetivos];
        StartMision1(nivelActual);
    }

    // Update is called once per frame
    #region Mision 1
    void StartMision1(int nivel)
    {
        for (int i = 0; i < misionUnoObjetivos; i++)
        {
            //Debug.Log("entra");
            
            objetivoContenedor = Instantiate(tituloObjetivoPlantillaPanel, misionUnoPanel.transform);
            objetivoContenedor.GetComponent<Text>().text = TextManager.Instance.text_objetivoPrincipal[i];
            
            for (int t = 0; t < misionUnoSubObjetivos; t++)
            {
                
                //Debug.Log("entra SubObjetivos");

                subObjetivoContenedor = Instantiate(subObjetivoPlantilla, objetivoContenedor.transform);
                textContainers[t] = subObjetivoContenedor;
                subObjetivoContenedor.GetComponent<Text>().text = TextManager.Instance.text_subObjetivoPrincipal[t];
                if (t > 0)
                {
                    textContainers[t].SetActive(false);
                }
                //subObjetivoContenedor = null;
                             
            }
           
        }
        //subObjetivoContenedor = Instantiate(subObjetivoPlantilla, objetivoContenedor.transform);

        //subObjetivoContenedor.GetComponent<Text>().text = TextManager.Instance.text_subObjetivoPrincipal[0];
    }

    public void UpdateTextosMisiones(int textNum , int currentText)
    {
        textContainers[textNum].GetComponent<Text>().text = TextManager.Instance.text_subObjetivoPrincipal[currentText];

        /*for (int i = 0; i < misionUnoSubObjetivos; i++)
        {
            subObjetivoContenedor.GetComponent<Text>().text = TextManager.Instance.text_subObjetivoPrincipal[i];
        }*/
    }

    #endregion
}
