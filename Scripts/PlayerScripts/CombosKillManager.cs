using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CombosKillManager : SingletonTemporal<CombosKillManager>
{
    //COMBO INTERNAL VARS

    public float timeCombos = 4f;
    float currentTimeCombo = 0;
    public int puntosCurrent = 0;
    int maxCombo = 0;
    public int currentComboCount = 1;


    //FEEDBACK SCREEN COMBO VARS
    [SerializeField] Text comboText;
    [SerializeField] Text comboTextIN;
    [SerializeField] Text puntosText;


    // Start is called before the first frame update
    void Start()
    {
        PuntoUpdate();
        ComboOut();
    }

    // Update is called once per frame
    void Update()
    {
        TimeCombosChecker();
    }

    private void TimeCombosChecker()
    {
        currentTimeCombo -= Time.deltaTime;
        
        if (currentTimeCombo <= 0)
        {
            
            
            currentTimeCombo = timeCombos;
            CheckComboEnd();
        }
        else
        {
            
            if (currentComboCount > 1)
            {
                var tempColorplus = comboText.color;
                tempColorplus.a = (currentTimeCombo / timeCombos);
                comboText.color = tempColorplus;
            }
            
        }
    }
    public void StopComboByDamage()
    {
        currentComboCount = 1;
        if (puntosCurrent > 0)
        {
            puntosCurrent--;
            
        }
        ComboOut();
        PuntoUpdate();
    }

    void CheckComboEnd()
    {
        
        if (currentComboCount > 1)
        {
            currentComboCount--;
            if (currentComboCount <= 1)
            {
                ComboOut();
            }
            else
            {
                ComboIn();
            }
            
        }
    }

    public void ComboRecibido()
    {
        currentTimeCombo = timeCombos;
        puntosCurrent = puntosCurrent + currentComboCount;
        currentComboCount++;
        PuntoUpdate();
        ComboIn();
    }

    void ComboIn()
    {
        comboText.text = "X" + currentComboCount.ToString();
        
    }
    void ComboOut()
    {
        comboText.text = "";
    }
    void PuntoUpdate()
    {
        puntosText.text = puntosCurrent.ToString();
        comboTextIN.text = puntosCurrent.ToString();
    }

}
