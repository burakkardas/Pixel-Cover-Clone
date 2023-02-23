using System.Collections.Generic;
using UnityEngine;

public class PixelGenerator : MonoBehaviour
{
    public static PixelGenerator Instance;


    [SerializeField] private Texture2D _pixelArt;

    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private GameObject _colorBoxPrefab;

    [SerializeField] private List<Color> _colorList = new List<Color>();
    [SerializeField] private List<GameObject> _cellList = new List<GameObject>();
    [SerializeField] private List<GameObject> _colorBoxList = new List<GameObject>();

    [SerializeField] private Transform _pixelArtTranform;


    private int _xPosition = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    private void Start()
    {
        CreatePixelArea();
    }



    [ContextMenu("Create")]
    public void CreatePixelArea()
    {
        for (int x = 0; x < _pixelArt.width; x++)
        {
            for (int z = 0; z < _pixelArt.height; z++)
            {
                if (_pixelArt.GetPixel(x, z).a != 0)
                {
                    if (!_colorList.Contains(_pixelArt.GetPixel(x, z)))
                    {
                        _colorList.Add(_pixelArt.GetPixel(x, z));
                    }

                    GameObject _newCell = Instantiate(_cellPrefab, new Vector3(x, _cellPrefab.transform.position.y, z), _cellPrefab.transform.rotation);
                    _newCell.GetComponent<CellController>().currentColor = _pixelArt.GetPixel(x, z);
                    _newCell.transform.SetParent(_pixelArtTranform);
                    _cellList.Add(_newCell);
                }
            }
        }

        CreateNewColorBoxes();
        CheckCellValues();
        _pixelArtTranform.transform.position = new Vector3(-(_pixelArt.width / 2), 0f, (_pixelArt.height / 22));
    }



    private void CheckCellValues()
    {
        for (int i = 0; i < _colorList.Count; i++)
        {
            foreach (GameObject cell in _cellList)
            {
                if (_colorList[i] == cell.GetComponent<CellController>().currentColor)
                {
                    cell.GetComponent<CellController>().activeColor = i + 1;
                    cell.GetComponent<CellController>().SetStartValues(i + 1);
                    _colorBoxList[i].GetComponent<ColorBoxController>().colorIndex = i + 1;
                    _colorBoxList[i].GetComponent<ColorBoxController>().SetColorBoxValues(i + 1, _colorList[i]);
                }
            }
        }
    }




    private void CreateNewColorBoxes()
    {
        for (int i = 0; i < _colorList.Count; i++)
        {
            GameObject _newColorBox = Instantiate(_colorBoxPrefab, GetNewPosition(), _colorBoxPrefab.transform.rotation);
            _colorBoxList.Add(_newColorBox);
            _xPosition += 5;
        }
    }



    private Vector3 GetNewPosition()
    {
        return new Vector3(_xPosition, _colorBoxPrefab.transform.position.y, _colorBoxPrefab.transform.position.z);
    }
}
