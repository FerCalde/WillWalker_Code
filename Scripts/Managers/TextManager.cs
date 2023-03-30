using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : SingletonTemporal<TextManager>
{
    [SerializeField] [TextArea] public string[] text_Titulo;
    [SerializeField] [TextArea] public string[] text_descripcionTitulo;

    [SerializeField] [TextArea] public string[] text_objetivoPrincipal;
    [SerializeField] [TextArea] public string[] text_subObjetivoPrincipal;

    [SerializeField] [TextArea] public string[] text_objetivoSecundario;
    [SerializeField] [TextArea] public string[] text_subObjetivoSecundario;

}
