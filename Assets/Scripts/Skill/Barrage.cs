using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage : Skill

{
    [SerializeField] public static Barrage Instance;

    private void Awake()
    {
        Barrage.Instance = this;
    }



    public override void ActiveSkill()
    {

    }

}
