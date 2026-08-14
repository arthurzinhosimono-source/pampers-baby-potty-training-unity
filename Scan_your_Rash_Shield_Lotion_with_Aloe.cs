using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Handles scanning the Rash Shield Lotion pack for bonus rewards.
/// </summary>
public class Scan_your_Rash_Shield_Lotion_with_Aloe : MonoBehaviour
{
    [Header("UI & Visual Elements")]
    [SerializeField] private GameObject lotionOverlayGuide;
    [SerializeField] private GameObject fingerPointingPrompt; // Assets/Images/Finger_Pointing.png
    [SerializeField] private GameObject successBadge;

    [Header("Events")]
    public UnityEvent onLotionScanned;

    private void OnEnable()
    {
        ShowScanPrompt();
    }

    public void ShowScanPrompt()
    {
        if (lotionOverlayGuide != null) lotionOverlayGuide.SetActive(true);
        if (fingerPointingPrompt != null) fingerPointingPrompt.SetActive(true);
    }

    public void OnLotionDetected()
    {
        if (lotionOverlayGuide != null) lotionOverlayGuide.SetActive(false);
        if (fingerPointingPrompt != null) fingerPointingPrompt.SetActive(false);
        if (successBadge != null) successBadge.SetActive(true);

        Debug.Log("[Pampers] Rash Shield Lotion with Aloe Verified!");
        onLotionScanned?.Invoke();
    }
}
