using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private Barrage barrage;
    [SerializeField] private BaseShot baseshot;
    [SerializeField] private HailOfArrows hailOfArrows;
    [SerializeField] private MultiShot multiShot;
    private void Awake()
    {
        barrage = GetComponentInChildren<Barrage>();  
        baseshot = GetComponentInChildren<BaseShot>();
        hailOfArrows = GetComponentInChildren<HailOfArrows>();
        multiShot = GetComponentInChildren<MultiShot>();
    }

    public void GetSKill(string skill_name)
    {
        if(skill_name == "BaseShot" && baseshot != null)
        {
            baseshot.ActiveSkill();
        }
        if (skill_name == "Barrage" && barrage != null)
        {
            barrage.ActiveSkill();
        }
        if (skill_name == "HailOfArrows" && hailOfArrows != null)
        {
            hailOfArrows.ActiveSkill();
        }
        if (skill_name == "MultiShot" && multiShot != null)
        {
            multiShot.ActiveSkill();
        }

    }
}
