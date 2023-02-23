using UnityEngine;
using TMPro;

public class ColorBoxController : MonoBehaviour
{
    [SerializeField] private TMP_Text _colorNumberText;

    [SerializeField] private Renderer _colorBoxRenderer;
    private MaterialPropertyBlock _materialPropertyBlock;
    public Color mainColor;
    public int colorIndex;



    private void Awake()
    {
        _materialPropertyBlock = new MaterialPropertyBlock();
    }



    public void SetColorBoxValues(int value, Color color)
    {
        colorIndex = value;
        SetColorBoxNumberValue();
        SetColorBoxColor(color);
    }




    private void SetColorBoxColor(Color color)
    {
        mainColor = color;
        _materialPropertyBlock.SetColor("_Color", mainColor);
        _colorBoxRenderer.SetPropertyBlock(_materialPropertyBlock);
    }



    private void SetColorBoxNumberValue()
    {
        _colorNumberText.text = colorIndex.ToString();
    }
}
