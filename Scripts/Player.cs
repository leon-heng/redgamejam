using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PointSystem PointSystem;
    [SerializeField] private Animator animator;
    [SerializeField] public bool isStun = false;
    [SerializeField] private float stunRecovery =1.3f;
    [SerializeField] private SoundEffectPlayer SoundPlayer;
    [SerializeField] bool started = false;

    [SerializeField] GrapplingHook GH;
    [SerializeField] CameraMovingUp Camera;
    [SerializeField] GameObject gameoverPanel;

    private float stunTimer;

    void Update()
    {
        if (!started)
        {
            return;
        }

        if (isStun)
        {
            stunTimer += Time.deltaTime;
            if(stunTimer >= stunRecovery)
            {
                isStun = false;
                animator.SetBool("isStun", false);
                SoundPlayer.StopDizzy();
                stunTimer = 0;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!started)
        {
            return;
        }

        if (other.CompareTag("Finish"))
        {
            started = false;
            transform.GetComponent<Rigidbody2D>().simulated = false;
            GH.GameOver();
            Camera.GameOver();
            gameoverPanel.SetActive(true);
        }
        else if (other.CompareTag("Obstacle"))
        {
            isStun = true;
            animator.SetBool("isStun", true);
            SoundPlayer.PlayObstascleBreak();
            SoundPlayer.PlayDizzy();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Coin"))
        {
            PointSystem.AddPoints();
            Destroy(other.gameObject);
        }
    }
    public void Started()
    {
        started = true;
    }
}
