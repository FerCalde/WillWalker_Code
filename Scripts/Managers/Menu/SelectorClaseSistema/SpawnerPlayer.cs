using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlayer : MonoBehaviour
{
    [SerializeField] GameObject[] playerClases;
    [SerializeField] GameObject lookCamPlayer;


    // Start is called before the first frame update
    void Start()
    {
        // int claseSeleccionada = PlayerPrefs.GetInt("ClaseActual");
        int claseSeleccionada = AppData.Instance.claseSeleccionada;
        for (int i = 0; i <= playerClases.Length - 1; i++)
        {
            if (i != claseSeleccionada)
            {
                playerClases[i].SetActive(false);
            }
            else
            {
                playerClases[i].SetActive(true);
                playerClases[i].transform.SetParent(null);
                lookCamPlayer.transform.SetParent(playerClases[i].transform);
                //GameManager.Instance.cmpInputManager.SetPlayer(playerClases[i]);
                GameManager.Instance.SetPlayerReff(playerClases[i]);
            }
        }
        Destroy(this.gameObject, 0.5f);
    }

}
