using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractScript : MonoBehaviour
{
    [Header("Input Action")]
    private ThirdPersonMovement PlayerActions;

    private readonly HashSet<GameObject> stationInRange =
        new HashSet<GameObject>();

    private void Start()
    {
        if (PlayerActions != null)
        {
            PlayerActions.Player.Enable();
            PlayerActions.Player.Interact.performed += OnInteract;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BakeStation"))
        {
            stationInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        stationInRange.Remove(other.gameObject);
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        GameObject closestBlock = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject block in stationInRange)
        {
            if (block == null)
                continue;

            float distance = (
                block.transform.position - transform.position
            ).sqrMagnitude;

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestBlock = block;
            }
        }

        if (closestBlock != null &&
            closestBlock.CompareTag("BakeStation"))
        {
            Destroy(closestBlock);
        }
    }
}
