
using UnityEngine;

public class ReceiptUI : MonoBehaviour
{
    Player PlayerScript;
    
    public Receipt CurrentReceipt;
    public GameObject receiptobject;
    public Transform Canvas;
    private void Start()
    {
        PlayerScript = FindAnyObjectByType<Player>();
        

    }

    public void MakeReceipt()
    {
        CurrentReceipt.Drink = PlayerScript.ChosenDrink;
        CurrentReceipt.Food  = PlayerScript.ChosenFood;
        CurrentReceipt.OrderNumber++;
        Receipt copy = CurrentReceipt.CreateCopy();

        GameObject Spawned = Instantiate(receiptobject, Canvas);

        if(Spawned.TryGetComponent<ReceiptData>(out var Display))
        {
            
            Display.Setup(copy);
        }

    }


}
