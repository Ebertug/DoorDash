using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Delivery : MonoBehaviour{
    
    [SerializeField] float destroyDelay=0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,0,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    bool hasPackage = false;
    
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    // Collider
    void OnCollisionEnter2D(Collision2D other){

        Debug.Log("Crash!");
    }

    // Trigger 
    void OnTriggerEnter2D(Collider2D other){

        if (other.tag == "Package" && !hasPackage){
        Debug.Log("Package picked up!");
        hasPackage =true;
        spriteRenderer.color = hasPackageColor;
        Destroy(other.gameObject,destroyDelay);
    }
        else if (other.tag == "Customer"&& hasPackage){
        Debug.Log("Package Delivered!");
        hasPackage = false;
        spriteRenderer.color = noPackageColor;
    }
    
        else if (other.tag == "Package" && hasPackage){
        Debug.Log("You had a package already!");
    }
        else if (other.tag == "Customer"&& !hasPackage){
        Debug.Log("You don't have a package!");
    }
    }
}

//
// SpriteRenderer spriteRenderer;
// 
// void Start() {
//     spriteRenderer = GetComponent<SpriteRenderer>();
// 
// }
// ile spriteRenderer component'ı ile etkileşime girilebiliyor.
// spriteRenderer.color = hasPackageColor;
//