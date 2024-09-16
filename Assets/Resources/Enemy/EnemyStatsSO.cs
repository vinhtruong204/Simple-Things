using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Stats", menuName = "ScriptableObjects/EnemyStats", order = 1)]
public class EnemyStatsSO : ScriptableObject
{
    public string enemyName;
    public int maxHP;
    public int amountDamage;
}