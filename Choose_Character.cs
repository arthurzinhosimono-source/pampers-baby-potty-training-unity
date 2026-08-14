using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages selection between Super Baby and Lion characters.
/// </summary>
public enum CharacterType
{
    SuperBaby,
    Lion
}

public class Choose_Character : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button babyButton; // Assets/Buttons/Pampers_Super_Baby_Button.png
    [SerializeField] private Button lionButton; // Assets/Buttons/Lion.png

    [Header("References")]
    [SerializeField] private World_Characters_Button worldCharacterManager;

    public static CharacterType SelectedCharacter { get; private set; } = CharacterType.SuperBaby;

    private void Awake()
    {
        if (babyButton != null)
            babyButton.onClick.AddListener(() => SelectCharacter(CharacterType.SuperBaby));

        if (lionButton != null)
            lionButton.onClick.AddListener(() => SelectCharacter(CharacterType.Lion));
    }

    public void SelectCharacter(CharacterType character)
    {
        SelectedCharacter = character;
        Debug.Log($"[Pampers] Selected Character: {character}");

        if (worldCharacterManager != null)
        {
            worldCharacterManager.SpawnCharacter(SelectedCharacter);
        }

        gameObject.SetActive(false); // Hide selection UI
    }
}
