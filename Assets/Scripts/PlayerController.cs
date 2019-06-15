using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Side
    {
        Left,
        Center,
        Right
    };

    public Side currentSide = Side.Center;
    public float speed;
    public Rigidbody playerRigidbody;
    public Animator playerAnimator;
    public GameObject magnetCollider;
    public float distanceSideX;
    public bool powerUpMultiplier;
    public bool powerUpInvincible;
    public bool powerUpMagnet;

    [HideInInspector]
    public int pagesNumber;

    private static PlayerController m_instance;
    private GameController m_controller;
    private bool m_jumping;
    private bool m_sliding;
    private bool m_gameOver;

    private void Awake()
    {
        if (!m_instance)
        {
            m_instance = this;
        }
    }

    public static PlayerController GetInstance()
    {
        return m_instance;
    }

    private void Start()
    {
        m_controller = GameController.GetInstance();
    }

    private void Update()
    {
        CheckMovement();
        CheckInput();
        ActualizeUIInformation();
    }

    public IEnumerator JumpCoroutine()
    {
        m_jumping = true;
        m_sliding = true;
        //JumpAnimationTime
        yield return new WaitForSeconds(0.7f);
        m_jumping = false;
        m_sliding = false;
        playerAnimator.SetBool("jump", false);
    }

    private IEnumerator SlideCoroutine()
    {
        m_sliding = true;
        m_jumping = true;
        //SlideAnimationTime
        yield return new WaitForSeconds(1.08f);
        m_sliding = false;
        m_jumping = false;
        playerAnimator.SetBool("slide", false);
    }

    private void CheckMovement()
    {
        if (!m_gameOver)
        {
            speed += 0.001f;
            playerRigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !m_jumping)
        {
            playerAnimator.SetBool("jump", true);
            playerAnimator.Play("Jump");
            StartCoroutine(JumpCoroutine());
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !m_sliding)
        {
            playerAnimator.SetBool("slide", true);
            playerAnimator.Play("Slide");
            StartCoroutine(SlideCoroutine());
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (currentSide)
            {
                case Side.Left:
                    {
                        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
                        currentSide = Side.Center;
                    }
                    break;
                case Side.Center:
                    {
                        transform.position = new Vector3(distanceSideX, transform.position.y, transform.position.z);
                        currentSide = Side.Right;
                    }
                    break;
                case Side.Right:
                    {

                    }
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (currentSide)
            {
                case Side.Left:
                    {

                    }
                    break;
                case Side.Center:
                    {
                        transform.position = new Vector3(-distanceSideX, transform.position.y, transform.position.z);
                        currentSide = Side.Left;
                    }
                    break;
                case Side.Right:
                    {
                        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
                        currentSide = Side.Center;
                    }
                    break;
            }
        }
    }

    private void ActualizeUIInformation()
    {
        m_controller.controllerUI.UpdatePagesNumber(pagesNumber);
        m_controller.controllerUI.UpdateScore(transform.position.z);
    }

    public void GameOver()
    {
        m_gameOver = true;
    }
}
