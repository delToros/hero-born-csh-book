using UnityEngine;

public class Character
{
    public string Name;
    public int Exp;

    // Basic constructor, basically default value
    public Character()
    {
        Name = "Not your fucking business";
    }

    // Constructor overloading -
    // multiple constructors in a single class for a single param
    public Character(string name)
    {
        this.Name = name;
    }

    public void PrintStatsInfo()
    {
        Debug.Log($"Hero: {this.Name}\nXP: {this.Exp}");
    }

}
