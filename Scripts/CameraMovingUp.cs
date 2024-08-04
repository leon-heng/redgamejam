using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovingUp : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.25f;
    public bool started = false;

    void Update()
    {
        if (started)
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }

    public void Startes()
    {
        started = true;
    }

    public void GameOver()
    {
        started = false;
    }
}
