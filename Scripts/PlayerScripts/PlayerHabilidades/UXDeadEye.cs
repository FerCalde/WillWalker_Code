using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UXDeadEye : MonoBehaviour
{
    ParticleSystem particle;
    float time = 0f;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Play();
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 5)
        {
            Destroy(this.gameObject);
        }
    }
}
