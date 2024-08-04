using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] TextMeshProUGUI heightText;
    [SerializeField] PointSystem PointSystem;
    [SerializeField] TextMeshProUGUI pointText;

    void Start()
    {
        pointText.text = "Score : " + PointSystem.point.ToString();

        float height = camera.position.y * 3f;
        int roundedHeight = Mathf.RoundToInt(height);
        heightText.text = "Reached : " + roundedHeight + "m";
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
