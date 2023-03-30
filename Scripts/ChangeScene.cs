using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    bool doOnce = false;
    [SerializeField] int sceneToGo = 1;
  
    public void ChangeScenes()
    {
        if (doOnce == false)
        {
            GameObject.FindObjectOfType<LoadAsync>().LevelLoader(sceneToGo);
            doOnce = true;
        }
        //SceneManager.LoadScene("nextScene");
       
    }
    public void MainMenu()
    {
        if (doOnce == false)
        {
            GameObject.FindObjectOfType<LoadAsync>().LevelLoader(1);
            doOnce = true;
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    
}
