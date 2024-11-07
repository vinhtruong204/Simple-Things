using UnityEngine;

public class FrameRateCap : MonoBehaviour
{
    private void Awake()
    {
        QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled
        Application.targetFrameRate = 60;
    }
}
