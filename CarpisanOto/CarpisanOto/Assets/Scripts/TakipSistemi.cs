using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TakipSistemi : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;
    public Transform target6;
    public Transform target7;
    public Transform target8;
    int baslangic;
    int zaman=0;
    Transform[] targets = new Transform[8];
    
    void Start()
    {
       //Başlangıçta tüm duüşman otoları targets adlı değişkenin içine atar.
        targets[0] = target1;
        targets[1] = target2;
        targets[2] = target3;
        targets[3] = target4;
        targets[4] = target5;
        targets[5] = target6;
        targets[6] = target7;
        targets[7] = target8;
        agent = GetComponent<NavMeshAgent>();
        baslangic = 0;
    }

    
    void FixedUpdate()
    {
        //FixedUpdate saniyede 60 kere çağıralcağı için zaman değişkeni saniyede 60 kere artacak.
        //aşağıda baslangic değişkenini 120 yaptım. Yani 2 saniye boyunca herhangi bir oto herhangi bir otoya çarpmaya çalışacak.
        //sonra hedef değiştirecek
        zaman++;
        if (zaman > baslangic)
        {
            //targets içinde rastgele bir elemana erişmek için.
            int rastgele= Random.Range(0, 7);
            
            if (targets[rastgele].transform!=null)
            {
                agent.destination = targets[rastgele].position;
                zaman = 0;
                baslangic = 120;
            }
            //eğer o eleman yoksa yani oto ölmüşse zaman ve başlanbıcı sıfırlar ve tekrar if içine girip yeni bir hedef belirler.
            else
            {
                zaman = 1;
                baslangic = 0;
            }
            
        }
        

       

    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
