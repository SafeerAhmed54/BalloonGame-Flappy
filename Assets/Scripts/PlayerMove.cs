using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using DG.Tweening.Core.Easing;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float boundX = 4.5f;
    [SerializeField] private int score;
    [SerializeField] private AudioManager audioManager;

    public bool gameOver = false;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    [SerializeField] private string highScoreKey = "HighScore";
    [SerializeField] private List<AudioClip> clip;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        audioManager = FindAnyObjectByType<AudioManager>();   
        highscoreText.text = "HighScore : " + PlayerPrefs.GetInt(highScoreKey).ToString();
    }

    private void Update()
    {
        SpaceJump();
        BoundaryCheck();
    }

    void SpaceJump()
    {
        if (Input.GetKey(KeyCode.Space)) 
        { 
            playerRb.AddForce(Vector3.up, ForceMode.Impulse);
            audioManager.PlayAudioClip(clip[0]);
        }
    }

    void BoundaryCheck()
    {
        if (transform.position.y >= boundX ||  transform.position.y <= -boundX)
        {
            gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            gameOver = true;
            audioManager.PlayAudioClip(clip[1]);
        }
        else if (other.CompareTag("Points"))
        {
            score++;
            scoreText.text = "Points : " + score.ToString();
            
            if (PlayerPrefs.GetInt(highScoreKey) <= score)
            {
                PlayerPrefs.SetInt(highScoreKey, score);
                PlayerPrefs.Save();
                highscoreText.text = "HighScore : " + PlayerPrefs.GetInt(highScoreKey).ToString(); 
            }

            Debug.Log("Point is " + score);
        }
    }
}
