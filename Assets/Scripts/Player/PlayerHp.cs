using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] private Image hp_fill;

    private void Awake()
    {
        this.hp_fill = GetComponent<Image>();
    }
    public void Update()
    {
        hp_fill.fillAmount = (PlayerManager.Instance.current_hp / PlayerManager.Instance.max_hp);
        if (PlayerManager.Instance.current_hp > PlayerManager.Instance.max_hp)
        {
            PlayerManager.Instance.current_hp = PlayerManager.Instance.max_hp;
        }
    }
    public void GainHP()
    {
        PlayerManager.Instance.current_hp += 50f;
      
    }
    public void DecreaseHP()
    {
        PlayerManager.Instance.current_hp -= 50f;
        
    }
}
