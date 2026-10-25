using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    private int score;

    private int count = 15;

    private void Start()
    {
        {
            StartCoroutine(SpawnAndWait());
        }
    }

    private IEnumerator SpawnAndWait()
    {

        while (count > 0)
        {
            if (count > 10 && count <= 15)
            {
                SpawnBasicEnemy();
                count--;
                yield return new WaitForSeconds(0.5f);
            }

            if (count <= 10 && count > 5)
            {
                SpawnFastEnemy();
                count--;
                yield return new WaitForSeconds(0.5f);
            }
            if (count <= 5 && count > 0)
            {
                SpawnStrongEnemy();
                count--;
                yield return new WaitForSeconds(0.5f);
            }
        }

    }

    private void SpawnBasicEnemy()
    {
        EnemyMovement enemy1 = new EnemyBuilder()
            .SetName("Basic")
            .SetHealth(1)
            .SetSpeed(4f)
            .Build();
        enemy1.EnemyDestroyed += OnEnemyDestroyed;

    }

    private void SpawnFastEnemy()
    {
        EnemyMovement enemy1 = new EnemyBuilder()
            .SetName("Fast")
            .SetHealth(1)
            .SetSpeed(8f)
            .Build();
        enemy1.EnemyDestroyed += OnEnemyDestroyed;

    }

    private void SpawnStrongEnemy()
    {
        EnemyMovement enemy1 = new EnemyBuilder()
            .SetName("Strong")
            .SetHealth(3)
            .SetSpeed(2f)
            .Build();
        enemy1.EnemyDestroyed += OnEnemyDestroyed;

    }


    private void OnEnemyDestroyed()
    {
        AddToScore();
    }

    private void AddToScore()
    {
        score += 1;
        ScoreText.text = "Score: " + score;
    }
}
