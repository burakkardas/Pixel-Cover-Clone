using UnityEngine;


[CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public Stack[] stacks;
    public Speed[] speeds;
}


[System.Serializable]
public class Level
{
    public float price;
}


[System.Serializable]
public class Stack : Level
{
    public int stackSize;
}




[System.Serializable]
public class Speed : Level
{
    public float movementSpeed;
}
