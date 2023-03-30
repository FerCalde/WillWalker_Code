using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorEnemigosController : MonoBehaviour
{
    public int cantidadEnemigosNivel = 5;

    [SerializeField] int numeroObjetivo;
    public int enemigosMataos = 0;

    // Update is called once per frame
    void Update()
    {
        enemigosMataos = GameManager.Instance.contadorKillsEnemy;

        UpdateTextKill();
        if (cantidadEnemigosNivel <= GameManager.Instance.contadorKillsEnemy)
        {
            FinLevel.Instance.ActiveEndGamePanel();

        }
    }

    void UpdateTextKill()
    {

        ManagerMisiones.Instance.textContainers[numeroObjetivo].GetComponent<Text>().text = "Destroy all the enemies: " + GameManager.Instance.contadorKillsEnemy + " / " + cantidadEnemigosNivel;
    }



}
