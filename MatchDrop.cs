using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MatchDrop : MonoBehaviour, IDropHandler
{
    [SerializeField]
    string harf;

    GameObject tasinanHarf;
    public void OnDrop(PointerEventData eventData)
    {
        tasinanHarf = eventData.pointerDrag.gameObject;
        if (harf == tasinanHarf.transform.GetChild(0).GetComponent<Text>().text)
        {
            tasinanHarf.GetComponent<MatchDrag>().yerlestimi = true;
            tasinanHarf.transform.position = this.transform.position;
            tasinanHarf.transform.rotation=this.transform.rotation;
        }
    }
}
