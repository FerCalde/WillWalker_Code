using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : SingletonPersistent<MusicManager>
{

    public AudioSource musicBackground;



    /*public float cmpSonidoAll
    {


    } 
    */
    [Range(0, 1)]
    private float m_musicVolume;
    public float MusicVolume
    {
        get
        {
            return PlayerPrefs.GetFloat("MusicVolume");
            //return m_musicVolume;
        }
        set
        {
            value = Mathf.Clamp(value, 0, 1);
            m_musicVolume = value;
        }
    }

    public float MusicVolumeSave
    {
        get
        {
            return m_musicVolume;
        }

        set
        {
            value = Mathf.Clamp(value, 0, 1);
            PlayerPrefs.SetFloat("MusicVolume", value);
            m_musicVolume = value;
        }
    }

    void Start()
    {
        m_musicVolume = PlayerPrefs.GetFloat("MusicVolume");

        musicBackground = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<AudioSource>();
        SetVolumeMusic();
    }
    public void LoadMusicVolumen()
    {
        m_musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        
        SetVolumeMusic();
    }
    void Update()
    {
        if (musicBackground == null)
        {
            musicBackground = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<AudioSource>();
        }
        else
        {
            SetVolumeMusic();
            //m_musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }

    }
    public void SetVolumeMusic()
    {
        musicBackground.volume = m_musicVolume;
    }



    /*
    public GameObject[] musicObjects;

    [Range(0, 1)]
    private float m_musicVolume;
    public float MusicVolume
    {
        get
        {
            return m_musicVolume;
        }
        set
        {
            value = Mathf.Clamp(value, 0, 1);
            m_musicVolume = value;
        }
    }

    [Range(0, 1)]
    private float m_sfvVolume = 0.5f;

    public float SfxVolume
    {
        get
        {
            return m_sfvVolume;
        }
        set
        {
            value = Mathf.Clamp(value, 0, 1);
            m_sfvVolume = value;
        }
    }

    public float SfxVolumeSave
    {
        get
        {
            return m_sfvVolume;
        }
        set
        {
            value = Mathf.Clamp(value, 0, 1);
            PlayerPrefs.SetFloat("SfxVolume", value);
            m_sfvVolume = value;
        }
    }
    public float MusicVolumeSave
    {
        get
        {
            return m_musicVolume;
        }

        set
        {
            value = Mathf.Clamp(value, 0, 1);
            //PlayerPrefs.SetFloat("MusicVolume", value);
            m_musicVolume = value;
        }
    }
    

    // Start is called before the first frame update
    //void Start()
    {
        m_musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        musicObjects = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        /*musicObjects = GameObject.FindObjectsOfType<AudioSource>();
        if (musicObjects == null)
        {
            musicObjects = GameObject.FindObjectsOfType<AudioSource>();
        }*/
    /*
        SetVolumeMusic();
    }
    public void SetVolumeSfxObjects()
    {
        AudioSource[] sfxObjects = GameObject.FindObjectsOfType<AudioSource>();

        for (int i = 0; i < (sfxObjects.Length - 1); i++)
        {
            if (sfxObjects[i].tag != "BackgroundMusic")
            {
                sfxObjects[i].volume = m_sfvVolume;
            }
            else
            {
                sfxObjects[i].volume = m_musicVolume;
            }
        }

    }

    public void SetVolumeMusic()
    {
        if (musicObjects.Length > 0)
        {
            for (int i = 0; i <= (musicObjects.Length - 1); i++)
            {
                musicObjects[i].GetComponent<AudioSource>().volume = m_musicVolume;
            }
        }
        else if (musicObjects.Length == 0)
        {
            musicObjects = GameObject.FindGameObjectsWithTag("BackgroundMusic");
            if (musicObjects != null)
            {
                SetVolumeMusic();
            }
            GameObject musicAmbient = GameObject.FindGameObjectWithTag("BackgroundMusic");
            if (musicAmbient != null)
            {
                if (musicAmbient.GetComponent<AudioSource>() != null)
                {
                    musicAmbient.GetComponent<AudioSource>().volume = m_musicVolume;
                }
            }
        }
    }

*/
}
