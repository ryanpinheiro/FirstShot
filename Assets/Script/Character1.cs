using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1 : MonoBehaviour
{ 
    public float speed;
    public float jumbforce;
    private Animator anin;
    SpriteRenderer  _SpriteRedere;

    private Rigidbody2D rig;

    public bool Isjump;
    public bool doublejump;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anin = GetComponent<Animator>();
        _SpriteRedere = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Jump();
    }

     void move(){

    Vector3 move = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
    transform.position += move * Time.deltaTime * speed;

    if (Input.GetAxis("Horizontal") > 0f){ 

        anin.SetBool("dele", false);
        _SpriteRedere.flipX = false;
        
    }
    if (Input.GetAxis("Horizontal") < 0f){
               
               anin.SetBool("dele",false);
               _SpriteRedere.flipX = true;
    }
    if (Input.GetAxis("Horizontal") == 0f){
               
               anin.SetBool("dele",true); 
    }
     }
        

     void Jump(){

           if(Input.GetButtonDown("Jump")){

               if(!Isjump){


               rig.AddForce(new Vector2(0f,jumbforce), ForceMode2D.Impulse);
               doublejump = true;

               
               }else{
                   if(doublejump){

                       rig.AddForce(new Vector2(0f,jumbforce), ForceMode2D.Impulse);
                       doublejump = false;
                   }

               }
               

           }
         }


         void OnCollisionEnter2D(Collision2D other)
         {
             if(other.gameObject.layer == 3){

                 Isjump = false;


             }
         }

        
         void OnCollisionExit2D(Collision2D other)
         {
             if(other.gameObject.layer == 3){

                 Isjump = true;
                 
             }

         }

         

     }
     

