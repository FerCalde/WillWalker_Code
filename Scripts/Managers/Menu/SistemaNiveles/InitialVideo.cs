using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InitialVideo : MonoBehaviour
{
    float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("MusicVolume", 0.5f);
        timer = 5f;
       // StartCoroutine(WaitForVideoEnds());
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
    /*IEnumerator WaitForVideoEnds()
    {
        new WaitForSeconds(10f);
        yield return null;
    }
    */
}
