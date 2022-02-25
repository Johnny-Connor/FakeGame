using UnityEngine;

public class FakeGameUI : MonoBehaviour
{

    [Header("Animator variables")]
    private Animator _animator;
    private int _gameStartPhaseParameter;

    [Header("Class variables")]
    private bool _canStartRealGameUI;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        // StringToHash lets you refer to a string through a number (variable int).
        _gameStartPhaseParameter = Animator.StringToHash("GameStartPhase");
    }

    public void SetAnimation(int ID)
    {
        switch (ID)
        {
            case 0:
                _animator.SetInteger(_gameStartPhaseParameter, ID);
                break;
            case 1:
                _animator.SetInteger(_gameStartPhaseParameter, ID);
                break;
            default:
                break;
        }
    }

    // Used in "GameStart" animation.
    private void SetCanStartRealGameUI(int zeroOrOne)
    {
        switch (zeroOrOne)
        {
            case 0:
                _canStartRealGameUI = false;
                break;
            case 1:
                _canStartRealGameUI = true;
                break;
            default:
                break;
        }
    }

    public bool GetCanStartRealGameUI
    {
        get { return _canStartRealGameUI; }
    }

}
