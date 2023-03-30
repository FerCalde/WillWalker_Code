using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDeadEyeEffect : MonoBehaviour
{
    [SerializeField] GameObject fx_deadEyeSet;
    HabilidadDeadEye tracker;
    NavMeshAgent nav;
    float speedStart;
    public GameObject soniDeadEyeMarcaje;
    bool marcado = false;

    void Start()
    {
        if (AppData.Instance.claseSeleccionada == 2)
        {
            /*tracker = GameObject.FindGameObjectWithTag("Player").GetComponent<HabilidadDeadEye>();*/
            nav = GetComponent<NavMeshAgent>();
            speedStart = nav.speed;
        }
        else
        {
            Destroy(this.GetComponent<EnemyDeadEyeEffect>());
        }
        
    }
    void Update()
    {
        if (tracker != null && nav!=null)
        {
            if (tracker.ejecutarDeadEye == true)
            {
                nav.speed = 0f;
            }
            else
            {
                
                nav.speed = speedStart;
            }
        }
        else
        {
            tracker = GameObject.FindGameObjectWithTag("Player").GetComponent<HabilidadDeadEye>();
            nav = GetComponent<NavMeshAgent>();

        }
    }
    public void AddTrack()
    {
        if (marcado == false)
        {
            nav.speed = 0f;
            fx_deadEyeSet.SetActive(true);
            tracker.enemigosMarcados++;
            tracker.enemigosLista.Insert(0, gameObject);
            //NuevoSonido(soniDeadEyeMarcaje, this.transform.position, 2f);
            marcado = true;
        }


    }
    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }
}
