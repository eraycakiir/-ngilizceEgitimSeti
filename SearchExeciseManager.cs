using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SearchExeciseManager : MonoBehaviour
{
    int bolumSayisi;
    public bool butonBasilsinmi;
    AudioClip clip;

    AudioSource[] butunSesKaynaklar;

    YıldızKontrolManager yildizKontrolManager;
    private void Awake()
    {
        yildizKontrolManager = Object.FindObjectOfType<YıldızKontrolManager>();
    }
    private void Start()
    {
        butonBasilsinmi = false;
        TumSeslerDurdur();
        SesiCikar();
    }

    public void PanelHareketEttir()            //PaneliHareketKodları
    {
        if (bolumSayisi >= 36)
        {
            return;
        }
        bolumSayisi++;
        yildizKontrolManager.YildiziParlat(bolumSayisi);
        this.gameObject.GetComponent<RectTransform>().DOLocalMoveX(this.gameObject.GetComponent<RectTransform>().localPosition.x - 1280f, .5f);
        SesiCikar();
    }

    void SesiCikar()
    {
        butonBasilsinmi = false;
        Transform obje = this.gameObject.transform.GetChild(bolumSayisi);
        for (int i = 0; i < 3; i++)
        {
            if (!obje.GetChild(i).GetComponent<SearchButonManager>().dogrumu)
            {
                clip = obje.GetChild(i).GetComponent<AudioSource>().clip;
                break;
            }
        }
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        Invoke("ButonaBasilabir", clip.length);
    }
    //ButonMethodları
    void ButonaBasilabir()
    {
        butonBasilsinmi = true;
    }
    void TumSeslerDurdur()
    {
        butunSesKaynaklar = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource audio in butunSesKaynaklar)
        {
            audio.Stop();
        }
    }
    public void SesiTekrarEt()
    {
        TumSeslerDurdur();
        SesiCikar();
    }

    public void AnaSahneyeDon()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
