using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealWaveController : MonoBehaviour
{

    private float count_time_despawn;
    private float skill_time;
    // Start is called before the first frame update
    void Start()
    {
        LoadComponent();
    }

    // Update is called once per frame
    void Update()
    {
        MinusTime();
        Despawning();
    }
    private void LoadComponent()
    {
        this.skill_time = 0.5f;
        this.count_time_despawn = skill_time;
    }
    private void MinusTime()
    {
       this.count_time_despawn -= Time.deltaTime;
    }
    private void Despawning()
    {
        if (!CanDespawn())
            return;
        Despawn();
    }
    private bool CanDespawn()
    {
        if (count_time_despawn<=0)
        {
            return true;
        }
        return false;
    }
    private void Despawn()
    {
        Destroy(gameObject);
    }
}
