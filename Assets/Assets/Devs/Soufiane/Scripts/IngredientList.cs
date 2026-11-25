using UnityEngine;
using System.Collections.Generic;

public enum Bread
{
    Wit,
    Bruin,
    GlutenVrij,
}

public enum Fish
{
    Haring,
    Kibbeling,
    Zalm,
    Paling,
    Makreel,
    Inktvisringen,
    Mosselen,
    Garnalen,
    Witvis,
    Kabbeljauw,
    Schol,
}

public enum Sauce
{
    Ravigotte,
    Remoulade,
    KnoflookSaus
}

public enum Drinks
{
    Cola,
    Fanta,
    Sprite,
    IceTea,
    Cassis,
    SpaRood
}

[CreateAssetMenu(fileName = "New Ingredient Data", menuName = "Game/Ingredient Data")]
public class IngredientData : ScriptableObject
{
    public List<Bread> breads = new List<Bread>();
    public List<Fish> fish = new List<Fish>();
    public List<Sauce> sauces = new List<Sauce>();
    public List<Drinks> drinks = new List<Drinks>();
}