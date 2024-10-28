using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterMaxHPSO", menuName = "Scriptable Objects/CharacterMaxHPSO", order = 0)]
public class CharacterMaxHPSO : ScriptableObject
{
    public string characterName;
    public int maxHP;
}
