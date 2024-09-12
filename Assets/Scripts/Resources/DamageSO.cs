using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "ScriptableObjects/DamageSO", order = 1)]
public class DamageSO : ScriptableObject
{
    public int currentHp;
    public int maxHp;
    public int amountDamage;
}
