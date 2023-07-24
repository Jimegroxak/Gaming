using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    [SerializeField] private Arena arena;

    private float radius;
    private Vector3 center;

    private void Start() 
    {
        radius = arena.transform.localScale.x / 2;  
        center = arena.transform.localPosition;  
    }

    public float GetRadius()
    {
        return radius;
    }

    public Vector3 GetCenter()
    {
        return center;
    }
}
