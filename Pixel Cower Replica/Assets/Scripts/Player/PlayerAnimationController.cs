using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;



    public void SetPlayerRunAnimation(bool value)
    {
        _animator.SetBool("Run", value);
    }
}
