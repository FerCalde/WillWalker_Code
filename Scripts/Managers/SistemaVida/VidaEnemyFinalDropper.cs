using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemyFinalDropper : VidaEnemyFinal
{
    [SerializeField] GameObject finalLevel;
    [SerializeField] int numeroObjetivo;

    bool muerto = false;

    public override IEnumerator Morir()
    {
        GetComponent<Animator>().SetBool("die", true);
        nextObjetive.SetActive(true);
        finishTask();
        yield return new WaitForSeconds(0.1f);
    }
    protected override void Start()
    {
        base.Start();
        nextObjetive.SetActive(false);
    }
    void finishTask()
    {
        if (!muerto)
        {
            ManagerMisiones.Instance.textContainers[numeroObjetivo].GetComponent<Text>().text += " Completed";
            ManagerMisiones.Instance.textContainers[numeroObjetivo].GetComponent<Text>().color = Color.gray;
            if (ManagerMisiones.Instance.textContainers[numeroObjetivo + 1] != null)
            {
                ManagerMisiones.Instance.textContainers[numeroObjetivo + 1].SetActive(true);
            }
            muerto = true;
        }
     
    }
    protected override void Update()
    {
        base.Update();
       

        if (goPlayer == null)
        {
            goPlayer = GameManager.Instance.goPlayer;
        }
        if (goPlayer != null)
        {
            if (Vector3.Distance(this.transform.position, goPlayer.transform.position) <= distanceVista)
            {
                GetComponent<Animator>().SetBool("view", true);
            }
            else
                GetComponent<Animator>().SetBool("view", false);
        }

    }
}
