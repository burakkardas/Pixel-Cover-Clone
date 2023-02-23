using UnityEngine;
using System.IO;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    private IncrementalLevel _incrementalLevel;


    private void Awake()
    {
        GetComponentValues();
    }



    private void GetComponentValues()
    {
        _incrementalLevel = new IncrementalLevel();


        if (File.Exists(Application.persistentDataPath + "/IncrementalLevel.json"))
        {
            Load();
        }
    }



    public float GetMovementSpeed()
    {
        return _playerData.speeds[_incrementalLevel.speedLevel].movementSpeed;
    }



    public int GetStackSize()
    {
        return _playerData.stacks[_incrementalLevel.stackLevel].stackSize;
    }



    #region Save&Load
    public void Save()
    {
        string json = JsonUtility.ToJson(_incrementalLevel, true);
        File.WriteAllText(Application.persistentDataPath + "/IncrementalLevel.json", json);
    }



    public void Load()
    {

        string json = File.ReadAllText(Application.persistentDataPath + "/IncrementalLevel.json");
        _incrementalLevel = JsonUtility.FromJson<IncrementalLevel>(json);
    }
    #endregion
}



public class IncrementalLevel
{
    public int stackLevel;
    public int speedLevel;
}

