using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PaperPool : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();

    [SerializeField] private GameObject _paperPrefab;


    [SerializeField] private Material _paperMaterial;


    public int _maxPaperCount;
    public int _paperIndex;
    [SerializeField] private float _duration;

    private void Start()
    {
        CreateNewPaper();
    }



    private void CreateNewPaper()
    {
        for (int i = 0; i < _maxPaperCount; i++)
        {
            GameObject _newPaper = Instantiate(_paperPrefab, transform.position, Quaternion.identity);
            _newPaper.SetActive(false);
            paperList.Add(_newPaper);
        }
    }




    public void CallNewPaper(Vector3 position, Vector3 targetPosition, Color color)
    {
        _paperMaterial.color = color;
        paperList[_paperIndex].SetActive(true);
        paperList[_paperIndex].transform.position = position;
        paperList[_paperIndex].transform.DOLocalMove(targetPosition, _duration);
        _paperIndex++;

        if (_paperIndex >= _maxPaperCount)
        {
            _paperIndex = 0;
        }
    }
}
