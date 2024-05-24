using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lv_text;
    [SerializeField] private Image exp_fill;
    [SerializeField] private float lerp_speed;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateExpBar();
    }
    private void UpdateExpBar()
    {
        float fill = PlayerManager.Instance.CurrentExp / PlayerManager.Instance.ExpMax;
        exp_fill.fillAmount = Mathf.MoveTowards(exp_fill.fillAmount, fill, lerp_speed * Time.deltaTime);
    }
    public void LoadComponent()
    {
        this.lerp_speed = 0.8f;
    }
    public void AddExp(float value)
    {
        PlayerManager.Instance.AddExp(value);
    }
    public void SetTextLevel(float value)
    {
        this.lv_text.text = value.ToString();
    }
}
