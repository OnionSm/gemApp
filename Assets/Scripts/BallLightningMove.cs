using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLightningMove : MonoBehaviour
{
    private Vector3 start_point;
    private float damage;
    // Start is called before the first frame update

    void Start()
    {
        this.start_point = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(100f*Time.deltaTime*WitchManager.Instance.GetDirect(),0f,0f));
        Despawning();
    }
    private float CalculateDistance()
    {
        float distance = Vector3.Distance(start_point, transform.position);
        return distance;
    }
    private void Despawning()
    {
        if (!CanDespawn())
            return;
        Despawn();
    }
    private bool CanDespawn()
    {
        if(CalculateDistance() >= 300f)
        {
            return true;
        }
        return false;
    }
    private void Despawn()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IDamageable>()?.TakeDamage(125f);
        }
    }
    public void SetDamage(float value)
    {
        this.damage = value;
    }
}
