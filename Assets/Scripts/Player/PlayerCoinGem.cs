using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCoinGem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coin_text;
    [SerializeField] private TextMeshProUGUI gem_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.SetCoinText();
        this.SetGemText();
    }
    public void SetCoinText()
    {
        coin_text.text = $"{Math.Round(PlayerManager.Instance.coin)}";
    }
    public void SetGemText() 
    {
        gem_text.text = $"{Math.Round(PlayerManager.Instance.gem)}";
    }
}
