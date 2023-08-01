using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    protected Player player;

    protected virtual void Awake()
    {
        player = GetComponent<Player>();
    }

    public abstract string GetSkillName();

    public abstract KeyCode GetSkillKey();

    public abstract void UseSkill(GameObject target);

    public Player GetPlayer()
    {
        return player;
    }
}
