using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DiscoverManager : MonoBehaviour
{
    [SerializeField]
    GameObject harfPrefab;
    [SerializeField]
    Transform harflerHolder;
    [SerializeField]
    AudioClip[] harfSesleri;

    string[] harfler = { "a", "b", "c", "d", "e", "f", "g" };
    int harfAdet;

    private void Start()
    {
        HarflerSirala();
        StartCoroutine(HarfleriGosterRoutine());
    }

    void HarflerSirala()
    {
        for (int i = 0; i < harfler.Length; i++)
        {
            GameObject harfObje = Instantiate(harfPrefab, harfPrefab.transform.position, Quaternion.identity);
            harfObje.transform.GetChild(0).GetComponent<Text>().text = harfler[i];
            harfObje.name= harfler[i];  
            harfObje.transform.SetParent(harflerHolder);
            harflerHolder.localPosition = new Vector3(570, 0, 0);
        }
       
    }

    IEnumerator HarfleriGosterRoutine()
    {
        while (harfAdet < harfler.Length)
        {
            harflerHolder.GetChild(harfAdet).GetComponent<CanvasGroup>().DOFade(1, .5f);
            harflerHolder.GetChild(harfAdet).GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);
            harflerHolder.GetChild(harfAdet).GetComponent<AudioSource>().clip = harfSesleri[harfAdet];

            yield return new WaitForSeconds(.2f);
            harfAdet++;
        }
  
    }
}
