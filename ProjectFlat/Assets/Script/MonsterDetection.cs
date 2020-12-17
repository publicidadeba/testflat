using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     
  void OnTriggerStay2D(Collider2D collision)
 {

   if (collision.gameObject.CompareTag("destroy"))
   {
     
    Application.LoadLevel(0);
     
   }

 }
}
