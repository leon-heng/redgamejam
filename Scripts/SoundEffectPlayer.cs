using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource src;

    [SerializeField] private AudioClip gainPointSFX;
    [SerializeField] private AudioClip gotStunSFX;


    [SerializeField] private AudioClip obstascleBreakSFX;
    [SerializeField] private AudioClip stuckwallSFX;
    [SerializeField] private AudioClip getPointSFX;

    [SerializeField] private AudioSource srcStun;
    [SerializeField] private AudioSource srcStuck;
    [SerializeField] private AudioSource srcObstascleBreak;
    [SerializeField] private AudioSource srcGainPoint;

    public void GainPoint()
    {
        srcGainPoint.Play();
    }

    public void PlayDizzy()
    {
        srcStun.Play();
    }

    public void StopDizzy()
    {
        srcStun.Stop();
    }

    public void PlayObstascleBreak()
    {
        srcObstascleBreak.Play();
    }

    public void PlayStuck()
    {
        srcStuck.Play();
    }
}
