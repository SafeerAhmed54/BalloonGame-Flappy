using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveScript : MonoBehaviour
{
    public float speed = 5f;  // Default speed, can be adjusted in the Inspector
    private Rigidbody cubeRb;
    private Animator cubeAni;
    //[SerializeField] private Animation cubeAni;
    [SerializeField] private PlayerMove player;

    // Start is called before the first frame update
    void Start()
    {
        cubeRb = GetComponent<Rigidbody>();
        cubeAni = GetComponent<Animator>();
        player = FindAnyObjectByType<PlayerMove>();

    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        Move();
        BoundaryCheck();
        GameOverCheck();
    }

    void Move()
    {
        // Set the velocity to a constant speed to the left
        cubeRb.velocity = Vector3.left * speed;
    }
    void BoundaryCheck()
    {
        if (transform.position.x <= -12)
        {
            Destroy(gameObject);
        }
    }

    void GameOverCheck()
    {
        if(player.gameOver == true)
        {
            /*Transform startPosChild = gameObject.GetComponentInChildren<Transform>();
            Transform startPos = gameObject.GetComponent<Transform>();*/
            cubeAni.Play("BlockOut");
        }
    }
}
