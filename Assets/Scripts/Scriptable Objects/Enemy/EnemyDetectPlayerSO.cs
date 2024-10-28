using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyDetectPlayerSO", menuName = "Scriptable Objects/EnemyDetectPlayerSO", order = 2)]
public class EnemyDetectPlayerSO : ScriptableObject
{
    public float visionRange;
    public Vector3 offsetLeft;
    public Vector3 offsetRight;
}