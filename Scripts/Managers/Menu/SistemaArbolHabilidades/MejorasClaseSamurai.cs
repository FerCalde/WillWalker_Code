using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejorasClaseSamurai : MonoBehaviour
{
    int cantidadMejorasSamurai = 1;

    HabilidadBase habilidadClase;
    WeaponController cmpWeaponController;
    KatanaAttack katana;



    // Start is called before the first frame update
    void Start()
    {
        habilidadClase = GetComponent<HabilidadClase>();
        cmpWeaponController = GetComponent<WeaponController>();
        katana = GetComponent<KatanaAttack>();
        AppData.Instance.LoadCurrentsMejoras();

        cantidadMejorasSamurai = PlayerPrefs.GetInt("MejorasClaseSamurai");

        if (cantidadMejorasSamurai > 1) //2 Mejoras
        {
            //desbloqueas el Arma Secundaria
            cmpWeaponController.UnlockSecondaryWeapons();
        }
        if (cantidadMejorasSamurai > 2) //3 Mejoras
        {
            //Desbloquas Habilidad
            habilidadClase.UnlockHability();
        }

        if (cantidadMejorasSamurai >= 3)
        {
            katana.parryUnlock = true;
        }
    }
}
