using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillSystem : MonoBehaviour
{
    public static PlayerSkillSystem Instance {get; private set;}

    [SerializeField] private Player player;

    private Dictionary<KeyCode, BaseSkill> skillDictionary;
    private const float BASE_GCD = 2.5f;
    private float gcd;
    private bool isBusy;

    //Used for combo actions
    private BaseSkill lastSkillUsed;

    private void Awake() 
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one Player Skill System! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }

        Instance = this;    
    }

    private void Start() 
    {
        skillDictionary = GetComponent<SkillDictionary>().GetDictionary();        
    }

    private void Update() 
    {
        UpdateTimer();

        HandleCurrentAction();
    }

    private void UpdateTimer()
    {
        if (isBusy)
        {
            gcd -= Time.deltaTime;
        }

        if (gcd <= 0)
        {
            gcd = BASE_GCD;
            isBusy = false;
        }
    }

    private void HandleCurrentAction()
    {
        foreach (var key in skillDictionary.Keys)
        {
            if (Input.GetKeyDown(key))
            {
                if (!isBusy)
                {
                    skillDictionary[key].UseSkill(player.GetTarget());
                    lastSkillUsed = skillDictionary[key];
                    isBusy = true;
                }

                else
                {
                    Debug.Log("Not ready yet");
                }
            }
        }
    }

    public BaseSkill GetLastSkillUsed()
    {
        return lastSkillUsed;
    }
}
