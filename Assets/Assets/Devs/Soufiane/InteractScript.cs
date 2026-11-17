
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractable
{
    void Interact();
}

public class InteractScript : MonoBehaviour
{
    [Header("Input Action")]
    private ThirdPersonMovement PlayerActions;

    public Transform InteractorSource;
    public float InteractRange = 3f;

    private void Awake()
    {
        PlayerActions = new ThirdPersonMovement();

        PlayerActions.Player.Enable();
        PlayerActions.Player.Interact.performed += OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Ray r = new Ray(
            InteractorSource.position,
            InteractorSource.forward
        );

        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.TryGetComponent(
                out IInteractable interactObj))
            {
                interactObj.Interact();
            }
        }
    }

    private void OnDestroy()
    {
        PlayerActions.Player.Interact.performed -= OnInteract;
        PlayerActions.Player.Disable();
        PlayerActions.Dispose();
    }
}
