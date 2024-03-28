using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpart : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Debug.Log("Player collided with an Enemy!");
            collision.gameObject.SetActive(false);
        }
    }
}
