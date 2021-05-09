using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menupanel;
    public Camera kameraDis;
    public Camera kameraIc;
    bool kamera = false;
    
    //Ekranda bulunan P nesnesine basıldığında menupanel'i açar ve oyunun durdurur.
    public void menuAc()
    {
        menupanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
    //menude oyuna devam et seçeneğine tıklandığında menüyü kapatır ve zamanı normal akışına döndürür
    public void oyunaDevamEt()
    {
        menupanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    //Oyundan çıkış yapar
    public void anaMenuye()
    {
        Application.Quit();
    }

    //fps ile dışardan bakma arasında gidip gelir. Ekranda ki fps nesnesinden değişir
    public void KameraDegis()
    {
        if (kamera)
        {
            kameraIc.enabled = false;
            kameraDis.enabled = true;

            kamera = !kamera;
        }
        else
        {
            kameraIc.enabled = true;
            kameraDis.enabled = false;
            
            kamera = !kamera;
        }
    }
    //Yeni Oyun başlatır ancak doğru çalışmadığı için yorum satırına aldım.
    public void YeniOyun()
    {
        
        //SceneManager.LoadScene(0);
    }
}
