using System.Collections.Generic;
using UnityEngine;

public class PlayerStackController : MonoBehaviour
{
    [SerializeField] private PaperPool _paperPool;

    public List<GameObject> paperList = new List<GameObject>();

    [SerializeField] private Transform _paperPoint;


    public int activeColorIndex;

    [SerializeField] private float time = 0.01f;
    private float _currentTime;
    [SerializeField] private float _yPosition;



    private void Start()
    {
        ResetYPosition();
    }


    public void ResetYPosition()
    {
        _yPosition = _paperPoint.localPosition.y;
    }


    public void AddNewPaper(int colorIndex, Transform colorBoxTransform, Color color)
    {
        if (paperList.Count < 50)
        {
            if (_currentTime <= 0)
            {
                _currentTime = time;
                activeColorIndex = colorIndex;
                paperList.Add(_paperPool.paperList[_paperPool._paperIndex]);
                _paperPool.paperList[_paperPool._paperIndex].transform.SetParent(transform);
                _paperPool.CallNewPaper(colorBoxTransform.position, new Vector3(_paperPoint.localPosition.x, _yPosition, _paperPoint.localPosition.z), color);
                _yPosition += 0.1f;
            }
            else
            {
                _currentTime -= Time.deltaTime;
            }
        }
    }


    public int GetPaperListCount()
    {
        return paperList.Count;
    }


    public void RemovePaper()
    {
        paperList[paperList.Count - 1].transform.parent = null;
        paperList[paperList.Count - 1].transform.position = Vector3.zero;
        paperList.RemoveAt(paperList.Count - 1);

    }
}
