using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMorteroSube : MonoBehaviour
{
    Rigidbody miRb;
    public float speed;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        miRb = GetComponent<Rigidbody>();
        miRb.AddForce(transform.up * speed * 100);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            gameObject.SetActive(false);
        }
    }
}
