using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    [SerializeField] bool somethingLater;
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] SoundEffectPlayer soundPlayer;
    public int point = 0;

    void Start()
    {
        UpdatePointText();
    }

    public void AddPoints()
    {
        point += 10;
        soundPlayer.GainPoint();
        UpdatePointText();
    }

    private void UpdatePointText()
    {
        pointText.text = point.ToString();
    }
}
