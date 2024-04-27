using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : Skill
{
    [SerializeField] public static MultiShot Instance;

    private void Awake()
    {
        MultiShot.Instance = this;
    }
    public override void ActiveSkill()
    {

    }

    protected override void LoadComponent()
    {

    }
}
