using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejorasClaseHacker : MonoBehaviour
{
    int cantidadMejorasHacker = 1;

    HabilidadBase habilidadClase;
    WeaponController cmpWeaponController;

 

    // Start is called before the first frame update
    void Start()
    {
        habilidadClase = GetComponent<HabilidadClase>();
        cmpWeaponController = GetComponent<WeaponController>();

        cantidadMejorasHacker = PlayerPrefs.GetInt("MejorasClaseHacker");

        if (cantidadMejorasHacker > 1)//2Mejoras
        {
            //desbloqueas el Arma Secundaria
            cmpWeaponController.UnlockSecondaryWeapons();
        }
        if (cantidadMejorasHacker > 2)//3Mejora
        { 
            habilidadClase.UnlockHability();
        }
    }
}
