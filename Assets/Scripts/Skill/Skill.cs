using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : OnionBehaviour
{
    [SerializeField] public static Skill Instance;

    private void Awake()
    {
        Skill.Instance = this;
    }

}
