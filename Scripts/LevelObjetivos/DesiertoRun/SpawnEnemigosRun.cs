using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigosRun : MonoBehaviour
{
    [SerializeField] float timeMinRandom = 2f;
    [SerializeField] float timeMaxRandom = 4f;

    public float timeWait = 10f;

    [SerializeField] GameObject[] enemyPref;

    // Start is called before the first frame update
    void Start()
    {
        timeWait = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeWait > 0)
        {
            timeWait -= Time.deltaTime;
        }
        else
        {
            int indexEnemy = Mathf.RoundToInt(Random.Range(0, enemyPref.Length - 1));
            GameObject enemyInstanciado = Instantiate(enemyPref[indexEnemy], this.transform);
            enemyInstanciado.transform.parent = null;
            print(enemyInstanciado.name);
            Destroy(enemyInstanciado, 60f);
            timeWait = Random.Range(timeMinRandom, timeMaxRandom);
        }
    }

}
