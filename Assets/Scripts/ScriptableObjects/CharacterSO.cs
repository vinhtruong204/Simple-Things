using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObjects/Character", order = 0)]
public class CharacterSO : ScriptableObject
{
    public string characterName;
    public int maxHP;
}
