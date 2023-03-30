using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEscopetaFix : MonoBehaviour
{
    [SerializeField] BulletBase[] bala;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<BossBehaviour>() != null)
        {
            for (int i = 0; i < bala.Length; i++)
            {
                bala[i].damageBala = 5f;
            }
        }
        else
        {
            Destroy(this);
        }
        
    }
}
