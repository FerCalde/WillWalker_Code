using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejorasClaseDefault : MonoBehaviour
{
    int cantidadMejorasDefault = 1;

    HabilidadBase habilidadClase;
    WeaponController cmpWeaponController;


 
    // Start is called before the first frame update
    void Start()
    {
        habilidadClase = GetComponent<HabilidadClase>();
        cmpWeaponController = GetComponent<WeaponController>();
        cantidadMejorasDefault = PlayerPrefs.GetInt("MejorasClaseDefault");

        if (cantidadMejorasDefault > 1) //2 Mejoras
        {
            //desbloqueas el Arma Secundaria
            cmpWeaponController.UnlockSecondaryWeapons();
        }
        if (cantidadMejorasDefault > 2) //3 Mejoras
        {
            //Desbloquas Habilidad
            habilidadClase.UnlockHability();
        }
        if (cantidadMejorasDefault >= 3)
        {

        }
    }


}
