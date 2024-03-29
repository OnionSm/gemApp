using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    [SerializeField] private float bullet_speed;
    [SerializeField] private float bullet_direction;

    private void Awake()
    {
        //this.bullet_direction = PlayerManager.Instance.player_direction;
    }

    void Start()
    {
        this.bullet_direction = PlayerManager.Instance.player_direction;
    }

    
    void Update()
    {
        this.BulletMove();
    }
    private void BulletMove()
    {
        Vector3 direction = new Vector3(bullet_direction, 0, 0);
        transform.Translate(direction * 50 * Time.deltaTime);
    }
}
