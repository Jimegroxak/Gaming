using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private TextMeshProUGUI skillKeyTMP;
    [SerializeField] private Button button;

    public void SetBaseSkill(BaseSkill baseSkill)
    {
        textMeshPro.text = baseSkill.GetSkillName();
        string skillKey = baseSkill.GetSkillKey().ToString();
        skillKeyTMP.text = skillKey[skillKey.Length - 1].ToString();
    }
}

