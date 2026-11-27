using TMPro;
using UnityEngine;

public class ReceiptData : MonoBehaviour
{
   public Receipt CurrentOrder {  get; private set; }
    [SerializeField] private TMP_Text Order;
    
    public void Setup(Receipt OrderCopy)
    {
        CurrentOrder = OrderCopy;
        Order.text = $"Order #{CurrentOrder.OrderNumber}\n" +
                             $"Food: {CurrentOrder.Food}\n" +
                             $"Drink: {CurrentOrder.Drink}";
    }
}
