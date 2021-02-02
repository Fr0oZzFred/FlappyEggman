using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject doublePalmier;
    [SerializeField]
    float spawnTimer = 1.5f;
    float spawnTime;
    GameObject palmier;
    Vector3 position;
    private static SpawnManager _instance;
    public static SpawnManager instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if (GameManager.gameState == GameManager.GameState.InGame)
        {
            spawn();
        }
    }

    void spawn()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <=0)
        {
            position = this.transform.position;
            position.y = Random.Range(0, 2.6f);
            palmier = Instantiate(doublePalmier, position, Quaternion.identity);
            spawnTime = spawnTimer;
        }
    }
}
