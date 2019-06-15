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
    public float distanceSideX;

    private bool m_jumping;
    private bool m_sliding;

    private void Update()
    {
        playerRigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.UpArrow) && !m_jumping)
        {
            playerAnimator.SetBool("jump", true);
            StartCoroutine(JumpCoroutine());
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !m_sliding)
        {
            playerAnimator.SetBool("slide", true);
            StartCoroutine(SlideCoroutine());
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (currentSide)
            {
                case Side.Left:
                    {
                        transform.position = new Vector3(Mathf.Lerp(transform.position.x, 0f, 1f), transform.position.y, transform.position.z);
                        currentSide = Side.Center;
                    }
                    break;
                case Side.Center:
                    {
                        transform.position = new Vector3(Mathf.Lerp(transform.position.x, distanceSideX, 1f), transform.position.y, transform.position.z);
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
                        playerRigidbody.MovePosition(new Vector3(Mathf.Lerp(transform.position.x, -distanceSideX, 1f), transform.position.y, transform.position.z));
                        currentSide = Side.Left;
                    }
                    break;
                case Side.Right:
                    {
                        playerRigidbody.MovePosition(new Vector3(Mathf.Lerp(transform.position.x, 0f, 1f), transform.position.y, transform.position.z));
                        currentSide = Side.Center;
                    }
                    break;
            }
        }
    }

    public IEnumerator JumpCoroutine()
    {
        m_jumping = true;
        yield return new WaitForSeconds(0.7f);
        m_jumping = false;
        playerAnimator.SetBool("jump", false);
    }

    private IEnumerator SlideCoroutine()
    {
        m_sliding = true;
        yield return new WaitForSeconds(1.08f);
        m_sliding = false;
        playerAnimator.SetBool("slide", false);
    }
}
