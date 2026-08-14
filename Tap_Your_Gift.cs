using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Allows tapping 3D/UI gift boxes spawned by character actions.
/// </summary>
public class Tap_Your_Gift : MonoBehaviour
{
    [Header("Gift Visuals")]
    [SerializeField] private GameObject giftBoxContainer;
    [SerializeField] private GameObject fingerPointer; // Assets/Images/Finger_Pointing.png
    [SerializeField] private ParticleSystem openParticles;

    [Header("Events")]
    public UnityEvent onGiftOpened;

    private bool giftAvailable = false;

    public void SpawnGift()
    {
        giftAvailable = true;
        if (giftBoxContainer != null) giftBoxContainer.SetActive(true);
        if (fingerPointer != null) fingerPointer.SetActive(true);
    }

    private void Update()
    {
        if (!giftAvailable) return;

        // Touch or Click input
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == giftBoxContainer.transform || hit.transform.IsChildOf(giftBoxContainer.transform))
                {
                    OpenGift();
                }
            }
        }
    }

    public void OpenGift()
    {
        giftAvailable = false;
        if (fingerPointer != null) fingerPointer.SetActive(false);
        if (openParticles != null) openParticles.Play();

        Debug.Log("[Pampers] Gift Opened!");
        
        Invoke(nameof(CompleteGiftEvent), 1.0f);
    }

    private void CompleteGiftEvent()
    {
        if (giftBoxContainer != null) giftBoxContainer.SetActive(false);
        onGiftOpened?.Invoke();
    }
}
