using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image health_bar;
    public Image erase_health_bar;
    private Image mana_bar;
    private Image erase_mana_bar;
    private float lerp_speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LoadComponent()
    {
        this.lerp_speed = 0.05f;
    }
}
