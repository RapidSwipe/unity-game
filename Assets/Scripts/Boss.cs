using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject monster;
    public GameObject superMonster;

    private float targetTime = 2f;
    private Vector2 direction;
    private float speed;

    void Start()
    {
        direction = transform.right;
        speed = GameManager.Instance.bossSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            transform.Rotate(0, 180, 0);
            speed = Random.Range(0.5f, 3);
        }
    }
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
        targetTime -= Time.deltaTime;
        if(targetTime <= 0) {
            float randomChanceToSpawnMonster = Random.value;
            if(randomChanceToSpawnMonster < 0.94f)
            {
                SpawnMonster();
            } else
            {
                SpawnSuperMonster();
            }
            targetTime = Random.Range(GameManager.Instance.minMonsterSpawnRate, GameManager.Instance.maxMonsterSpawnRate);
        }
    }
    void SpawnMonster()
    {
        Instantiate(monster, transform.position, Quaternion.identity);
    }
    void SpawnSuperMonster()
    {
        Instantiate(superMonster, transform.position, Quaternion.identity);

    }
}
