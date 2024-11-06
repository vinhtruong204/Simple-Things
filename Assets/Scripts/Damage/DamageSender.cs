using UnityEngine;

public abstract class DamageSender : MonoBehaviour
{
    // Amount damge to send
    protected int amount;

    protected abstract void InitialAmountDamage(); // Initial amount damage to send

    public void SendDamage(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;

        SendDamge(damageReceiver);
    }

    public void SendDamge(DamageReceiver damgeReceiver)
    {
        damgeReceiver.Deduct(amount);
    }
}
