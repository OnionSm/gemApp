using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour

{
    [SerializeField] public static SkillManager Instance;
    [SerializeField] 
    private void Awake()
    {
        SkillManager.Instance = this;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void GetSKill(string skill_name)
    {
        if(skill_name == "BaseShot")
        {
            BaseShot.Instance.ActiveSkill();
        }
        if (skill_name == "Barrage")
        {
            Barrage.Instance.ActiveSkill();
        }
        if (skill_name == "HailOfArrows")
        {
            HailOfArrows.Instance.ActiveSkill();
        }
        if (skill_name == "MultiShot")
        {
            MultiShot.Instance.ActiveSkill();
        }

    }
}
