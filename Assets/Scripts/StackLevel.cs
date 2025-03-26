using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stack", menuName = "StackLevel", order = 0)]
public class StackLevel : ScriptableObject
{
    public List<Sprite> stack = new();

    public int GetBlockCount()
    {
        return stack.Count;
    }

    public Sprite GetBlock(int index)
    {
        return stack[stack.Count - index - 1]; 
    }
}
