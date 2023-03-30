﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPointer : MonoBehaviour
{
    public Transform[] targets;
    public GameObject arrow;
    int i = 0;

  
    void LateUpdate()
    {
        if ((targets.Length - 1) >= i) //Comprobar que no se sale del array (Bugs)
        {
            if (targets[i] != null)
            {
                float dist = Vector3.Distance(targets[i].position, transform.position);
                if (dist < 4f)
                {
                    arrow.SetActive(false);
                }
                else
                {
                    arrow.SetActive(true);
                }
                transform.LookAt(targets[i]);
            }
            else
            {
                i++;
            }
        }
        else
        {
            i = (targets.Length - 1);//Setear ultimo target del quest pointer
        }
       
    }
}
