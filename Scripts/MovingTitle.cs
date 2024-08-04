using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTitle : MonoBehaviour
{
    public float minY = -50f;  
    public float maxY = 50f;   
    public float moveSpeed = 1f;  

    private float targetY;  
    private float startY;  

    void Start()
    {
        startY = transform.position.y;  
        SetRandomTargetY(); 
    }

    void Update()
    {
        float newY = Mathf.MoveTowards(transform.position.y, targetY, moveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        if (Mathf.Abs(newY - targetY) < 0.1f)
        {
            SetRandomTargetY();
        }
    }

    private void SetRandomTargetY()
    {
        targetY = Random.Range(startY + minY, startY + maxY);
    }
}
