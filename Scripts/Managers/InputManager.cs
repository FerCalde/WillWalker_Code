using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    HabilidadBase habilidadClase;
    HabilidadBase habilidadRewind;

    public delegate void OnStart();
    public event OnStart PressFire;
    public event OnStart ReleaseFire;
    public event OnStart ReloadInput;


    public static InputManager Instance
    {
        get;
        private set;
    }

    public void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        ((GameManager)GameManager.Instance).SetPlayerRef += SetPlayer;
    }

    public void SetPlayer(GameObject go)
    {
        print(go.name);
        habilidadClase = go.GetComponent<HabilidadClase>();
        habilidadRewind = go.GetComponent<RewindManagment>();
        //habilidad = GameObject.FindGameObjectWithTag("Player").GetComponent<HabilidadBase>();
        if (habilidadRewind == null)
        {
            habilidadRewind = go.GetComponent<RewindManagment>();
        }
        if (habilidadClase == null)
        {
            habilidadClase = go.GetComponent<HabilidadClase>();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (habilidadClase == null)
        {
            habilidadClase = GameManager.Instance.goPlayer.GetComponent<HabilidadClase>();
        }
        if (Input.GetMouseButtonDown(0))
        {
            PressFire();
        }
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseFire();
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            RewindManagment.StartRewinding();

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            habilidadClase.Activar();
        }
    }


}
