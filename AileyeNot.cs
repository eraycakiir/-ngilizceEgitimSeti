using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AileyeNot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    Text ÝkiSaniyeBasýlýTut;
    [SerializeField]
    Image doldurulcakDaire;
    [SerializeField]
    GameObject AieleNotImg;


    bool butonBasildimi;
    float basiliTutmaSuresi;
    float toplamBasilacakSure = 2f;

    public void OnPointerDown(PointerEventData eventData)    //Hazýr basýlý tutma event kodu
    {
        butonBasildimi = true;
    }
    public void OnPointerUp(PointerEventData eventData)       //Hazýr Basýlý tutma event kodu
    {
        butonBasildimi=false;
    }

    void Update()
    {
        if (butonBasildimi)                                              //eðer butona basýldýysa basýlý tutma süresi artar 
        {
            ÝkiSaniyeBasýlýTut.gameObject.SetActive(true);
            basiliTutmaSuresi += Time.deltaTime;
            if (basiliTutmaSuresi >= toplamBasilacakSure)                 // butona basma iki veya ikiden fazlaysa Img açýlýr       
            {
                butonBasildimi = false;
                ÝkiSaniyeBasýlýTut.gameObject.SetActive(false);
                AieleNotImg.gameObject.SetActive(true);
            }

            doldurulcakDaire.fillAmount = basiliTutmaSuresi / toplamBasilacakSure;     // basýlý tutuldukca daire dolar
        }
        if (!butonBasildimi)                                                           // butondan el çekince daire geriye sarar ve yazý kaybolur
        {
            basiliTutmaSuresi -= Time.deltaTime;
            if (basiliTutmaSuresi <= 0)
            {
                basiliTutmaSuresi = 0;
            }
            ÝkiSaniyeBasýlýTut.gameObject.SetActive(false);
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
