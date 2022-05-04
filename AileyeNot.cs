using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AileyeNot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    Text �kiSaniyeBas�l�Tut;
    [SerializeField]
    Image doldurulcakDaire;
    [SerializeField]
    GameObject AieleNotImg;


    bool butonBasildimi;
    float basiliTutmaSuresi;
    float toplamBasilacakSure = 2f;

    public void OnPointerDown(PointerEventData eventData)    //Haz�r bas�l� tutma event kodu
    {
        butonBasildimi = true;
    }
    public void OnPointerUp(PointerEventData eventData)       //Haz�r Bas�l� tutma event kodu
    {
        butonBasildimi=false;
    }

    void Update()
    {
        if (butonBasildimi)                                              //e�er butona bas�ld�ysa bas�l� tutma s�resi artar 
        {
            �kiSaniyeBas�l�Tut.gameObject.SetActive(true);
            basiliTutmaSuresi += Time.deltaTime;
            if (basiliTutmaSuresi >= toplamBasilacakSure)                 // butona basma iki veya ikiden fazlaysa Img a��l�r       
            {
                butonBasildimi = false;
                �kiSaniyeBas�l�Tut.gameObject.SetActive(false);
                AieleNotImg.gameObject.SetActive(true);
            }

            doldurulcakDaire.fillAmount = basiliTutmaSuresi / toplamBasilacakSure;     // bas�l� tutuldukca daire dolar
        }
        if (!butonBasildimi)                                                           // butondan el �ekince daire geriye sarar ve yaz� kaybolur
        {
            basiliTutmaSuresi -= Time.deltaTime;
            if (basiliTutmaSuresi <= 0)
            {
                basiliTutmaSuresi = 0;
            }
            �kiSaniyeBas�l�Tut.gameObject.SetActive(false);
            doldurulcakDaire.fillAmount = basiliTutmaSuresi / toplamBasilacakSure;
        }
      
    }
    public void AileNotKapat()          //kapat butonu
    {
        basiliTutmaSuresi = 0;
        butonBasildimi = false;
        AieleNotImg.SetActive(false);
    }
  
}
