using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyclone : MonoBehaviour
{

  void Start(){
    Debug.Log("Script working");
  }
 
     void OnTriggerStay2D(Collider2D collision)
 {

   if (collision.gameObject.CompareTag("killer"))
   {
     
     Debug.Log("Trigger Working");
     Destroy(gameObject);
     
   }

 }


}
