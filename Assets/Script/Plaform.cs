using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaform : MonoBehaviour
{
    

   private PlatformEffector2D effector;
   public float waitime;
   


    void Start()
    {
      effector = GetComponent<PlatformEffector2D>();  
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.DownArrow)){
              
              waitime = 0.2f;

        }

        if(Input.GetKey(KeyCode.DownArrow)){
            if(waitime <= 0){
                effector.rotationalOffset = 0f;
                waitime = 0.2f;
            }else{
                waitime -= Time.deltaTime;
            }
        }

        if(Input.GetKey(KeyCode.Space)){
            effector.rotationalOffset = 180f;
        }
    }

    
}
