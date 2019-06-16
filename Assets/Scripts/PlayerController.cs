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
    private float m_counterMultiplier;
    private float m_counterInvincible;
    private float m_counterMagnet;
    private float m_timeMultiplier;
    private float m_timeInvincible;
    private float m_timeMagnet;

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
        m_timeInvincible = PlayerPrefs.GetFloat("timeInvincible", 5);
        m_timeMultiplier = PlayerPrefs.GetFloat("timeMultiplier", 5);
        m_timeMagnet = PlayerPrefs.GetFloat("timeMagnet", 5);
    }

    private void Update()
    {
        CheckMovement();
        CheckInput();
        CheckMultiplier();
        CheckInvincible();
        CheckMagnet();
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
        speed += 0.001f;
        playerRigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
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

    public void ActivateMultiplier()
    {
        m_counterMultiplier = m_timeMultiplier;
        powerUpMultiplier = true;
    }

    private void CheckMultiplier()
    {
        if (powerUpMultiplier)
        {   
            m_counterMultiplier -= Time.deltaTime;
            if (m_counterMultiplier <= 0)
            {
                powerUpMultiplier = false;
            }
        }
    }

    public void ActivateInvincible()
    {
        if (!powerUpInvincible)
        {
            speed += 10f;
        }
            
        m_counterInvincible = m_timeInvincible;
        powerUpInvincible = true;
    }

    private void CheckInvincible()
    {
        if (powerUpInvincible)
        {
            m_counterInvincible -= Time.deltaTime;
            if (m_counterInvincible <= 0)
            {
                speed -= 10f;
                powerUpInvincible = false;
            }
        }
    }
    
    public void ActivateMagnet()
    {
        if (!powerUpMagnet)
        {
            magnetCollider.SetActive(true);
        }

        m_counterMagnet = m_timeMagnet;
        powerUpMagnet = true;
    }

    private void CheckMagnet()
    {
        if (powerUpMagnet)
        {
            m_counterMagnet -= Time.deltaTime;
                if (m_counterMagnet <= 0)
                {
                    magnetCollider.SetActive(false);
                    powerUpMagnet = false;
                }
        }
    }

    private void ActualizeUIInformation()
    {
        m_controller.controllerUI.UpdatePagesNumber(pagesNumber);
        m_controller.controllerUI.UpdateScore(transform.position.z);
    }

    public void KillPlayer()
    {
        m_controller.GameOver();
    }
}
