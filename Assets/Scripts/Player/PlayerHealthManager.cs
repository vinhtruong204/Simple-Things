using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerHealthManager : MonoBehaviour
{
    private CharacterMaxHPSO playerMaxHPSO;
    private PlayerDamageReceiver playerDamageReceiver;

    private void Awake()
    {
        playerDamageReceiver = transform.parent.GetComponentInChildren<PlayerDamageReceiver>();
    }

    public async Task<(int CurrentHP, int MaxHP)> LoadHPAsync()
    {

        AsyncOperationHandle<CharacterMaxHPSO> handle = Addressables.LoadAssetAsync<CharacterMaxHPSO>(ScriptableObjectString.PlayerSOPath.MAXHP_PATH);
        
        // Await load task complete
        await handle.Task;

        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogWarning("Player max hp scriptable object could not loaded!");

            // Return default values if could not load scriptable object
            return (5, 5); 
        }

        playerMaxHPSO = handle.Result;

        // Get max hp from scriptable object
        int MaxHP = playerMaxHPSO.maxHP;

        // Get hp from previous level
        int CurrentHP = PlayerPrefs.GetInt("CurrentHP");

        // If current hp is not set from previous level
        if (CurrentHP == 0)
        {
            // Set max hp for current hp
            CurrentHP = MaxHP;
        }

        return (CurrentHP, MaxHP);
    }

    public void SaveHP()
    {
        PlayerPrefs.SetInt("CurrentHP", playerDamageReceiver.CurrentHP);
    }

    public void ClearHP()
    {
        PlayerPrefs.DeleteKey("CurrentHP");
    }
}
