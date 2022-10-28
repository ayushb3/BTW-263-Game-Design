using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public float speed  = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 direction = FindObjectOfType<Weapon>().GetDirection();
        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D hitInfo) 
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);

    }
}
