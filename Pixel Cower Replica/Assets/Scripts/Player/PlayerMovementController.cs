using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerDataTransmitter _playerDataTransmitter;

    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private DynamicJoystick _joystick;




    private void FixedUpdate()
    {
        SetMovementPlayer();
    }



    private void SetMovementPlayer()
    {
        _playerRigidbody.velocity = GetNewVelocity();
        CheckVelocitySpeed();
    }



    private Vector3 GetNewVelocity()
    {
        return new Vector3(_joystick.Horizontal * _playerDataTransmitter.GetMovementSpeed() * Time.fixedDeltaTime, _playerRigidbody.velocity.y, _joystick.Vertical * _playerDataTransmitter.GetMovementSpeed() * Time.fixedDeltaTime);
    }



    private void SetPlayerRotation()
    {
        transform.rotation = Quaternion.LookRotation(_playerRigidbody.velocity);
    }



    private void CheckVelocitySpeed()
    {
        if (_playerRigidbody.velocity.x != 0 || _playerRigidbody.velocity.z != 0)
        {
            _playerDataTransmitter.SetPlayerRunAnimation(true);
            SetPlayerRotation();
        }
        else
        {
            _playerDataTransmitter.SetPlayerRunAnimation(false);
        }
    }
}
