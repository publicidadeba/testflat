using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyclone : MonoBehaviour
{
 
     void OnTriggerStay2D(Collider2D collision)
 {

   if (collision.gameObject.CompareTag("player"))
   {
     
     Destroy(gameObject);
     
   }

      if (collision.gameObject.CompareTag("destroy"))
   {
     Application.LoadLevel(0);
     
     
   }

 }


}
