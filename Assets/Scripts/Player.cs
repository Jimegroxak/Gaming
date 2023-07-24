using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Arena arena;

    private void Update() 
    {
        MoveUnit();
        
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
}
    
