using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindKill : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    float timeToDestroy = 5f;
    float time = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        particle.Play();
        print("niRUSIAniOxford");
    }

    // Update is called once per frame
    void Update()
    {
        print(time);
        time += Time.deltaTime;
        if (timeToDestroy <= time)
        {
            Destroy(gameObject);   
        }
    }
}
