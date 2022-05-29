using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesData : MonoBehaviour
{
    public const string EMPTY_ENEMY = "";
    List<DeadEnemy> deadEnemies = new List<DeadEnemy>();
    public DeadEnemy GetEnemy(string enemyId) {
        DeadEnemy enemy = new DeadEnemy(EMPTY_ENEMY, Vector3.zero, Vector3.zero);

        int i = 0;
        while (i < deadEnemies.Count && enemy.id  == EMPTY_ENEMY) {
            if (deadEnemies[i].id == enemyId) {
                enemy = deadEnemies[i];
            }
            i++;
        }

        return enemy;
    }

    public void SaveEnemy(string id, Vector3 position, Vector3 rotation) {
        DeadEnemy enemy = new DeadEnemy(id, position, rotation);
        deadEnemies.Add(enemy);
    }
}
