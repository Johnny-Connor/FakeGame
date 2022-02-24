using UnityEngine;

public class RealGameUI : MonoBehaviour
{

    private Animator _animator;
    private int _scoreStartPhaseParameter;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        // StringToHash lets you refer to a string through a number (variable int).
        _scoreStartPhaseParameter = Animator.StringToHash("ScoreStartPhase");
    }

    private void Update()
    {
        AnimationManager();
    }

    private void AnimationManager()
    {
        FakeGameUI aux = FindObjectOfType<FakeGameUI>();
        if (aux.GetCanStartRealGameUI == true)
        {
            _animator.SetInteger(_scoreStartPhaseParameter, 0);
        }
        else
        {
            _animator.SetInteger(_scoreStartPhaseParameter, 1);
        }
    }

}
