using System.Collections.Generic;
using UnityEngine;

public class PlayerDataTransmitter : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerAnimationController _playerAnimationController;
    [SerializeField] private PlayerStackController _playerStackController;


    #region Stack
    public void AddNewPaper(int colorIndex, Transform colorBoxTransform, Color color)
    {
        _playerStackController.AddNewPaper(colorIndex, colorBoxTransform, color);
    }



    public int GetActiveColorIndex()
    {
        return _playerStackController.activeColorIndex;
    }



    public void RemovePaper()
    {
        _playerStackController.RemovePaper();
    }



    public int GetPaperListCount()
    {
        return _playerStackController.GetPaperListCount();
    }



    public void ResetYPosition()
    {
        _playerStackController.ResetYPosition();
    }



    public List<GameObject> GetPaperList()
    {
        return _playerStackController.paperList;
    }
    #endregion


    #region Animation
    public void SetPlayerRunAnimation(bool value)
    {
        _playerAnimationController.SetPlayerRunAnimation(value);
    }
    #endregion


    #region PlayerController
    public float GetMovementSpeed()
    {
        return _playerController.GetMovementSpeed();
    }



    public int GetStackSize()
    {
        return _playerController.GetStackSize();
    }

    #endregion
}
