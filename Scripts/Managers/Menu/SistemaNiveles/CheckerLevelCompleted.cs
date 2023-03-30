using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckerLevelCompleted : MonoBehaviour
{
    [SerializeField] int nextScene = 1;
    //[SerializeField] float puntuacionParaSuperarNivel = 100;

    public void CheckScore()
    {
        print(nextScene + " checkScire");
        //LevelManager.Instance.UnlockNextLevel();
        GameManager.Instance.UnlockNextLevel(nextScene, this.gameObject);

        //GetComponent<LoadAsync>().LevelLoader(nextScene);
    }
    public void RestartLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        print(currentLevel+" is level to restart");
        GameManager.Instance.UnlockNextLevel(currentLevel, this.gameObject);
        //GetComponent<LoadAsync>().LevelLoader(currentLevel);
    }

    public void GoLevelScene(int sceneToGo)
    {
        print(sceneToGo + " GoLevelSceneee");
        GetComponent<LoadAsync>().LevelLoader(sceneToGo);
    }

}
