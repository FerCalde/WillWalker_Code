using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class OpenDoor : MonoBehaviour
{
    [SerializeField] GameObject[] puertasOpening;
    bool enObjetivo = false;
    [SerializeField]GameObject nextObjetivo;

    bool isTaked = false;


    // Update is called once per frame
    void Update()
    {

        if (enObjetivo)
        {

            if (!isTaked)
            {
                FinLevel.Instance.press.SetActive(true);
                FinLevel.Instance.press.GetComponent<Text>().text = "Open the door";
            }

            if (Input.GetKey(KeyCode.E))
            {
                for (int i = 0; i <= (puertasOpening.Length - 1); i++)
                {
                    FinLevel.Instance.press.SetActive(false);
                    isTaked = true;
                    Destroy(puertasOpening[i]);
                    if (i == puertasOpening.Length - 1)
                    {
                        Destroy(this.gameObject);
                    }

                }

            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 8)
        {
            enObjetivo = true;
            //FinLevel.Instance.press.GetComponent<Text>().text = "Press E to open the door";
            //FinLevel.Instance.press.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == 8)
        {
            FinLevel.Instance.press.SetActive(false);
            enObjetivo = false;
        }
    }

}
