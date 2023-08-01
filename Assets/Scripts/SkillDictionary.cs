using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDictionary : MonoBehaviour
{
    private Dictionary<KeyCode, BaseSkill> skillDictionary;

    private BaseSkill heavySwing, maim;

    private void Awake() 
    {
        skillDictionary = new Dictionary<KeyCode, BaseSkill>();

        heavySwing = gameObject.AddComponent<HeavySwingSkill>();
        maim = gameObject.AddComponent<MaimSkill>();
        
        skillDictionary[heavySwing.GetSkillKey()] = heavySwing; 
        skillDictionary[maim.GetSkillKey()] = maim; 
    }

    private void Start() 
    {
        
    }

    public Dictionary<KeyCode, BaseSkill> GetDictionary()
    {
        return skillDictionary;
    }
}
