using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class HarfiKesfetManager : MonoBehaviour
{
    [SerializeField]
    List<Sprite> dairelerImages;

    int daireAdet;

    bool basilsinmi;

    GameObject resimlerHolder;
    void Start()
    {
        resimlerHolder = GameObject.Find("resimlerHolder");
        TumDaireleriPasifKapat();
    }

    void TumDaireleriPasifKapat()
    {
        dairelerImages = dairelerImages.OrderBy(i => Random.value).ToList();
        for (int i = 0; i < this.transform.GetChild(0).childCount; i++)
        {
            this.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
            if (i % 2 == 0)
            {
                this.transform.GetChild(0).GetChild(i).transform.GetComponent<Image>().sprite = dairelerImages[0];
            }
            else
            {
                this.transform.GetChild(0).GetChild(i).transform.GetComponent<Image>().sprite = dairelerImages[i];
            }

        }

    }
    public void TumDaireleriAc()
    {
        daireAdet = 0;
        StartCoroutine(DaireleriAcRoutine());
    }
    IEnumerator DaireleriAcRoutine()
    {
        while (daireAdet < this.transform.GetChild(0).childCount)
        {
            this.transform.GetChild(0).GetChild(daireAdet).gameObject.SetActive(true);
            daireAdet++;
            yield return new WaitForSeconds(0.08f);
        }
        yield return new WaitForSeconds(0.5f);
        while (daireAdet > 1)
        {
            this.transform.GetChild(0).GetChild(daireAdet - 1).gameObject.SetActive(false);
            daireAdet--;
        }
        basilsinmi = true;
    }


    private void Update()
    {
        UzerindenGec();
    }

    void UzerindenGec()
    {
        if (daireAdet < this.transform.GetChild(0).childCount)
        {
            float uzaklik = Vector3.Distance(Input.mousePosition, this.transform.GetChild(0).GetChild(daireAdet).transform.position);
            if (uzaklik < 45)
            {
                this.transform.GetChild(0).GetChild(daireAdet).gameObject.SetActive(true);
                this.transform.GetChild(0).GetChild(daireAdet).GetChild(0).gameObject.SetActive(true);

                if (uzaklik < 45)
                {
                    this.transform.GetChild(0).GetChild(daireAdet).gameObject.SetActive(true);
                    this.transform.GetChild(0).GetChild(daireAdet).GetChild(0).gameObject.SetActive(true);
                    if (this.transform.GetChild(0).GetChild(daireAdet - 1).GetChild(0) != null)
                    {
                        this.transform.GetChild(0).GetChild(daireAdet - 1).GetChild(0).gameObject.SetActive(false);
                    }
                    daireAdet++;
                }

            }
            if (daireAdet == this.transform.GetChild(0).childCount)
            {
                basilsinmi = false;
                Invoke("EkranGeriGetir", 2f);
            }
        }
    } 

    void EkranGeriGetir()
    {
        this.transform.gameObject.SetActive(false);
        resimlerHolder.gameObject.SetActive(true);
    }
}

