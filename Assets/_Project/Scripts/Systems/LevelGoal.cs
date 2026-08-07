using UnityEngine;
using TMPro;

public class LevelGoal : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            Time.timeScale = 0f;
            winPanel.SetActive(true);
            finalScoreText.text = "Final Score: " + ScoreManager.Instance.GetScore();
        }
    }
}