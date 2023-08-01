using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavySwingSkill : BaseSkill
{
    protected const float BASE_GCD = 2.5f;
    private float currentGCD;

    private string skillName = "Heavy Swing";
    private KeyCode skillKey = KeyCode.Alpha1;
    private int skillDamage = 200;

    override public void UseSkill(GameObject target)
    {
        Enemy enemy = target.GetComponent<Enemy>();
        Debug.Log(skillName);
        enemy.SetHealth(skillDamage);
    }

    override public string GetSkillName()
    {
        return skillName;
    }

    override public KeyCode GetSkillKey()
    {
        return skillKey;
    }

}
