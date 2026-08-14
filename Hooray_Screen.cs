using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays completion stars, fireworks, and navigation buttons.
/// </summary>
public class Hooray_Screen : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject hoorayBanner; // Assets/Images/Hooray_You_Earned_Star.png
    [SerializeField] private GameObject starIcon;     // Assets/Icons/Stars.png
    [SerializeField] private GameObject fireworksDisplay; // Assets/Gifs/Fireworks.gif (UI Animated Image/Video)

    [Header("Navigation Buttons")]
    [SerializeField] private Button goToStarboardButton; // Assets/Buttons/Go_To_Starboard.png
    [SerializeField] private Button retryButton;          // Assets/Buttons/Retry_Button.png

    private void OnEnable()
    {
        ShowHooraySequence();
    }

    public void ShowHooraySequence()
    {
        if (hoorayBanner) hoorayBanner.SetActive(true);
        if (starIcon) starIcon.SetActive(true);
        if (fireworksDisplay) fireworksDisplay.SetActive(true);

        if (goToStarboardButton) goToStarboardButton.onClick.AddListener(OnGoToStarboard);
        if (retryButton) retryButton.onClick.AddListener(OnRetry);
    }

    private void OnGoToStarboard()
    {
        Debug.Log("[Pampers] Navigating to Starboard...");
        // Add Starboard navigation logic here
    }

    private void OnRetry()
    {
        Debug.Log("[Pampers] Restarting potty training round...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}
