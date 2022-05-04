using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SearchButonManager : MonoBehaviour
{
    AudioSource audioSource;

    public bool dogrumu;
    SearchExeciseManager searchExeciseManager;
    AudioSource[] butunSesKaynaklar;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        searchExeciseManager = Object.FindObjectOfType<SearchExeciseManager>();
    }
    void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
 
    }


    public void SesCikar()
    {
        if (audioSource && searchExeciseManager.butonBasilsinmi)                       //SesKodlarý
        {
            TumSeslerDurdur();
            audioSource.Play();
            
        }
        if (dogrumu && searchExeciseManager.butonBasilsinmi )
        {
            TumSeslerDurdur();
            audioSource.Play();
            searchExeciseManager.PanelHareketEttir();
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
