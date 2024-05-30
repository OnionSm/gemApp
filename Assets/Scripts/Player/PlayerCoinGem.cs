using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCoinGem : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.SetCoinText();
        this.SetGemText();
    }
    public void SetCoinText()
    {
        if(PlayerUIManager.Instance.coin_text != null)
            PlayerUIManager.Instance.coin_text.text = $"{Math.Round(PlayerManager.Instance.coin)}";
    }
    public void SetGemText() 
    {
        if(PlayerUIManager.Instance.gem_text != null)
            PlayerUIManager.Instance.gem_text.text = $"{Math.Round(PlayerManager.Instance.gem)}";
    }
}
