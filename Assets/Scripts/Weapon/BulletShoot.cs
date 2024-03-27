using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    [SerializeField] private float bullet_spped;
    [SerializeField] private float bullet_direction;
    
   

    void Start()
    {
        
    }

    
    void Update()
    {
        this.BulletMove();
    }
    private void BulletMove()
    {
        Vector3 direction = new Vector3(PlayerManager.Instance.player_direction, 0, 0);
        transform.Translate(direction * 50 * Time.deltaTime);
    }
}
