using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportTorreta : MonoBehaviour
{
    public float rango;
    public GameObject objVisualRango;
    StateMachine stateManager;
    int layerMask = 1 << 8 | 1 << 9;
    public bool attackDronON = false;
    [HideInInspector]public GameObject dronContainer;
    public GameObject centro;
    public int totalDronsLimit;
    public GameObject padre;
    public bool empty=false;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GetComponent<StateMachine>();
        newScale(objVisualRango, rango);
    }

    // Update is called once per frame
    void Update()
    {
        if (dronContainer == null)
        {
            attackDronON = false;
        }
        else
        {
            if (!dronContainer.activeSelf )
            {
                attackDronON = false;
            }
        }

        if (GetComponent<VidaEnemyBase>().VidaActual <= 0)
        {
            stateManager.ChangeState("Muerte");
        }
    }
    public void newScale(GameObject theGameObject, float newSize)
    {

        float sizeX = theGameObject.GetComponent<Renderer>().bounds.size.x;
        float sizeZ = theGameObject.GetComponent<Renderer>().bounds.size.z;

        Vector3 rescale = theGameObject.transform.localScale;

        rescale.x = newSize * rescale.x / sizeX * 2;
        rescale.z = newSize * rescale.z / sizeZ * 2;


        theGameObject.transform.localScale = rescale;

    }
}
