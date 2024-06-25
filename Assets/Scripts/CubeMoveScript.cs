using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeMoveScript : MonoBehaviour
{
    [SerializeField] public float speed = 5f;  // Default speed, can be adjusted in the Inspector
    [SerializeField] private Rigidbody cubeRb;
    [SerializeField] private Animator cubeAni;
    [SerializeField] private GameObject cubeObj;
    //[SerializeField] private Animation cubeAni;
    [SerializeField] private PlayerMove player;

    // Start is called before the first frame update
    void Start()
    {
        cubeRb = GetComponent<Rigidbody>();
        cubeAni = GetComponent<Animator>();
        player = FindAnyObjectByType<PlayerMove>();
        cubeObj = transform.GetChild(0).gameObject;

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
            Vector3 posEnd1 = new Vector3(0,100,0);
            Vector3 posEnd2 = new Vector3(0, -100, 0);
            transform.DOLocalMove(posEnd1, 30, false);
            cubeObj.transform.DOLocalMove(posEnd2, 30, false);
            //cubeAni.Play("BlockOut");
        }
    }
}
