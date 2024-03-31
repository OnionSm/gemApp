using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpart : MonoBehaviour
{
    [SerializeField] private DamageSender damage_sender;
    private void Awake()
    {
        this.damage_sender = GetComponent<DamageSender>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OK");
        this.damage_sender.Send(other.transform);
    }

}
        