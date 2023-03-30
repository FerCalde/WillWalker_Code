using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControllerDontDestroy : SingletonPersistent<TimeControllerDontDestroy>
{

    // Start is called before the first frame update
    void Start()
    {
        if (Time.timeScale < 1)
        {
            Time.timeScale = 1;
        }

    }

}
