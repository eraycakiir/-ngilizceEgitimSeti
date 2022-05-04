using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSceneManager : MonoBehaviour
{
    int bolumSayisi;
    AudioClip clip;
    public bool butonBasilsinmi;
    int harfAdet;
    AudioSource[] butunSesKaynaklar;

    private void Start()
    {
        StartCoroutine(HarfleriAcRoutine());
    }
    IEnumerator HarfleriAcRoutine()    //Sýrasyýyla Harfleri Sýralama Kodu
    {
        GameObject obje = this.transform.GetChild(bolumSayisi).gameObject;
        SesiCikar();

        while (harfAdet<3)
        {
            obje.transform.GetChild(harfAdet).GetComponent<CanvasGroup>().DOFade(1,.1f);         
            yield return new WaitForSeconds(.2f);
            harfAdet++;
        }
    }

    void SesiCikar()
    {
        butonBasilsinmi = false;
        Transform obje = this.gameObject.transform.GetChild(bolumSayisi);
        clip = obje.GetComponent<AudioSource>().clip;
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        Invoke("ButonaBasilabir", clip.length);
    }

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
}