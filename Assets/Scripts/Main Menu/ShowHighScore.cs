using UnityEngine;
using TMPro;

public class ShowHighScore : MonoBehaviour
{
    private TextMeshProUGUI highScore;
    private float screenWidth, screenHeight;

    void Start()
    {
        highScore = GetComponent<TextMeshProUGUI>();
        highScore.text = "High Score: " + PlayerPrefs.GetInt("highscore");
    }
}
