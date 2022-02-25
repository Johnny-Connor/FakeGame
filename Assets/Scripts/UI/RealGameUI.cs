using UnityEngine;
using TMPro;

public class RealGameUI : MonoBehaviour
{

    [Header("Animator variables")]
    private Animator _animator;
    private int _scoreStartPhaseParameter;

    [Header("Class variables")]
    private bool _isGameRunning;
    [Tooltip("The text which is going to display the Player's score.")] [SerializeField] private TMP_Text _scoreText;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        // StringToHash lets you refer to a string through a number (variable int).
        _scoreStartPhaseParameter = Animator.StringToHash("ScoreStartPhase");
    }

    private void Update()
    {
        AnimationManager();
        UpdateScoreText();
    }

    #region Custom Functions
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

    // Used by "ScoreStart" and "ScoreEnd" animations.
    private void SetIsGameRunning(int zeroOrOne)
    {
        switch (zeroOrOne)
        {
            case 0:
                _isGameRunning = false;
                break;
            case 1:
                _isGameRunning = true;
                break;
            default:
                break;
        }
    }

    private void UpdateScoreText()
    {
        Player aux = FindObjectOfType<Player>();
        _scoreText.text = "Score: " + aux.GetSCR.ToString("n0");
    }
    #endregion Custom Functions

    #region Properties
    public bool GetIsGameRunning
    {
        get { return _isGameRunning; }
    }
    #endregion Properties

}
