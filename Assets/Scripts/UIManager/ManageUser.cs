using TMPro;
using Unity.Netcode;
using UnityEngine;

public class ManageUser : MonoBehaviour
{
    public static ManageUser Instance { get; private set; }
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Dropdown dropdown;

    public string Username => inputField.text;
    public string StartMode => dropdown.options[dropdown.value].text;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
}
