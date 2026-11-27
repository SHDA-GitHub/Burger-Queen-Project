using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Receipt", menuName = "Scriptable Objects/Receipt")]
public class Receipt : ScriptableObject
{

    public Sprite Background;
    public int OrderNumber;
    public  string Food; 
    public string Drink;

    public Receipt CreateCopy()
    {
        return Instantiate(this);
        
    }
    
}
