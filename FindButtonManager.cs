using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindButtonManager : MonoBehaviour
{
    AudioSource audioSource;

    public bool dogrumu;

    AudioSource[] butunSesKaynaklar;
    FindSceneManager findSceneManager;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        findSceneManager =Object.FindObjectOfType<FindSceneManager>();
    }
    public void SesCikar()            //SesAyarlamalarý
    {
        if (audioSource && findSceneManager.butonBasilsinmi)
        {
            TumSeslerDurdur();
            audioSource.Play();

        }
        if (dogrumu && findSceneManager.butonBasilsinmi)
        {
            TumSeslerDurdur();
            audioSource.Play();
        }
    }
    void TumSeslerDurdur()
    {
        butunSesKaynaklar = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource audio in butunSesKaynaklar)
        {
            audio.Stop();
        }
    }
}
