using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePhysics : MonoBehaviour
{
    [SerializeField] int cantRebotes = 2;

    [SerializeField] GameObject prefabExplosionRange;

    [SerializeField] GameObject vfxGrenadeExplosion;

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            cantRebotes--;
            if (cantRebotes <= 0)
            {
                StartCoroutine(ComiezaExplosion());
            }
        }
    }

    IEnumerator ComiezaExplosion()
    {

        GameObject vfxExplosion = Instantiate(vfxGrenadeExplosion, this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        GameObject newExplosion = Instantiate(prefabExplosionRange, this.transform.position, this.transform.rotation);
        Destroy(vfxExplosion);
        Destroy(this.gameObject);
    }
}
