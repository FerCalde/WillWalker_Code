using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GongCheckerMonasterio : MonoBehaviour
{
    public List<GongChecker> gongToTake = new List<GongChecker>();
    [SerializeField] int currentsGongs = 0;


    //[SerializeField] bool cogerObjetivo = false;
    //[SerializeField] GameObject nextObjetivo;

    [SerializeField] Text textoObjetivoUpdateable;
    [SerializeField] string objetiveToTake = "Gongs Taked: ";

    [SerializeField] int numeroObjetivo;
    //public GongChecker[] gongTaker;

    [SerializeField] bool isNextObjetivePosible = false;
    [SerializeField] GameObject nextObjetivo;
    [SerializeField]string objetoParaCoger = "Drug Bag";

    // Start is called before the first frame update
    void Start()
    {
        currentsGongs = 0;
        //UpdateTextObjetiveTaked();
        if (isNextObjetivePosible)
        {
            nextObjetivo.SetActive(false);
        }
        FinLevel.Instance.GetComponent<Collider>().enabled = false;
        /*if (!cogerObjetivo)
        {
            if (nextObjetivo != null)
            {
                nextObjetivo.SetActive(false);
            }
        }*/
    }

    public void GongIsTake(GameObject playedGong)
    {
        for (int i = 0; i < gongToTake.Count; i++)
        {
            if (playedGong == gongToTake[i].gong)
            {
                if (gongToTake[i].isTaked == false)
                {
                    currentsGongs++;
                    UpdateTextObjetiveTaked();

                    Destroy(gongToTake[i].objectToDestroy);

                    if (currentsGongs >= gongToTake.Count)
                    {
                        FinLevel.Instance.GetComponent<Collider>().enabled = true;

                       
                        if (isNextObjetivePosible)
                        {
                            UpdateTextObjetiveTaked(" Completed " /*+ "\r\n \r\n" + "Take the "+ objetoParaCoger+" and... Get the fuck out of here!"*/);
                            nextObjetivo.SetActive(true);
                        }
                        if (!isNextObjetivePosible)
                        {
                            UpdateTextObjetiveTaked(" Completed " /*+ "\r\n \r\n" + "Take the "+ objetoParaCoger+" and... Get the fuck out of here!"*/);
                           
                        }

                    }
                    gongToTake[i].isTaked = true;
                }
            }
        }
    }

    void UpdateTextObjetiveTaked()
    {
        //textoObjetivoUpdateable.text = objetiveToTake + currentsGongs.ToString() + "/" + gongToTake.Count.ToString();
        string objUp = objetiveToTake + currentsGongs.ToString() + "/" + gongToTake.Count.ToString();

        //TextManager.Instance.text_subObjetivoPrincipal[numeroObjetivo] = objUp;
        //int varNivel = ManagerMisiones.Instance.nivelActual;
        ManagerMisiones.Instance.textContainers[numeroObjetivo].GetComponent<Text>().text = objUp;
    }

    void UpdateTextObjetiveTaked(string setString)
    {

        //Debug.Log("entra final");
        //TextManager.Instance.text_subObjetivoPrincipal[numeroObjetivo] = objUp;
        //int varNivel = ManagerMisiones.Instance.nivelActual;
        ManagerMisiones.Instance.textContainers[numeroObjetivo].GetComponent<Text>().text += setString;
        ManagerMisiones.Instance.textContainers[numeroObjetivo].GetComponent<Text>().color = Color.gray;
        if(ManagerMisiones.Instance.textContainers[numeroObjetivo + 1] != null)
        {
            ManagerMisiones.Instance.textContainers[numeroObjetivo + 1].SetActive(true);
        }
        
    }

}


[System.Serializable]
public class GongChecker
{

    [SerializeField] public GameObject gong;
    public bool isTaked = false;
    [SerializeField] public GameObject objectToDestroy;
}