using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

/// <summary>
/// Captures a photo of the 3D baby/lion and UI frame.
/// </summary>
public class Take_Picture_Pampers_Character : MonoBehaviour
{
    [Header("UI Controls")]
    [SerializeField] private Button photoButton; // Assets/Buttons/Take_Photo_Button.png
    [SerializeField] private GameObject UIOverlayToHide;
    [SerializeField] private Image photoPreviewDisplay;

    private void Start()
    {
        if (photoButton != null)
            photoButton.onClick.AddListener(CapturePhoto);
    }

    public void CapturePhoto()
    {
        StartCoroutine(CaptureScreenRoutine());
    }

    private IEnumerator CaptureScreenRoutine()
    {
        // Hide trigger button during capture
        if (UIOverlayToHide != null) UIOverlayToHide.SetActive(false);

        yield return new WaitForEndOfFrame();

        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        // Restore UI
        if (UIOverlayToHide != null) UIOverlayToHide.SetActive(true);

        if (photoPreviewDisplay != null)
        {
            Sprite photoSprite = Sprite.Create(screenshot, new Rect(0, 0, screenshot.width, screenshot.height), new Vector2(0.5f, 0.5f));
            photoPreviewDisplay.sprite = photoSprite;
            photoPreviewDisplay.gameObject.SetActive(true);
        }

        Debug.Log("[Pampers] Photo captured successfully!");
    }
}
