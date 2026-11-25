using UnityEngine;
using System.Collections.Generic;

public class BakeStation : MonoBehaviour
{
    [Header("Available Ingredient Data")]
    public List<IngredientData> ingredientData = new List<IngredientData>();

    private int currentIngredientIndex = 0;

    public IngredientData GetNextIngredient()
    {
        if (ingredientData == null || ingredientData.Count == 0)
            return null;

        IngredientData selectedIngredient = ingredientData[currentIngredientIndex];

        currentIngredientIndex++;

        if (currentIngredientIndex >= ingredientData.Count)
        {
            currentIngredientIndex = 0;
        }

        return selectedIngredient;
    }
}