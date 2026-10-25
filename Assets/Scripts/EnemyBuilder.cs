using TMPro;
using UnityEngine;

public class EnemyBuilder
{

    private string _name;
    private int _health = 1;
    private float _speed = 5f;

    public EnemyBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public EnemyBuilder SetHealth(int health)
    {
        _health = health;
        return this;
    }

    public EnemyBuilder SetSpeed(float speed)
    {
        _speed = speed;
        return this;
    }

    public EnemyMovement Build()
    {
        GameObject enemyObj = new GameObject(_name);
        EnemyMovement enemyMovement = enemyObj.AddComponent<EnemyMovement>();
        enemyMovement.Initialize(_name, _health, _speed);
        return enemyMovement;
    }
}
