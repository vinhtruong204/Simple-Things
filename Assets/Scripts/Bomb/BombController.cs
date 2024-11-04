using UnityEngine;

public class BombController : MonoBehaviour
{
    public BombAnimation BombAnimation { get; private set; }
    public BombForce BombForce { get; private set; }
    public BombSendDamage BombSendDamage { get; private set; }

    private void Awake()
    {
        LoadAllComponents();
    }

    private void LoadAllComponents()
    {
        BombAnimation = GetComponentInChildren<BombAnimation>();
        BombForce = GetComponentInChildren<BombForce>();
        BombSendDamage = GetComponentInChildren<BombSendDamage>();
    }

}
