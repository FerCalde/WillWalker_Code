using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShields : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] GameObject rotateAround;
    private void Start()
    {
        transform.SetParent(null);
    }
    void Update()
    {
        if(rotateAround == null)
        {
            Destroy(gameObject);
        }
        transform.position = rotateAround.transform.position;
        transform.RotateAround(rotateAround.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        
    }
}
