using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEyeRay : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField]float maxDist;
    LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDist))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.gameObject.GetComponent<EnemyDeadEyeEffect>()!= null)
            {
                hit.collider.gameObject.GetComponent<EnemyDeadEyeEffect>().AddTrack();
            }
            if (hit.collider)
            {
                lr.SetPosition(1, new Vector3(0, 0, hit.distance));
            }
           
        }
        else
        {
            lr.SetPosition(1, new Vector3(0, 0, maxDist));
        }
    }
}
