using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour
{
    private ThirdPersonMovement PlayerActions;

    [Header("Received Ingredient Data")]
    public List<IngredientData> receivedIngredientData = new List<IngredientData>();

    private BakeStation currentBakeStation;

    private void Start()
    {
        PlayerActions = new ThirdPersonMovement();
        PlayerActions.Player.Enable();

        PlayerActions.Player.Interact.performed += OnInteract;
    }

    private void OnDestroy()
    {
        if (PlayerActions != null)
        {
            PlayerActions.Player.Interact.performed -= OnInteract;
            PlayerActions.Player.Disable();
        }
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (currentBakeStation != null)
        {
            Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BakeStation"))
        {
            currentBakeStation = other.GetComponent<BakeStation>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BakeStation"))
        {
            if (currentBakeStation != null)
            {
                currentBakeStation = null;
            }
        }
    }

    private void Interact()
    {
        if (currentBakeStation == null)
            return;

        receivedIngredientData = new List<IngredientData>(
            currentBakeStation.GetIngredientData()
        );

        Debug.Log("Received " + receivedIngredientData.Count + " Ingredient Data assets!");
    }
}