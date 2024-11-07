using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    //[SerializeField] Color32 hasPackageColor = new Color32(102,97,255,255);
    //[SerializeField] Color32 noPackageColor = new Color32(102, 97, 255, 255);
    [SerializeField] float timeToVanish = 0.2f;
    bool isTaken;

    SpriteRenderer carSpriteRenderer;

    void Start()
    {
        carSpriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("You're hitting something");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && isTaken == false)//khi xe k có hàng đi qua và trigger nhận hàng ==> xe đã có hàng
        {
            Debug.Log("Package captured");
            isTaken = true; //khi đi qua object có tag "Package", xe trigger nhận hàng và điều kiện isTaken đúng
            //spriteRenderer.color = hasPackageColor;
            SpriteRenderer boxSpriteRenderer = collision.GetComponent<SpriteRenderer>(); //lấy màu của package 
            carSpriteRenderer.color = boxSpriteRenderer.color; //gán màu của package cho ô tô
            Destroy(collision.gameObject, timeToVanish);
        }    
        if (collision.tag == "Speed Orb")
        {
            Debug.Log("Car is sped up");
            
            Destroy(collision.gameObject, timeToVanish);
        }
        if (collision.tag == "Customer" && isTaken)
        {
            Debug.Log("Package delivered");
            isTaken = false; //khi đi qua object có tag "Customer" và điều kiện isTaken đúng, xe trigger giao hàng
                             // và điều kiện isTaken sai ==> sẽ không thể giao lại hàng nếu không có hàng trong xe
            
        }
    }
}
