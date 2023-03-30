using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportStairs : MonoBehaviour
{
    [SerializeField] GameObject[] stairs;
    [SerializeField] GameObject[] salidas;

    GameObject goPlayer;
    [SerializeField]Transform tpPosition;
    [SerializeField]bool isEndTP = true;
    [SerializeField] float speedTP = 50f;
    [SerializeField] float distEndTP = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        goPlayer = GameManager.Instance.goPlayer;
    }

    void Update()
    {
        if (!isEndTP)
        {
            TeleportFast();

            if (Vector3.Distance(goPlayer.transform.position, tpPosition.position) <= distEndTP)
            {
                goPlayer.GetComponent<Mov>().enabled = true;
                goPlayer.GetComponent<CharacterController>().enabled = true;
                goPlayer.GetComponent<WeaponController>().enabled = true;


                isEndTP = true;

            }
        }
    }



    public void StairWay(GameObject stairTaken)
    {
        for (int i = 0; i <= (stairs.Length - 1); i++)
        {
            if (stairs[i] == stairTaken)
            {
                if (goPlayer == null)
                {
                    goPlayer = GameManager.Instance.goPlayer;
                    print("FUNSIONAstairsss");
                    goPlayer.GetComponent<Mov>().enabled = false;
                    goPlayer.GetComponent<CharacterController>().enabled = false;
                    goPlayer.GetComponent<WeaponController>().enabled = false;
                    tpPosition = salidas[i].transform;
                    isEndTP = false;
                }
                else
                {
                    goPlayer.GetComponent<Mov>().enabled = false;
                    goPlayer.GetComponent<CharacterController>().enabled = false;
                    goPlayer.GetComponent<WeaponController>().enabled = false;
                    tpPosition = salidas[i].transform;
                    isEndTP = false;
                }
            }
        }
    }

    void TeleportFast()
    {
        float step = speedTP * Time.deltaTime;
        Vector3.MoveTowards(goPlayer.transform.position, tpPosition.position, step);

    }

}
