using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : SingletonTemporal<WeaponController>
{

    [SerializeField] public List<ArmaBase> armasEquipadas = new List<ArmaBase>();
    ArmaBase armaActual;


    GameObject armaEquipada, armaEquipada2, armaEquipada3;
    [SerializeField] public List<ArmaBase> claseSeleccionadaWeapons = new List<ArmaBase>();

    //float tiempoEspera = 0f; //Utilizado para setear valores de la espera Recarga/Cambiar Arma
    [SerializeField] bool isReloading = false;
    [SerializeField] bool isChangingWeapon = false;
    public bool isBusy = false;

    [SerializeField] Animator cmpAnimator;

    //[SerializeField] Image weaponEquipadaImg;
    //[SerializeField] Image weaponEquipadaImg2;
    [HideInInspector] [SerializeField] GameObject currentWeaponImg, secondaryWeaponImg;
    //[SerializeField] GameObject weaponEquipada2;
    [SerializeField] Text currentAmmoText;
    //[SerializeField] Animator animHud;

    public bool IsReloading { get => isReloading; set => isReloading = value; }



    float delayReloading;

    bool isWeaponSecondUnlocked = false;



    // Start is called before the first frame update
    void Start()
    {

        /*  CODIGO RESERVADO PARA LA UPDATE CUANDO TENGAMOS LAS CLASES HECHAS, PARA ELEGIR LAS ARMAS Y HABILIDADES QUE CORRESPONDEN A CADA ARMA!
         *  NO BORRAR NO BORRAR NO BORRAR
         *  CODIGO EN PROGRESO
        string nameEquiped1 = WeaponSelectManager.weaponNameSelected;
        armaEquipada = GameObject.Find(nameEquiped1);
        if (armaEquipada != null)
        {
            ArmaBase armaSelected1 = armaEquipada.GetComponent<ArmaBase>();
            claseSeleccionadaWeapons.Add(armaSelected1);
        }

        string nameEquiped2 = WeaponSelectManager.weaponNameSelected2;
        armaEquipada2 = GameObject.Find(nameEquiped2);
        if(armaEquipada2 != null)
        {
            ArmaBase armaSelected2 = armaEquipada2.GetComponent<ArmaBase>();
            claseSeleccionadaWeapons.Add(armaSelected2);
        }

        string nameEquiped3 = WeaponSelectManager.weaponNameSelected3;
        armaEquipada3 = GameObject.Find(nameEquiped3);
        if(armaEsquipada3!=null)
        {
            ArmaBase armaSelected3 = armaEquipada3.GetComponent<ArmaBase>();
            claseSeleccionadaWeapons.Add(armaSelected3);
        }
         *  NO BORRAR NO BORRAR NO BORRAR
        */
        ((InputManager)InputManager.Instance).PressFire += ControllerFire;
        ((InputManager)InputManager.Instance).ReleaseFire += ControllerStopFire;
        ((InputManager)InputManager.Instance).ReloadInput += InputRecarga;

        cmpAnimator = GetComponent<Animator>();

        currentWeaponImg = GameObject.Find("CurrentWeaponImage");
        secondaryWeaponImg = GameObject.Find("SecondaryWeaponImage");
        foreach (var arma in armasEquipadas) //Desactivo todas las armas
        {
            arma.weaponModelPrefab.SetActive(false); //DesactivaModeloArma
            arma.gameObject.SetActive(false);

            arma.CurrentAmmoText = currentAmmoText; //Seteo del texto donde ira el Ammo actual del weapon.
        }

        if (claseSeleccionadaWeapons.Count != 0) //En caso de haber una clase seleccionada con sus correspondientes weapons, se actualizan las armas que lleva el player.
        {
            armasEquipadas = new List<ArmaBase>();
            armasEquipadas = claseSeleccionadaWeapons;
        }


        armaActual = armasEquipadas[0]; //seteo arma actual
        armaActual.gameObject.SetActive(true);
        armaActual.weaponModelPrefab.SetActive(true);//Activa modelo del arma

        CheckerAnimator();


        ChangeWeaponInHUD();

        armaActual.BulletScreen();
    }



    // Update is called once per frame
    void Update()
    {
        if (!isReloading && !isChangingWeapon && !isBusy)
        {
            CambiarWeapon(); //Es instantáneo.

            // InputDisparo();
            // InputRecarga();
        }

        if (isReloading)
        {
            if (Time.time >= delayReloading)
            {
                AnimEventFinishReload();

                ControllerStopFire();
            }
        }

    }

    private void InputRecarga() //TIEMPO DE RECARGA CONTROLADO POR DURACION ANIMACION!
    {
        // if (Input.GetKeyDown(KeyCode.R)) //Press R
        //{
        if (!isReloading && !isChangingWeapon && !isBusy)
        {
            armaActual.SoltarGatillo();

            isReloading = true;

            armaActual.Recargar();

            armaActual.BulletScreen();
            //animHud.SetBool("recargando", true);

            //Anim.SetBool("Reloading", true);
        }
        //}
    }
    public void autoReloadController()
    {
        armaActual.SoltarGatillo();

        isReloading = true;

        armaActual.Recargar();

        armaActual.BulletScreen();
        //animHud.SetBool("recargando", true);

        //Anim.SetBool("Reloading", true);
    }

    public void StartReload(float delayWeaponReload)
    {
        delayReloading = Time.time + delayWeaponReload;
    }

    void ControllerFire()
    {
        if (!isReloading && !isChangingWeapon && !isBusy)
        {

            armaActual.ApretarGatillo();
            armaActual.BulletScreen();
        }

    }
    public void ControllerStopFire()
    {
        armaActual.SoltarGatillo();
        if (armaActual.isGrenade)
        {
            cmpAnimator.ResetTrigger("Grenade");
        }
        else
        {
            cmpAnimator.ResetTrigger("Shooting");
        }
    }

    private void CambiarWeapon()
    {
        for (int i = 1; i <= armasEquipadas.Count; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                if (isWeaponSecondUnlocked) //ARBOL HABILIDADES! IMPEDIR CAMBIAR WEAPON
                {

                    armaActual.SoltarGatillo();
                    armaActual.weaponModelPrefab.SetActive(false); //DesactivaModeloArma
                    armaActual.gameObject.SetActive(false); //Desactivo el arma
                   // secondaryWeaponImg.GetComponent<Image>().sprite = armaActual.ScreenWeaponImg;
                    /*if (secondaryWeaponImg.GetComponent<Image>().sprite != currentWeaponImg.GetComponent<Image>().sprite) //BugControl cambio arma
                    {
                        secondaryWeaponImg.GetComponent<Image>().sprite = armaActual.ScreenWeaponImg;
                    }*/

                    armaActual = armasEquipadas[i - 1];
                    armaActual.gameObject.SetActive(true);
                    armaActual.weaponModelPrefab.SetActive(true);  //Activa modelo del arma
                    CheckerAnimator();


                    ChangeWeaponInHUD();    //Update Imagen del arma equipada


                }
            }

        }
    }
    public void CheckerAnimator()
    {
        //Layer 1-> 2HandWeapon
        //Layer 2-> OneHandWeapon
        //Layer 3-> Greanade

        //print("Cambio Layer");
        //print(Anim.GetLayerWeight(4));
        if (cmpAnimator.GetLayerWeight(4) == 0)
        {
            cmpAnimator.SetLayerWeight(4, 0f);
        }
        if (armaActual.isGrenade)
        {
            cmpAnimator.SetLayerWeight(3, 1f);
            cmpAnimator.SetLayerWeight(1, 0f);
            cmpAnimator.SetLayerWeight(2, 0f);
            //Anim.SetLayerWeight(4, 0f);
        }
        else if (armaActual.isOneHandWeapon && !armaActual.isGrenade)
        {
            cmpAnimator.SetLayerWeight(2, 1f);
            cmpAnimator.SetLayerWeight(1, 0f);
            cmpAnimator.SetLayerWeight(3, 0f);
            //Anim.SetLayerWeight(4, 0f);
        }
        else if (!armaActual.isOneHandWeapon && !armaActual.isGrenade)
        {
            cmpAnimator.SetLayerWeight(1, 1f);
            cmpAnimator.SetLayerWeight(2, 0f);
            cmpAnimator.SetLayerWeight(3, 0f);
        }

    }

    private void ChangeWeaponInHUD()
    {


        //currentWeaponImg.GetComponent<Image>().sprite = armaActual.ScreenWeaponImg;
        armaActual.BulletScreen();

    }


    //EVENTOS ANIMACION

    public void AnimEventLanzarGrenade() //Activa eventos para instanciar la granada
    {
        armaActual.GetComponent<LanzagranadaRalenti>().EventLanzarGrenade();
    }

    public void AnimEventAcabaGranada() //Activa AnimEvent para finalizar granada;
    {
        cmpAnimator.ResetTrigger("Grenade");
        isBusy = false;
    }

    public void AnimEventFinishReload()
    {

        armaActual.FinishReload();
        cmpAnimator.SetBool("Reloading", false);
        //animHud.SetBool("recargando", false);
        isReloading = false;
    }

    public void AnimEventLanzarBoomer()
    {
        if (armaActual.GetComponent<Chakram>() != null)
        {
            armaActual.GetComponent<Chakram>().EventLanzarBoomer();
        }
    }

    public void BusyState()
    {
        isBusy = !isBusy;
    }
    public void OcultarActivarArma()
    {
        if (armaActual.weaponModelPrefab.activeSelf == true)
        {
            armaActual.weaponModelPrefab.SetActive(false);

            if (armaActual.GetComponent<Chakram>() != null)
            {
                armaActual.GetComponent<Chakram>().goBoomerang.SetActive(false);
            }
        }
        else
        {
            armaActual.weaponModelPrefab.SetActive(true);

            if (armaActual.GetComponent<Chakram>() != null)
            {
                armaActual.GetComponent<Chakram>().goBoomerang.SetActive(true);
            }
        }

    }

    public void UnlockSecondaryWeapons()
    {
        isWeaponSecondUnlocked = true;
    }
}
