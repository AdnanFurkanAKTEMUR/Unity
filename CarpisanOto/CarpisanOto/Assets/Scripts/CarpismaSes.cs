using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpismaSes : MonoBehaviour
{
    public AudioSource ses;
    void Start()
    {
        //Başlangıçta ses nesnesini alır
        ses = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //dusmanOto tag ismine sahip bir nesneye çarptığı an çarpma sesi çalar.
        if (collision.gameObject.tag == "dusmanOto")
        {
            ses.Play();
            //print("Düşmana çarptım");
        }
    }
}
