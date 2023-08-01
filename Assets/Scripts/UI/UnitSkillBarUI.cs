using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSkillBarUI : MonoBehaviour
{
    [SerializeField] private Transform skillButtonPrefab;
    [SerializeField] private Transform skillButtonContainerTransform;

    private void Start() 
    {
        CreateSkillIcons();    
    }

    private void CreateSkillIcons()
    {
        Dictionary<KeyCode, BaseSkill> skills = PlayerSkillSystem.Instance.GetComponent<SkillDictionary>().GetDictionary();

        foreach (BaseSkill s in skills.Values)
        {
            Transform skillButtonTransform = Instantiate(skillButtonPrefab, skillButtonContainerTransform);
            SkillButtonUI skillButtonUI = skillButtonTransform.GetComponent<SkillButtonUI>();
            skillButtonUI.SetBaseSkill(s);
        }
    }
}
