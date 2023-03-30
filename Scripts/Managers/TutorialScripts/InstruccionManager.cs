﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InstruccionManager : MonoBehaviour
{
    bool pausedGame = false;
    GameObject goPlayer;
    [SerializeField] GameObject panelTexto;
    [SerializeField] Text textoInstruccion;

    [SerializeField] Transform[] instruccionesTrigger;
    int instruccionActual = 0;

    [SerializeField] GameObject desbloquearSecondWeapon;
    [SerializeField] GameObject desbloquearHab;
    // Start is called before the first frame update
    void Start()
    {
        goPlayer = GameObject.FindGameObjectWithTag("Player");
        textoInstruccion.text = " ";
        panelTexto.SetActive(false);
    }

    public void InstruccionPaused(string instruccionRecibida, GameObject checkDesbloquear)
    {
        if (checkDesbloquear == desbloquearSecondWeapon)
        {
            DesbloquearSecondWep();
        }
        if (checkDesbloquear == desbloquearHab)
        {
            DesbloquearHabi();
        }

        if (goPlayer == null)
        {
            goPlayer = GameObject.FindGameObjectWithTag("Player");

        }
        textoInstruccion.text = instruccionRecibida;

        pausedGame = !pausedGame;

        if (pausedGame)
        {
            Time.timeScale = 0;
            goPlayer.GetComponent<WeaponController>().ControllerStopFire(); //Dejar de disparar
            panelTexto.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            textoInstruccion.text = " ";
            panelTexto.SetActive(false);

        }

        //Desactivo/Activo componentes del player para que se cumpla Pause en Player


        goPlayer.GetComponent<VidaBase>().enabled = !pausedGame; //Desactivo vida para evitar Bugs de que el tiempo siga corriendo y muera el Player mientras está en Pausa
        goPlayer.GetComponent<Mov>().enabled = !pausedGame;
        goPlayer.GetComponentInChildren<Root>().enabled = !pausedGame;
        goPlayer.GetComponent<WeaponController>().enabled = !pausedGame;
        print(pausedGame);
    }

    void DesbloquearSecondWep()
    {
        GameObject.FindObjectOfType<WeaponController>().UnlockSecondaryWeapons();
    }
    void DesbloquearHabi()
    {
        GameObject.FindObjectOfType<HabilidadClase>().UnlockHability();
    }



}
