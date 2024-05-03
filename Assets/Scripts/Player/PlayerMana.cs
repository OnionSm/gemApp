using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] private Image mana_fill;

    private void Awake()
    {
        this.mana_fill = GetComponent<Image>();
    }
    public void Update()
    {
        mana_fill.fillAmount = (PlayerManager.Instance.current_mana / PlayerManager.Instance.max_mana);
        if (PlayerManager.Instance.current_mana > PlayerManager.Instance.max_mana)
        {
            PlayerManager.Instance.current_mana = PlayerManager.Instance.max_mana;
        }
    }
    public void GainMana()
    {
        PlayerManager.Instance.current_mana += 5f;

    }
    public void DecreaseMana()
    {
        PlayerManager.Instance.current_mana -= 10f;

    }
}
