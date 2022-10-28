using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletVelocity  = 20f;
    public static Vector2 direction;


    // Update is called once per frame
    void Update()
    {

        // Vector3 mousePosition = Input.mousePosition;

        // Vector3 aimDirection = (mousePosition - transform.position).normalized;
        // float angle  = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        // aimTransform.eulerAngles = new Vector3(0, 0,)
        // if(Input.GetMouseButtonDown(0)) 
        // {
        //     Shoot();
        // }
        if (Input.GetMouseButtonDown(0))
        {  
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();
            // Creates the bullet locally
            Instantiate(bulletPrefab,firePoint.position + (Vector3)(direction * 0.5f), Quaternion.identity);

            
         
        
        }
    }
    public Vector2 GetDirection() {
        return direction;
    }

    void Shoot() {

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
