using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RealGameUI : MonoBehaviour
{

    [Header("Animator")]
    private Animator _animator;
    private int _scoreStartPhaseParameter;
    private int _invinciblePhaseParameter;

    [Header("Children")]
    [Tooltip("The text which is going to display the Player's score.")] [SerializeField] private TMP_Text _scoreText;
    [Tooltip("The slider which is going to show invincible timer.")] [SerializeField] private Slider _slider;

    [Header("Parent")]
    private bool _isGameRunning;
    private bool _canChangeinvinciblePhaseToZero;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        // StringToHash lets you refer to a string without needing to type it over and over.
        _scoreStartPhaseParameter = Animator.StringToHash("ScorePopUpPhase");
        _invinciblePhaseParameter = Animator.StringToHash("InvinciblePopUpPhase");
    }

    private void Update()
    {
        InvincibleAnim();
        ScoreAnim();
        UpdateScoreText();
    }

    #region Custom Functions
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

    private void ScoreAnim()
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

    private void UpdateScoreText()
    {
        Player aux = FindObjectOfType<Player>();
        _scoreText.text = "Score: " + aux.GetSCR.ToString("n0");
    }

    private void InvincibleAnim()
    {
        Player aux = FindObjectOfType<Player>();
        _slider.maxValue = aux.GetInvincibleDuration;
        if (aux.GetIsInvincible)
        {
            _animator.SetInteger(_invinciblePhaseParameter, 0);
            _slider.value = aux.GetInvincibleDuration - aux.GetInvincibleTimer;
            _canChangeinvinciblePhaseToZero = true;
        }
        else if (aux.GetIsInvincible == false && _canChangeinvinciblePhaseToZero)
        {
            _animator.SetInteger(_invinciblePhaseParameter, 1);
        }
    }
    #endregion Custom Functions

    #region Properties
    public bool GetIsGameRunning
    {
        get { return _isGameRunning; }
    }
    #endregion Properties

}