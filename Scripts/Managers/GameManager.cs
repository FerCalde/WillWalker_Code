using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonTemporal<GameManager>
{
    [SerializeField] bool isPaused = false;
    public bool IsPaused { get => isPaused; }

    public GameObject goPlayer;
    public int contadorKillsEnemy;
    public int contadorRespeto;
    public int contadorCombo;
    public string score;
    public float tiempoCombo;
    //Text textoCombos;
    //GameObject goTextCombos;
    bool abletoCount = false;

    Color colorAntiguo;
    float lastKill;
    public GameObject sonidoCombo1;
    public GameObject sonidoCombo2;
    GameObject splatter;

    int nivelesCompletados = 0;

    [HideInInspector]public InputManager cmpInputManager;
    //bool gameEnd = false;

    [Tooltip("Poner el numero de enemigos que puedes eliminar de este nivel")]
    public int cantidadEnemigosLevel = 0;



    public delegate void OnSetPlayer(GameObject refPlayer);
    public event OnSetPlayer SetPlayerRef;
    //public event OnSetPlayer EnemyKilled;



    // Start is called before the first frame update
    void Start()
    {
        if (cmpInputManager == null)
        {
            cmpInputManager = this.GetComponent<InputManager>();
        }

        if (isPaused)
        {
            PauseGame();
        }
        if (Time.timeScale < 1)
        {
            Time.timeScale = 1;
        }
        contadorRespeto = 0;

        goPlayer = GameObject.FindGameObjectWithTag("Player");

        if (goPlayer == null)
        {
            goPlayer = GameObject.FindGameObjectWithTag("Player");
        }
        //goTextCombos = GameObject.Find("ComboText");

        /*if (goTextCombos != null)
        {
            textoCombos = goTextCombos.GetComponent<Text>();
        }

        colorAntiguo = textoCombos.color;
        goTextCombos.SetActive(false);
        */


        LoadCurrentLevels();
        //splatter = GameObject.Find("ImageSplatter");
        //splatter.SetActive(false);


    }
    public void SetPlayerReff(GameObject refPlayer)
    {
        goPlayer = refPlayer;
        //SetPlayerRef(refPlayer);
    }

    /*private void Update()
    {
        lastKill -= Time.deltaTime;

        if (lastKill <= 0)
        {
            lastKill = 0;
            contadorCombo = 0;
            /*if (textoCombos != null)
            {
                textoCombos.text = " ";
            }
            if (splatter != null)
            {
                splatter.SetActive(false);
            }

              goTextCombos.SetActive(false);
        }
        else
        {
            if (abletoCount)
            {
                ContadorCombo();
            }
       goTextCombos.SetActive(true);

             print("combos");
        }

    }*/

   /* public IEnumerator ActivarTextoCombos()
    {
        if (contadorCombo >= 2)
        {
            // textoCombos.text = "Combo X" + Mathf.RoundToInt(contadorCombo).ToString();
            //  goTextCombos.SetActive(true);
            new WaitForSeconds(0.5f);

            //goTextCombos.SetActive(false);
            /*textoCombos.fontSize = 50;
            textoCombos.font.name = ("Lequire");
            textoCombos.color = colorAntiguo;*/
            // splatter.SetActive(false);
            // print("cambio de fuente");
            /*yield return null;
        }
    }*/
    public void PauseGame()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            goPlayer.GetComponent<WeaponController>().ControllerStopFire(); //Dejar de disparar
        }
        else
        {
            Time.timeScale = 1;
        }

        //Desactivo/Activo componentes del player para que se cumpla Pause en Player

        goPlayer.GetComponent<VidaBase>().enabled = !isPaused; //Desactivo vida para evitar Bugs de que el tiempo siga corriendo y muera el Player mientras está en Pausa
        goPlayer.GetComponent<Mov>().enabled = !isPaused;
        goPlayer.GetComponentInChildren<Root>().enabled = !isPaused;
        goPlayer.GetComponent<WeaponController>().enabled = !isPaused;
    }

    public void ContadorMuerte()
    {

        //lastKill = 2;
        //abletoCount = true;
        contadorKillsEnemy++;
        //EnemyKilled(goPlayer);
        //ContadorCombo();

    }
    public void ComboAdmin()
    {
        CombosKillManager.Instance.ComboRecibido();
    }

    /*public void ContadorCombo()
    {
        contadorCombo++;
        StartCoroutine(ActivarTextoCombos());
        if (contadorCombo >= 3 && contadorCombo <= 4)
        {
            /*textoCombos.fontSize = 70;
            textoCombos.color = Color.white;
            textoCombos.font.name = ("Lequire");
            NuevoSonido(sonidoCombo1, this.transform.position, 2f);*/
    //splatter.SetActive(true);

    /* }

     if (contadorCombo >= 5 && contadorCombo <= 6)
     {
         /*textoCombos.fontSize = 70;
         textoCombos.color = Color.white;
         textoCombos.font.name = ("Lequire");
         NuevoSonido(sonidoCombo2, this.transform.position, 2f);*/
    //splatter.SetActive(true);

    /* }

     abletoCount = false;
 }*/

    void NuevoSonido(GameObject sonido, Vector3 pos, float duracion)
    {
        bool modificarPitch = true;
        GameObject obj = Instantiate(sonido, pos, Quaternion.identity);
        if (modificarPitch)
        {
            obj.GetComponent<AudioSource>().pitch *= 1 + Random.Range(-0.2f, 0.2f);
        }
        Destroy(obj, 3f);
    }

    public void FinLevelPauseTime()
    {
        Time.timeScale = 0;
    }

    public void UnlockNextLevel(int sceneToGo, GameObject endGame)
    {
        LoadCurrentLevels();
        // int totalLevels = PlayerPrefs.GetInt("TotalNiveles");


        int checkLevel = PlayerPrefs.GetInt("isNivelCompleted");
        nivelesCompletados += checkLevel;

        if (checkLevel > 0)
        {
            AppData.Instance.WinPuntoMejora();
            AppData.Instance.WinPuntoMejora();
        }

        AppData.Instance.SaveCurrentGame(nivelesCompletados);
        print(sceneToGo + " unlock Recibed");
        endGame.GetComponent<CheckerLevelCompleted>().GoLevelScene(sceneToGo);
    }


    void LoadCurrentLevels()
    {
        AppData.Instance.LoadCurrentLevels();
        nivelesCompletados = AppData.Instance.nivelesCompleted;
    }


}
