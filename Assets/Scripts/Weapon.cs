using UnityEngine;

public struct Weapon
{
    public string Name;
    public int Damage;

    public Weapon(string name, int damage)
    {
        this.Name = name;
        this.Damage = damage;
    }

    public void PrintWeaponStats()
    {
        Debug.Log($"Weapon: {this.Name}\nDamage: {this.Damage}");
    }
}
