using UnityEngine;
using UnityEngine.UI;
using TMPro; // Include the namespace for TextMeshPro

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText; // TextMeshProUGUI component reference
    public Joueur joueur; // Reference to the Joueur script

    void Start()
    {
        // Find the TextMeshProUGUI component in children
        scoreText = GetComponentInChildren<TextMeshProUGUI>();

        // Check if scoreText is found
        if (scoreText == null)
        {
            Debug.LogError("TextMeshProUGUI component not found in children!");
        }
        else
        {
            // Update the initial score text
            UpdateScoreText(joueur.score,joueur.scoremultiplier);
        }
    }

    void Update()
    {
        // Access the score variable from the Joueur script
        int score = joueur.score;
        int scoremultiplier = joueur.scoremultiplier;

        // Update the score text
        UpdateScoreText(score, scoremultiplier);
    }

    void UpdateScoreText(int score, int scoremultiplier)
    {
        // Update the text component with the new score value
        scoreText.text = "Score: " + score.ToString() + " Multiplier: " + scoremultiplier.ToString();
    }
}