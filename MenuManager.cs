using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject logoImg;
    void Start()
    {
        LogoyuAc();
    }
    void LogoyuAc()         //Logoyu yava� y�kleyerek a�ma kodu
    {
        logoImg.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        logoImg.GetComponent<RectTransform>().DOScale(1, 0.5f);
    }
    public void SahneyeGec(string sahneninAdi)    //Sahneler aras� ge�i� kodu
    {
        SceneManager.LoadScene(sahneninAdi);
    }
   

}
