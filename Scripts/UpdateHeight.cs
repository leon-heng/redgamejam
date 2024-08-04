using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UpdateHeight : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] TextMeshProUGUI heightText;

    void Update()
    {
        float height = camera.position.y * 3f;
        int roundedHeight = Mathf.RoundToInt(height);
        heightText.text = roundedHeight + "m";
    }
}
