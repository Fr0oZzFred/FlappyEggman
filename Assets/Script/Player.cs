using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float jump = 5.0f;
    [SerializeField]
    float jumpTimer = 0.25f;
    private float jumpTime = 0f;
    int lastJump = 0;
    Rigidbody2D rigidbody2d;
    AudioSource jumpsound;
    void Start()
    {
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        position.x = Screen.width * 0.25f;
        position.y = Screen.height * 0.5f;
        transform.position = Camera.main.ScreenToWorldPoint(position);
        rigidbody2d = GetComponent<Rigidbody2D>();
        jumpsound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameManager.gameState == GameManager.GameState.Start && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)))
        {
            jumpsound.Play();
            rigidbody2d.velocity = Vector2.up * jump;
            jumpTime = jumpTimer;
            GameManager.instance.ChangeGameState(GameManager.GameState.InGame);
        }
        if (GameManager.gameState == GameManager.GameState.InGame)
        {
            Jump();
        }
        if(GameManager.gameState == GameManager.GameState.Death && lastJump == 0)
        {
            rigidbody2d.velocity = Vector2.up * jump;
            jumpTime = jumpTimer;
            ++lastJump;
        }
    }

    public void Jump()
    {
        jumpTime -= Time.deltaTime;
        if ( jumpTime < 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            {
                jumpsound.Play();
                rigidbody2d.velocity = Vector2.up * jump;
                jumpTime = jumpTimer;
            }
        }
    }
}
