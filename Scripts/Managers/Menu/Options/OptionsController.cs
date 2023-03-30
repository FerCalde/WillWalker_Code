using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] GameObject panelOptions;
    [SerializeField] GameObject panelMenu;
    [SerializeField] Slider m_musicSlider, m_sfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        //MusicManager.Instance.SetVolumeMusic();
        panelOptions.SetActive(false);
        //m_musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    void OnEnable()
    {
        float valueSlider = PlayerPrefs.GetFloat("MusicVolume");
        m_musicSlider.value = valueSlider;
    }
    public void ReturnMenu()
    {
        //MusicManager.Instance.MusicVolumeSave = m_musicSlider.value;
        //MusicManager.Instance.SfxVolumeSave = m_sfxSlider.value;
        panelOptions.SetActive(false);
        if (panelMenu != null)
        {
            panelMenu.SetActive(true);
        }
    }
    public void OnOptions()
    {
        panelOptions.SetActive(true);

        m_musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        if (panelMenu != null)
        {

            panelMenu.SetActive(false);
        }
    }

    public void OnMusicValueChanged()
    {
        MusicManager.Instance.SetVolumeMusic();
        MusicManager.Instance.MusicVolume = m_musicSlider.value;
    }
    public void OnSfxValueChange()
    {
        //MusicManager.Instance.SfxVolume = m_sfxSlider.value;
    }
}
