using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoverButonManager : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    Transform harflerPanel;

    GameObject obje;

    private void Awake()
    {
            audioSource =GetComponent<AudioSource>();
        harflerPanel = GameObject.Find("TumHarfler").transform;
    }

   public void SesiCikar()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            obje = this.gameObject;
            Invoke("EkrandaHarfAc", 1f);
           
        }
    }

    void EkrandaHarfAc()
    {
        for (int i = 0; i < harflerPanel.childCount; i++)
        {
            if (this.gameObject.name == harflerPanel.GetChild(i).gameObject.name)
            {
                this.transform.parent.gameObject.SetActive(false);
                harflerPanel.GetChild(i).GetComponent<RectTransform>().DOScale(1, 0.4f).SetEase(Ease.OutBack);
                harflerPanel.GetChild(i).GetComponent<HarfiKesfetManager>().TumDaireleriAc();
                break;
            }
        }
    }

}
