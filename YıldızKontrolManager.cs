using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YıldızKontrolManager : MonoBehaviour
{   [SerializeField]
    GameObject doluYildiz1, doluYildiz2, doluYildiz3;
    [SerializeField]
    GameObject parlamaYildiz1,parlamaYildiz2, parlamaYildiz3;
    public void YildiziParlat(int gelenDeger)                 //Doğru bilince parlaklık artrırma kodu
    {
        if (gelenDeger < 12)
        {
            parlamaYildiz1.GetComponent<RectTransform>().DOScale(1, .2f).SetEase(Ease.OutBack);
            doluYildiz1.GetComponent<Image>().fillAmount = gelenDeger / 12f;
        }
        else if (gelenDeger >= 12 && gelenDeger < 24)
        {
            parlamaYildiz2.GetComponent<RectTransform>().DOScale(1, .2f).SetEase(Ease.OutBack);
            doluYildiz2.GetComponent<Image>().fillAmount = (gelenDeger-12) / 12f;
        }
        else if (gelenDeger >= 24 && gelenDeger < 36)
        {
            parlamaYildiz2.GetComponent<RectTransform>().DOScale(1, .2f).SetEase(Ease.OutBack);
            doluYildiz3.GetComponent<Image>().fillAmount = (gelenDeger-24) / 12f;
        }

        Invoke("ParlakligiGider", .5f);

    }  


    void ParlakligiGider()
    {
        parlamaYildiz1.GetComponent<RectTransform>().DOScale(0, .2f);
        parlamaYildiz2.GetComponent<RectTransform>().DOScale(0, .2f);
        parlamaYildiz3.GetComponent<RectTransform>().DOScale(0, .2f);
    }
}
