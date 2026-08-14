using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls 3D Character models, action swapping (Jump, Spin, Give Gift), and environment.
/// </summary>
public class World_Characters_Button : MonoBehaviour
{
    [Header("Environment")]
    [SerializeField] private GameObject grassGroundPrefab; // Assets/3D_Animations/Grass_Ground.obj
    [SerializeField] private GameObject babyHousePrefab;  // Assets/3D_Animations/Pampers_Super_Baby_House.obj

    [Header("Super Baby Mesh Options")]
    [SerializeField] private GameObject babyIdle;     // Pampers_Super_Baby.obj
    [SerializeField] private GameObject babySpinning; // Pampers_Super_Baby_Spinning.obj
    [SerializeField] private GameObject babyJumping;  // Pampers_Super_Baby_Jumping.obj
    [SerializeField] private GameObject babyGift;     // Pampers_Super_Baby_Give_a_Gift.obj

    [Header("Lion Mesh Options")]
    [SerializeField] private GameObject lionIdle;     // Lion.obj
    [SerializeField] private GameObject lionSpinning; // Lion_Spinning.obj
    [SerializeField] private GameObject lionJumping;  // Lion_Jumping.obj
    [SerializeField] private GameObject lionGift;     // Lion_Give_a_Gift.obj

    [Header("Action Buttons")]
    [SerializeField] private Button spinButton;
    [SerializeField] private Button jumpButton;
    [SerializeField] private Button giftButton;

    private CharacterType currentType;

    private void Start()
    {
        if (spinButton) spinButton.onClick.AddListener(TriggerSpin);
        if (jumpButton) jumpButton.onClick.AddListener(TriggerJump);
        if (giftButton) giftButton.onClick.AddListener(TriggerGift);

        SpawnCharacter(Choose_Character.SelectedCharacter);
    }

    public void SpawnCharacter(CharacterType type)
    {
        currentType = type;
        ResetAllActionMeshes();

        if (currentType == CharacterType.SuperBaby)
        {
            if (babyIdle) babyIdle.SetActive(true);
        }
        else
        {
            if (lionIdle) lionIdle.SetActive(true);
        }
    }

    public void TriggerSpin()
    {
        ResetAllActionMeshes();
        if (currentType == CharacterType.SuperBaby)
            ActivateAction(babySpinning, babyIdle);
        else
            ActivateAction(lionSpinning, lionIdle);
    }

    public void TriggerJump()
    {
        ResetAllActionMeshes();
        if (currentType == CharacterType.SuperBaby)
            ActivateAction(babyJumping, babyIdle);
        else
            ActivateAction(lionJumping, lionIdle);
    }

    public void TriggerGift()
    {
        ResetAllActionMeshes();
        if (currentType == CharacterType.SuperBaby)
            ActivateAction(babyGift, babyIdle);
        else
            ActivateAction(lionGift, lionIdle);

        // Find gift script and activate prompt
        Tap_Your_Gift giftScript = FindObjectOfType<Tap_Your_Gift>();
        if (giftScript != null) giftScript.SpawnGift();
    }

    private void ActivateAction(GameObject actionMesh, GameObject defaultMesh)
    {
        if (actionMesh != null)
        {
            actionMesh.SetActive(true);
            Invoke(nameof(ResetToIdle), 2.5f);
        }
        else if (defaultMesh != null)
        {
            defaultMesh.SetActive(true);
        }
    }

    private void ResetToIdle()
    {
        ResetAllActionMeshes();
        if (currentType == CharacterType.SuperBaby && babyIdle) babyIdle.SetActive(true);
        if (currentType == CharacterType.Lion && lionIdle) lionIdle.SetActive(true);
    }

    private void ResetAllActionMeshes()
    {
        CancelInvoke(nameof(ResetToIdle));
        if (babyIdle) babyIdle.SetActive(false);
        if (babySpinning) babySpinning.SetActive(false);
        if (babyJumping) babyJumping.SetActive(false);
        if (babyGift) babyGift.SetActive(false);

        if (lionIdle) lionIdle.SetActive(false);
        if (lionSpinning) lionSpinning.SetActive(false);
        if (lionJumping) lionJumping.SetActive(false);
        if (lionGift) lionGift.SetActive(false);
    }
}
