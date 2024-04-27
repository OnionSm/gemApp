using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HailOfArrows : Skill
{
    [SerializeField] public static HailOfArrows Instance;

    private void Awake()
    {
        HailOfArrows.Instance = this;
    }


    public override void ActiveSkill()
    {

    }
    
    protected override void LoadComponent()
    {

    }
}
