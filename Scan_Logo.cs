using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Handles logo detection and initial verification for the Pampers app.
/// </summary>
public class Scan_Logo : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private RawImage cameraFeed;
    [SerializeField] private Image targetLogoOverlay;
    [SerializeField] private GameObject scanningIndicator;
    [SerializeField] private Button skipScanButton;

    [Header("Settings")]
    [SerializeField] private Texture2D logoToMatch; // Assets/Logos/Pampers_Baby_Dry_Logo.png
    
    [Header("Events")]
    public UnityEvent onLogoSuccessfullyScanned;

    private bool isScanning = true;

    private void Start()
    {
        if (skipScanButton != null)
            skipScanButton.onClick.AddListener(OnScanComplete);

        StartScanning();
    }

    public void StartScanning()
    {
        isScanning = true;
        if (scanningIndicator != null) scanningIndicator.SetActive(true);
    }

    public void OnScanComplete()
    {
        if (!isScanning) return;
        
        isScanning = false;
        if (scanningIndicator != null) scanningIndicator.SetActive(false);
        
        Debug.Log("[Pampers] Logo Scanned Successfully!");
        onLogoSuccessfullyScanned?.Invoke();
    }

    // Call from Vuforia / AR Foundation or custom image tracker
    public void TargetFound()
    {
        OnScanComplete();
    }
}
