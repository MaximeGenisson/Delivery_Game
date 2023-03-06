using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour

{
    bool gotPack = false;
    [SerializeField] Color32 gotPackColor = new Color32(7, 255, 25, 255);
    [SerializeField] Color32 gotNothingColor = new Color32(238, 10, 33, 255);
    [SerializeField] float destroyTimer = 1.0f;

    SpriteRenderer spriteRenderer;

     private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("bump");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !gotPack){
            Debug.Log("Package picked up");
            gotPack = true;
            spriteRenderer.color = gotPackColor;
            Destroy(other.gameObject, destroyTimer);
        }

        if (other.tag == "Customer" && gotPack){
            Debug.Log("Package delivered");
            gotPack = false;
            spriteRenderer.color = gotNothingColor;
            Destroy(other.gameObject, destroyTimer);
        }
    }
}
