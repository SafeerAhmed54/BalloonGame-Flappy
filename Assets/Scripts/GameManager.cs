using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerMove player; // Reference to the player script
    public GameObject panel; // Game over panel
    public TextMeshProUGUI scoreText; // UI element to display the score
    public GameObject Button;
    public bool playGame = false;
    public bool fadeOut;
    public bool snapping;
    public float duration;
    public float strength;
    public int vibrato;
    public float randomness;

    void Start()
    {
        // Ensure player reference is set
        if (player == null)
        {
            player = FindObjectOfType<PlayerMove>();
        }

        // Hide the game over panel at the start
        panel.SetActive(false);
    }

    void Update()
    {
        if (player != null && player.gameOver)
        {
            panel.SetActive(true);
            scoreText.text = "Points: " + player.scoreText.text;
        }
        if (player == null)
        {
            player = FindObjectOfType<PlayerMove>();
        }
        ShakeAnimation();
    }
    public void PlayGame()
    {
        playGame = true;
    }
    public void Restart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShakeAnimation()
    {
        Button.transform.DOShakePosition(duration, strength, vibrato, randomness,snapping ,fadeOut, ShakeRandomnessMode.Harmonic);
    }
}
