using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScenas : MonoBehaviour
{
    public string nextScene;
    public int IndexScene;
    bool doOnce;

    [SerializeField] GameObject loadingPanel;

    private void Start()
    {
        Time.timeScale = 1f;
        loadingPanel.SetActive(false);

    }
    public void ChangeScene()
    {
        if (doOnce == false)
        {
            loadingPanel.SetActive(true);

            SceneManager.LoadScene(nextScene);
            doOnce = true;
        }
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoPlay()
    {
        if (doOnce == false)
        {
            GetComponent<LoadAsync>().LevelLoader(IndexScene);
            doOnce = true;
        }
        
    }

}
