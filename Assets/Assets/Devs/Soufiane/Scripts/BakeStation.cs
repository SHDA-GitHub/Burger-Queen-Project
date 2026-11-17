using UnityEngine;
using System.Collections.Generic;

public class BakeStation : MonoBehaviour
{
    [Header("Available Ingredient Data")]
    public List<IngredientData> ingredientData = new List<IngredientData>();

    public List<IngredientData> GetIngredientData()
    {
        return ingredientData;
    }
}