using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteBoss : MonoBehaviour
{
    [HideInInspector] public bool muerte = false;
    float time;
    BossBehaviour bbh;
    [SerializeField] GameObject fxSmoke;
    [SerializeField] GameObject deadFx;
    
    [SerializeField] GameObject shield;
    [SerializeField] GameObject mesh;
    //[SerializeField] GameObject finlevel;
    void Start()
    {
        bbh = GetComponent<BossBehaviour>();
    }
    void Update()
    {
        if (bbh.fase < 3)
        {
            Instantiate(fxSmoke, transform.position, transform.rotation);
            //luzDissaapeard.SetActive(true);
        }
        else
        {
            bbh.anim.SetTrigger("Dead");
        }
        bbh.muerte = true;
        time += Time.deltaTime;
        if (time >= 2)
        {
            if (bbh.fase >= 3)
            {
                Instantiate(deadFx, transform.position, transform.rotation);
            }
            mesh.SetActive(false);
            shield.SetActive(false);
            
            

        }
        if (time >= 8)
        {
            //finlevel.SetActive(true);
            //finlevel.GetComponent<Collider>().transform.localScale = new Vector3(100, 100, 100);
            FinLevel.Instance.ActiveEndGamePanel();
            Destroy(gameObject);
            
        }

    }
}
