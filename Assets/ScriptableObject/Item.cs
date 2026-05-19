using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public enum ObjectType {Weapon, Armor, Consumable}

    public Sprite objectImage;
    public string nombre;
    public ObjectType objectType;
    public float value;
}
