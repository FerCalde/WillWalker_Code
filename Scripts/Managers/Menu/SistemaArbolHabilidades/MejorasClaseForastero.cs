using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejorasClaseForastero : MonoBehaviour
{
    int cantidadMejorasForastero = 1;

    HabilidadBase habilidadClase;
    WeaponController cmpWeaponController;
   

    // Start is called before the first frame update
    void Start()
    {
        habilidadClase = GetComponent<HabilidadClase>();
        cmpWeaponController = GetComponent<WeaponController>();

        cantidadMejorasForastero = PlayerPrefs.GetInt("MejorasClaseForastero");

        if (cantidadMejorasForastero > 1) //2 Mejoras
        {
            //desbloqueas el Arma Secundaria
            cmpWeaponController.UnlockSecondaryWeapons();
        }
        if (cantidadMejorasForastero > 2) //3 Mejoras
        {
            //Desbloquas Habilidad
            habilidadClase.UnlockHability();
        }
    }
}
