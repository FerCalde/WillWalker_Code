using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AguantaEnZonaController : MonoBehaviour
{


    [SerializeField] float timeToAguantar = 60f;
    float currentTimeAguante = 0;

    public List<objToDestroy> objectToDestroy = new List<objToDestroy>();

    [SerializeField] Text textCantidadTiempoAguante;

    [SerializeField] int numeroObjetivo;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeAguante = timeToAguantar;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeAguante -= Time.deltaTime;
        ManagerMisiones.Instance.textContainers[numeroObjetivo].GetComponent<Text>().text = "Time to unlock Doors: " + currentTimeAguante.ToString("f2");
        textCantidadTiempoAguante.text = "Time to unlock Doors: " + currentTimeAguante.ToString("f2");
        if (currentTimeAguante <=0)
        {
            ManagerMisiones.Instance.textContainers[numeroObjetivo].GetComponent<Text>().text = "Time to unlock Doors: 0.00" + " Completed" ;
            ManagerMisiones.Instance.textContainers[numeroObjetivo].GetComponent<Text>().color = Color.gray;
            if (ManagerMisiones.Instance.textContainers[numeroObjetivo + 1] != null)
            {
                ManagerMisiones.Instance.textContainers[numeroObjetivo + 1].SetActive(true);
            }
            for (int i = 0; i < (objectToDestroy.Count); i++)
            {
                Destroy(objectToDestroy[i].objectToDestroy);
            }
            currentTimeAguante = 0;
            textCantidadTiempoAguante.text = " ";
        }
        
    }
}
[System.Serializable]
public class objToDestroy
{
    [SerializeField] public GameObject objectToDestroy;
}