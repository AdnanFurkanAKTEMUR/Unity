using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtoOlme : MonoBehaviour
{

    public GameObject fail;
    public GameObject win;
    public Transform OlenOto;
    private int olenSayisi = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
        //Oyuncu dışındaki herkes yok olduğunda win panelini çalıştırır ve oyunu dondurur.
        if (olenSayisi > 4)
        {
            win.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Trigger'a giren nesneyi alır.
        OlenOto = other.transform;
        //Eğer nesnenin tagi Player ise oyuncu ölmüştür. Fail panelini açar, oyunu dondurur ve oyuncuyu yok eder.
        if (OlenOto.tag == "Player")
        {
            fail.SetActive(true);
            Time.timeScale = 0.0f;
            Destroy(other.gameObject);
        }
        //eğer ölen player değilse olenSayisi değişkenini artırır ve Trigger'a giren nesneyi yok eder.
        else
        {
            olenSayisi++;
            Destroy(other.gameObject);
        }
    }
}
