using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour
{
    private ThirdPersonMovement PlayerActions;

    [Header("Received Ingredient Data")]
    public List<IngredientData> receivedIngredientData = new List<IngredientData>();

    private BakeStation currentBakeStation;
    private TrashCan currentTrashCan;

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
            InteractWithBakeStation();
        }
        else if (currentTrashCan != null)
        {
            InteractWithTrashCan();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BakeStation"))
        {
            currentBakeStation = other.GetComponent<BakeStation>();
        }

        if (other.CompareTag("TrashCan"))
        {
            currentTrashCan = other.GetComponent<TrashCan>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BakeStation"))
        {
            currentBakeStation = null;
        }

        if (other.CompareTag("TrashCan"))
        {
            currentTrashCan = null;
        }
    }

    private void InteractWithBakeStation()
    {
        if (currentBakeStation == null)
            return;

        IngredientData receivedIngredient = currentBakeStation.GetNextIngredient();

        if (receivedIngredient == null)
        {
            Debug.Log("Bake Station has no ingredients!");
            return;
        }

        receivedIngredientData.Clear();
        receivedIngredientData.Add(receivedIngredient);

        Debug.Log("Received ingredient: " + receivedIngredient.name);
    }

    private void InteractWithTrashCan()
    {
        if (receivedIngredientData.Count == 0)
        {
            Debug.Log("You have no ingredients to throw away!");
            return;
        }

        receivedIngredientData.Clear();

        Debug.Log("All ingredients thrown away!");
    }
}