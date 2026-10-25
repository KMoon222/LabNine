using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public string EnemyName { get; private set; }
    public int Health { get; private set; }
    public float Speed { get; private set; }

    public bool enemyActive = true;
    public bool moveLeft = false;

    public event Action EnemyDestroyed;


    public void Initialize (string name, int health, float speed)
    {
        EnemyName = name;
        Health = health;
        Speed = speed;
    }

    void Awake()
    {
        SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        CapsuleCollider2D collider = gameObject.AddComponent<CapsuleCollider2D>();
        Sprite sprite = Resources.Load<Sprite>("ship_K");
        spriteRenderer.sprite = sprite;
        transform.Rotate(0f, 0f, 180f);
        transform.position = new Vector3(-9f, 4f, 0);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Health -= 1;
        }
    }

    void Update()
    {
        if (enemyActive)
        {
            if (!moveLeft)
            {
                if (transform.position.x < 9)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * Speed);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
                    moveLeft = true;
                }
            }
            if (moveLeft)
            {
                if (transform.position.x > -9)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * Speed);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
                    moveLeft = false;
                }
            }
        }

        if (Health <= 0)
        {
            EnemyDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
