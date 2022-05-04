using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
public class MatchDrag : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    CanvasGroup canvasgroup;
    RectTransform rectTransform;
    public bool yerlestimi;
    AudioSource audioSource;

    Vector3 baslangicPos;
    private void Awake()
    {
        audioSource= GetComponent<AudioSource>();
        rectTransform=GetComponent<RectTransform>();
        canvasgroup=GetComponent<CanvasGroup>();
    }
    //Sürüklemeye Baþladýðýnda
    public void OnBeginDrag(PointerEventData eventData)
    {
          audioSource.Play();
          yerlestimi=false;
          baslangicPos = rectTransform.anchoredPosition;
          canvasgroup.alpha= .8f;
          canvasgroup.blocksRaycasts = false;
    }
    //Sürükleme esnasýnda 
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }
    //Sürükleme bittiðinde
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!yerlestimi)
        {
            rectTransform.DOAnchorPos(baslangicPos, .5f);
            canvasgroup.blocksRaycasts = true;
        }
        else
        {
            canvasgroup.blocksRaycasts=false;
            canvasgroup.alpha = 1f;
        }
    }

 

}
