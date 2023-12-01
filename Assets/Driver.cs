using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Driver : MonoBehaviour{
    [SerializeField] float steerSpeed =300;
    [SerializeField] float moveSpeed = 15;
    [SerializeField] float slowSpeed = 5;
    [SerializeField] float boostSpeed = 30;
        
    void Update(){
  
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "SpeedBoost"){
        Debug.Log("You got speed boost!");
        moveSpeed = boostSpeed;
        }
    }

 
}

// 
// Serialize Field] ile kod içerisinde verilen değerleri unity içerisinde değiştirilebiliyor.
// Input.GetAxis("Vertical/Horizontal") ile "WASD" entegrasyonu yapılıyor.
// OnCollisionEnter2D ve OnTriggerEnter2D ile collisionlar temas edince eylem gerçekştirilebiliyor.
// Time.deltaTime ile pixel değişimleri sabitleniyor.
//