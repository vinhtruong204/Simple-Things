public class PlayerDamageReceiver : DamageReceiver
{
    private PlayerAnimation playerAnimation;

    private PlayerHealthManager playerHealthManager;

    private void Start()
    {
        playerAnimation = transform.parent.GetComponentInChildren<PlayerAnimation>();
        playerHealthManager = transform.parent.GetComponentInChildren<PlayerHealthManager>();

        InitializeHealthPoint();
    }

    private async void InitializeHealthPoint()
    {
        // Get result from load health point method
        (int CurrentHP, int MaxHP) result = await playerHealthManager.LoadHPAsync();

        // Initial current and max HP
        CurrentHP = result.CurrentHP;
        MaxHP = result.MaxHP;
    }

    protected override void HitHandle()
    {
        playerAnimation.PlayHitAnimation();
    }

    protected override void DeadHandle()
    {
        playerAnimation.PlayDeadHitAnimation();
    }
}
