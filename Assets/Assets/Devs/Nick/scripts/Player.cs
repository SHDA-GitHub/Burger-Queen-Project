using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public bool CustomerInRange;
    private ThirdPersonMovement PlayerActions;
    Customer CurrentCustomer;
    ReceiptUI ReceiptUI;
    public string ChosenFood;
    public string ChosenDrink;

    void Start()
    {
        ReceiptUI = FindAnyObjectByType<ReceiptUI>();
        PlayerActions = new ThirdPersonMovement();
        CustomerInRange = false;
        PlayerActions.Player.Enable();
        PlayerActions.Player.r.performed += GetReceipt;
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Customer"))
        {
            CustomerInRange = true;
            CurrentCustomer = other.GetComponentInParent<Customer>();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Customer"))
        {
            CustomerInRange = false;
            CurrentCustomer = null;
        }
    }
    public void GetReceipt(InputAction.CallbackContext context)
    {
        if (CustomerInRange == true)
        {
            
            if (CurrentCustomer != null)
            {
                ChosenDrink = CurrentCustomer.ChosenDrink;
                ChosenFood = CurrentCustomer.Chosenfood;
                ReceiptUI.MakeReceipt();
                ChosenFood = null;
                ChosenDrink = null;

               
            }
        }
    }
}
