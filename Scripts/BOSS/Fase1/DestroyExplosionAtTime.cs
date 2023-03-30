using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosionAtTime : MonoBehaviour
{
    float time = 0f;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 0.3f)
        {
            Destroy(gameObject);
        }
    }
}
