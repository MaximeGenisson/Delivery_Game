using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moovin : MonoBehaviour
{

    [SerializeField] float turnSpeed = 250f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    // Start is called before the first frame update
    void Start()
{
        
    }

    // Update is called once per frame
    void Update()
    {
     float turnQuantity = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
     float moveQuantity = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
     transform.Translate(0,moveQuantity,0);
     transform.Rotate(0,0,-turnQuantity);   

     
    }

    private void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other){
       if (other.tag == "Boost"){
        moveSpeed = boostSpeed;
        }
    }
}
