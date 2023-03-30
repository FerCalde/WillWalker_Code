using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : SingletonTemporal<LevelManager>
{
    [SerializeField] GameObject[] totalNiveles;
    [SerializeField] GameObject[] modelsParticleFeedback;

    [Tooltip("Aqui debes hacer un array de tantos textos como niveles haya (vamos a tener 3, no te compliques.). a partir de ahi deja volar tu imaginacion y escribe buena mierda")]
    [SerializeField] [TextArea] public string[] text_Titulo;
    [SerializeField] [TextArea] public string[] text_descripcionTitulo;

    [SerializeField] [TextArea] public string[] text_objetivoPrincipal;
    [SerializeField] [TextArea] public string[] text_subObjetivoPrincipal;

    [SerializeField] [TextArea] public string[] text_objetivoSecundario;
    [SerializeField] [TextArea] public string[] text_subObjetivoSecundario;

    [SerializeField] Sprite[] img_Title;

    [SerializeField] GameObject panelMisionInfo;
    public GameObject sonidoMenu;
    int nivelJuegoScene;
    public int nivelesCompletados;
    //int clasePlayer = 0;
    [SerializeField] int nivelesPreviosJuego_MenuScenes = 6;

    [SerializeField] GameObject[] bonusThinks;
    [SerializeField] int[] notBonusLevel;




    // Start is called before the first frame update
    void Start()
    {
        AppData.Instance.LoadCurrentLevels();
        AppData.Instance.LoadBonusArray();

        nivelesCompletados = AppData.Instance.nivelesCompleted;
        Time.timeScale = 1;
        if (totalNiveles.Length != 0)
        {

            panelMisionInfo.SetActive(false);
            for (int i = 0; i <= (totalNiveles.Length - 1); i++)
            {
                if (i < nivelesCompletados)
                {
                    GameObject particleFeedbackLevel = Instantiate(modelsParticleFeedback[0], totalNiveles[i].transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                    particleFeedbackLevel.transform.SetParent(totalNiveles[i].transform);
                    particleFeedbackLevel.GetComponent<ParticleSystem>().Play();
                    // totalNiveles[i].SetActive(true);
                }
                if (i == nivelesCompletados)
                {
                    GameObject particleFeedbackLevel = Instantiate(modelsParticleFeedback[1], totalNiveles[i].transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                    particleFeedbackLevel.transform.SetParent(totalNiveles[i].transform);
                    particleFeedbackLevel.GetComponent<ParticleSystem>().Play();
                    /*if (AppData.Instance.isBonusCompleted[i] == 1) NO HARIA FALTA XK EL NIVEL QYUE TIENES QUE PASARTE X COJONES NO TIENE BONUS COMPLETAO
                    {
                        //SETEAR TEXTO DEL X;
                        //textoX.text= ""; EJEMPLO pa que salga X
                    }*/
                }
                if (i > nivelesCompletados)
                {
                    totalNiveles[i].GetComponent<Collider>().enabled = false;
                    GameObject particleFeedbackLevel = Instantiate(modelsParticleFeedback[2], totalNiveles[i].transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                    particleFeedbackLevel.transform.SetParent(totalNiveles[i].transform);
                    particleFeedbackLevel.GetComponent<ParticleSystem>().Play();
                    // totalNiveles[i].SetActive(false);

                }


            }
        }
    }

    public void SeleccionNivel(GameObject nivelSelected)
    {
        //LoadCurrentLevels();
        AppData.Instance.LoadCurrentLevels();

        for (int i = 0; i <= (AppData.Instance.nivelesCompleted); i++)
        {
            //Desactivar Collider de los objetos que seleccionan nivel para no interferir con el Menu de Seleccion
            totalNiveles[i].GetComponent<Collider>().enabled = false;
            /*if (totalNiveles[i].GetComponent<Collider>() != null)
            {
            }*/

            if (nivelSelected == totalNiveles[i])
            {
                for (int z = 0; z <= notBonusLevel.Length - 1; z++)
                {
                    if (i == notBonusLevel[z])
                    {
                        bonusThinks[0].SetActive(false);
                        bonusThinks[1].SetActive(false);
                        bonusThinks[2].SetActive(false);
                        bonusThinks[3].SetActive(false);
                        z = 1000;
                    }
                    else
                    {
                        bonusThinks[0].SetActive(true);
                        bonusThinks[1].SetActive(true);
                        bonusThinks[2].SetActive(true);
                        bonusThinks[3].SetActive(true);
                    }
                }
                if (panelMisionInfo != null)
                {
                    InfoMisionHUDCity cmpHUDmisioninfo = panelMisionInfo.GetComponent<InfoMisionHUDCity>();

                    //Sirve para guardar el valor del nivel, en caso de haber sido ya superado, guardamos 0 para que al terminarlo no sume ese point al score;
                    if (i < AppData.Instance.nivelesCompleted)
                    {
                        AppData.Instance.SaveLevelIsCompleted(0);
                    }
                    //En caso de que sea igual al numero de niveles completados, significa que es el nivel actual que debemos completar, por lo que guardamos 1 para que se sume al score posteriormente
                    if (i == AppData.Instance.nivelesCompleted)
                    {
                        AppData.Instance.SaveLevelIsCompleted(1);

                    }
                    //SETEO DEL CANVASBONUS
                    if (AppData.Instance.isBonusCompleted[i] == 1)
                    {
                        bonusThinks[2].SetActive(true);
                    }
                    else
                    {
                        bonusThinks[2].SetActive(false);
                    }


                    //Setear las variables del nivel seleccionado en el HUD-> Info de mision, img del titulo...
                    cmpHUDmisioninfo.SetCurrentMissionInfo(text_descripcionTitulo[i], text_objetivoPrincipal[i], text_subObjetivoPrincipal[i], text_objetivoSecundario[i], text_subObjetivoSecundario[i], img_Title[i]);
                    panelMisionInfo.SetActive(true);
                    //Suma las escenas anteriores de Menus. 
                    nivelJuegoScene = i + nivelesPreviosJuego_MenuScenes;
                }
            }


            PlaySound(sonidoMenu, this.transform.position, 2f);
        }
    }
    public void GoLevel()
    {
        GetComponent<LoadAsync>().LevelLoader(nivelJuegoScene);
    }

    public void CloseSeleccionNivelPanel()
    {
        for (int i = 0; i <= (AppData.Instance.nivelesCompleted); i++)
        {
            totalNiveles[i].GetComponent<Collider>().enabled = true;
        }
        panelMisionInfo.SetActive(false);
        /*if (panelMisionInfo != null)
        {
        }*/
    }
    void PlaySound(GameObject sonido, Vector3 pos, float duracion)
    {
        Destroy(Instantiate(sonido, pos, Quaternion.identity), 2f);
    }


}


/* void Update()
 {
     if (Input.GetKeyDown(KeyCode.U))
     {
         ResetLevels();
     }
 }*/
//AntiguaManera de Cargar Niveles
/*public void GoLevel()
{
    //funcion matemática que suma al nivel seleccionado, el total de niveles* la clase Seleccionada para llevar al nivel correcto
    int nivelSeleccionadoYClase = nivelJuegoScene + (totalNiveles.Length * clasePlayer);

    FindObjectOfType<LoadAsync>().LevelLoader(nivelSeleccionadoYClase);
}*/
/* public void UpdateClaseSeleccionada(int claseSeleccionada)
 {
     clasePlayer = claseSeleccionada;
 }*/
/*public void UnlockNextLevel()
{
nivelesCompletados++;
SaveCurrentGame();
}*/
/* void SaveCurrentGame()
{
    AppData.Instance.SaveCurrentGame(nivelesCompletados);
}
void LoadCurrentLevels()
{
    nivelesCompletados = PlayerPrefs.GetInt("NivelesCompletados");
}

void ResetLevels()
{
    nivelesCompletados = 0;
    SaveCurrentGame();
}*/
/* void SetearParticleEffectCiudad(int modelType, int currentNivel)
{
Instantiate(modelsParticleFeedback[1], totalNiveles[i].transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
}*/
