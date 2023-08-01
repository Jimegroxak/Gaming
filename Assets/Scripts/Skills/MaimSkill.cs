using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaimSkill : BaseSkill
{
    private string skillName = "Maim";
    private KeyCode skillKey = KeyCode.Alpha2;
    private int skillDamage = 150;
    private int comboSkillDamage = 300;

    override public void UseSkill(GameObject target)
    {
        Enemy enemy = target.GetComponent<Enemy>();
        Debug.Log(skillName);

        if (PlayerSkillSystem.Instance.GetLastSkillUsed() is HeavySwingSkill)
        {
            enemy.SetHealth(comboSkillDamage);
            Debug.Log(comboSkillDamage);
        }

        else
        {
            enemy.SetHealth(skillDamage);
            Debug.Log(skillDamage);
        }
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
