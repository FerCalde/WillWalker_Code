using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemyFinal : VidaEnemyBase
{
    [SerializeField] protected GameObject nextObjetive;
    [SerializeField] float delayForEndLevel = 1.5f;

    protected GameObject goPlayer;
    public float distanceVista = 10f;

    public override IEnumerator Morir()
    {
        GetComponent<Animator>().SetBool("die", true);
        nextObjetive.SetActive(true);
        yield return new WaitForSeconds(delayForEndLevel);
        FinLevel.Instance.ActiveEndGamePanel();
    }
    protected override void Start()
    {
        base.Start();
        
    }
    protected override void Update()
    {
        base.Update();
        if(FinLevel.Instance.press != null && FinLevel.Instance.press.activeSelf == false)
        {
            nextObjetive.SetActive(false);
        }

        if (goPlayer == null)
        {
           goPlayer = GameManager.Instance.goPlayer;
        }
        if (goPlayer != null)
        {
            if (Vector3.Distance(this.transform.position, goPlayer.transform.position) <= distanceVista)
            {
                GetComponent<Animator>().SetBool("view", true);
                float lookX = goPlayer.transform.position.x;
                float lookZ= goPlayer.transform.position.z;
                Vector3 lookPl = new Vector3(lookX, 1f, lookZ );
                this.transform.LookAt(lookPl);
            }
            else
                GetComponent<Animator>().SetBool("view", false);
        }

    }
}
