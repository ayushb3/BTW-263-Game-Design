using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public PhysicsMaterial2D Ice_Friction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   /// <summary>
   /// Sent when another object enters a trigger collider attached to this
   /// object (2D physics only).
   /// </summary>
   /// <param name="other">The other Collider2D involved in this collision.</param>
   private void OnTriggerEnter2D(Collider2D other)
   {
       Bullet bullet =  other.GetComponent<Bullet>();

       if(bullet != null) {
        print("COLLIDED WITH BULLET");
        GetComponent<SpriteRenderer>().color = Color.blue;
        GetComponent<Collider2D>().sharedMaterial = Ice_Friction;
       }
    }
}
