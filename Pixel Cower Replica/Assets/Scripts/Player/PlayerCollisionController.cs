using UnityEngine;
using BUMGames;

public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField] private PlayerDataTransmitter _playerDataTransmitter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag.CELL))
        {
            if (other.gameObject.GetComponent<CellController>().activeColor == _playerDataTransmitter.GetActiveColorIndex())
            {
                if (_playerDataTransmitter.GetPaperListCount() > 0)
                {
                    if (!other.gameObject.GetComponent<CellController>()._isComplete)
                    {
                        other.gameObject.GetComponent<CellController>().PaintCell();
                        _playerDataTransmitter.RemovePaper();
                    }

                }

            }



            if (_playerDataTransmitter.GetPaperList().Count == 0)
            {
                _playerDataTransmitter.ResetYPosition();
            }
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(Tag.COLOR_BOX))
        {
            _playerDataTransmitter.AddNewPaper(other.gameObject.GetComponent<ColorBoxController>().colorIndex, other.gameObject.transform, other.gameObject.GetComponent<ColorBoxController>().mainColor);
        }
    }
}
