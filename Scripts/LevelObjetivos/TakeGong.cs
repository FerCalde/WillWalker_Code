using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TakeGong : MonoBehaviour
{
    public bool enObjetivo = false;
    public GameObject pressText;

    AudioSource cmpAudioSource;

    [SerializeField] string textObjetivo;
    [SerializeField] GameObject puntoRuta;
    bool isTaked = false;

    void Start()
    {
        isTaked = false;
        cmpAudioSource = this.GetComponent<AudioSource>();
        if (cmpAudioSource != null)
        {
            cmpAudioSource.playOnAwake = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (enObjetivo)
        {

            if (!isTaked)
            {
                //pressText = FinLevel.Instance.press;
                FinLevel.Instance.press.SetActive(true);
                FinLevel.Instance.press.GetComponent<Text>().text = textObjetivo;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(puntoRuta);
                isTaked = true;
                FinLevel.Instance.press.GetComponent<Text>().text = "";
                FinLevel.Instance.press.SetActive(false);
                if (cmpAudioSource != null)
                {
                    cmpAudioSource.Play();
                }
                FindObjectOfType<GongCheckerMonasterio>().GongIsTake(this.gameObject);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            enObjetivo = true;
            //pressText = FinLevel.Instance.press;
           
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            enObjetivo = true;
            //pressText.GetComponent<Text>().text = "Press E to " + textObjetivo;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == 8)
        {
            FinLevel.Instance.press.SetActive(false);
            enObjetivo = false;
        }
    }
}