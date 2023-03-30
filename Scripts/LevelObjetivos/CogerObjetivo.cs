using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CogerObjetivo : MonoBehaviour
{
    [SerializeField] public GameObject finalLevel;
    bool enObjetivo = false;
    bool varCogida = false;

    [SerializeField] int numeroObjetivo;
    [SerializeField] string typeObjetive="Take this shit!";
    void Start()
    {
        FinLevel.Instance.GetComponent<Collider>().enabled = false;
    }

    void Update()
    {
        if (enObjetivo)
        {
            if (varCogida == false)
            {
                //press = FinLevel.Instance.press;
                FinLevel.Instance.press.SetActive(true);
                FinLevel.Instance.press.GetComponent<Text>().text = typeObjetive;
                //FinLevel.Instance.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                FinLevel.Instance.GetComponent<Collider>().enabled = true;
                FinLevel.Instance.press.GetComponent<Text>().text = "";
                FinLevel.Instance.press.SetActive(false);

                varCogida = true;
                UpdateTextObjetiveTaked(" Completed ");
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 8)
        {
            enObjetivo = true;
            
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == 8)
        {
            enObjetivo = false;
            FinLevel.Instance.press.GetComponent<Text>().text = "";
            FinLevel.Instance.press.SetActive(false);
        }
    }
    void UpdateTextObjetiveTaked(string setString)
    {

        Debug.Log("entra final");
        //TextManager.Instance.text_subObjetivoPrincipal[numeroObjetivo] = objUp;
        //int varNivel = ManagerMisiones.Instance.nivelActual;
        ManagerMisiones.Instance.textContainers[numeroObjetivo].GetComponent<Text>().text += setString;
        ManagerMisiones.Instance.textContainers[numeroObjetivo].GetComponent<Text>().color = Color.gray;
        if (ManagerMisiones.Instance.textContainers[numeroObjetivo + 1] != null)
        {
            ManagerMisiones.Instance.textContainers[numeroObjetivo + 1].SetActive(true);
        }

    }
}
