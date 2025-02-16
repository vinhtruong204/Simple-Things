using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        PlayerController.OnPlayerSpawned += HandleLoadedPlayer;
    }

    private void HandleLoadedPlayer(GameObject Player)
    {
        virtualCamera.Follow = Player.transform;
    }

    void OnDisable()
    {
        PlayerController.OnPlayerSpawned -= HandleLoadedPlayer;
    }
}
