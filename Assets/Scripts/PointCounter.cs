
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class PointCounter  : MonoBehaviour
{
    public GameManager gameManager;

    void Update()
    {
        // GameObject manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        TextMeshProUGUI labelText = GetComponent<TextMeshProUGUI>();
        labelText.text = "Points: " + gameManager.points.ToString();

    }
}