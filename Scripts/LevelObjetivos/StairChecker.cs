using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairChecker : MonoBehaviour
{
    //[SerializeField]TeleportStairs StairsController;
    [SerializeField] Transform targetPos;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = targetPos.position;
            /*
            StairsController.StairWay(this.gameObject);
            print("DetectedSTAIRRSSS");*/
        }
    }


}
