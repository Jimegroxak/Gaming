using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Arena arena;

    private AttackAction attackAction;

    //Skills
    private HeavySwingSkill heavySwing;

    //Attack variables
    private bool ableToAttack = false;
    private GameObject target = null;

    private void Awake() 
    {
        attackAction = GetComponent<AttackAction>();
        heavySwing = GetComponent<HeavySwingSkill>();
    }

    private void Start() 
    {
        
    }

    private void Update() 
    {
        MoveUnit(); 

        if (ableToAttack)
        {
            attackAction.Attack(target);
        }
    }

    private void MoveUnit()
    {
        float xMoveAmount = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float yMoveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        //Verify that unit has not left the circle
        
        float radius = arena.GetRadius();
        Vector3 center = arena.GetCenter();
        float distanceFromCenter = Mathf.Sqrt(
            Mathf.Pow((transform.position.x + xMoveAmount - center.x), 2) +
            Mathf.Pow((transform.position.y + yMoveAmount - center.y), 2));

        //Check if distance is greater than radius
        if (distanceFromCenter <= radius)
        {
            transform.Translate(xMoveAmount, yMoveAmount, 0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            ableToAttack = true;
            target = collider.gameObject;
            attackAction.ResetAttackTimer();   
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            ableToAttack = false; 
            target = null;
        }   
    }

    public GameObject GetTarget()
    {
        return target;
    }

    public AttackAction GetAttackAction()
    {
        return attackAction;
    }

    public HeavySwingSkill GetHeavySwingSkill()
    {
        return heavySwing;
    }
}
    
