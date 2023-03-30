using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CantidadPuntosMejora : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    void Start()
    {
        
    }
    void Update()
    {
        text.text = PlayerPrefs.GetInt("PuntosMejora").ToString();
    }
}
