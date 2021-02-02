using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmierBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed = -5f;

    void Update()
    {
        if (GameManager.gameState == GameManager.GameState.InGame)
        {
            Move();
            Destroy();
        }
    }

    void Move()
    {
        Vector2 position = this.transform.position;
        position.x += speed * Time.deltaTime;
        this.transform.position = position;
    }

    private void Destroy()
    {
        if (this.transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            UIManager.instance.AddScore();
        }
    }
}
