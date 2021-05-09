using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtoControl : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float gravityArtir;
    public GameObject oto;
    private Rigidbody rb;
    public Joystick tus;
    public GameObject direksiyon;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        Move();
        Turn();
        Fall();
    }

    private void Move()
    {
        //Kullanıcının joystickten ileri mi yoksa geri mi gitmek istediğini anlamaka için iki bool türünde değişken oluşturdum.
        bool ileri=false;
        bool geri = false;

        //eğer tus.Vertical yani joystickde ileri ittirilmişse değeri 0'dan büyüktür o halde ileri true olmalı
        if (tus.Vertical > 0)
        {
            ileri = true;
            geri = false;
        }

        //eger jostickde geri gidilmişse geri true olmalı ki aşağıda ona göre işlem yapabilelim
        if (tus.Vertical < 0)
        {
            ileri = false;
            geri = true;
        }

        //eğer yukarıdaki işlemlerin sonucunda ileri true olmuşsa ileri gitmiek istiyordur.
        if (ileri)
        {
            //public değişken olan speed*10 kadar hızlanacak
            rb.AddRelativeForce(new Vector3(Vector3.forward.x,0,Vector3.forward.z) * speed * 10);
        }
        else if (geri)
        {
            //public değişken olan -speed*10 kadar tersi yönde hızlanacak
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z)* -speed * 10);
        }
        //Cismin hız vektörünün güncellenmesi
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity.x = 0;
        rb.velocity = transform.TransformDirection(localVelocity);
    }
    private void Turn()
    {
        //Bu fonksiyon yukarıdaki fonksiyonun Move fonksiyonunun aynısı yanlızca Vertical yerine Horizontal kullanılmıştır.
        bool ileri = false;
        bool geri = false;
        
        if (tus.Horizontal > 0.4 )
        {
            ileri = true;
            geri = false;
        }
        
        if (tus.Horizontal < -0.4)
        {
            ileri = false;
            geri = true;
            
        }
        
        
        if (ileri)
        {
            //Otomuzdaki direksiyonun da dnüş hızında dönmesini sağlar
            direksiyon.transform.Rotate(Vector3.back * turnSpeed);
            rb.AddTorque(Vector3.up * turnSpeed * 10);
        }
        else if (geri)
        {
            //Otomuzdaki direksiyonun da dnüş hızında dönmesini sağlar
            rb.AddTorque(-Vector3.up * turnSpeed * 10);
            direksiyon.transform.Rotate(-Vector3.back * turnSpeed);
        }
    }
    private void Fall()
    {
        //Düşme esnasında düşme ivmesini artırır.
        rb.AddForce(Vector3.down * gravityArtir * 10);
    }
}
