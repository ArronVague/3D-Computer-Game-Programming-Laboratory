using System;
using UnityEngine;

[System.Serializable]
public class Attributes
{
    [Tooltip("blood")]
    public int blood;
    [Tooltip("difficulty")]
    public int initial_difficulty;
    [Tooltip("number of UFOs per round")]
    public int UFOs_per_round;
}

[CreateAssetMenu(fileName = "CharacterItem", menuName = "(ScriptableObject)CharacterItem")]
public class CharacterItem : ScriptableObject
{
    public string Name;
    public string Desc;
    [Tooltip("game settings")]
    public Attributes Attributes;

    public static CharacterItem CreateCharacterItem()
    {
        CharacterItem item = ScriptableObject.CreateInstance<CharacterItem>();
        item.Attributes = new Attributes();
        return item;
    }
}