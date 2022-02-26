using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RealGameUI : MonoBehaviour
{

    [Header("Animator")]
    private Animator _animator;
    private int _gameOverTextPhaseParameter;
    private int _invinciblePhaseParameter;
    private int _scoreStartPhaseParameter;

    [Header("Children")]
    [Tooltip("The text which is going to display the Player's score.")] [SerializeField] private TMP_Text _scoreText;
    [Tooltip("The slider which is going to show invincible timer.")] [SerializeField] private Slider _slider;

    [Header("Parent")]
    private bool _isGameRunning;
    private bool _canChangeinvinciblePhaseToZero;

    [Header("Go references")]
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private FakeGameUI _fakeGameUI;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        // StringToHash lets you refer to a string without needing to type it over and over.
        _scoreStartPhaseParameter = Animator.StringToHash("ScorePopUpPhase");
        _invinciblePhaseParameter = Animator.StringToHash("InvinciblePopUpPhase");
        _gameOverTextPhaseParameter = Animator.StringToHash("GameOverTextPhase");
    }

    private void Update()
    {
        PlayerDies();
        InvincibleAnim();
        ScoreAnim();
        UpdateScoreText();
    }

    #region Custom Functions
    private void PlayerDies()
    {
        if (_player.GetIsAlive == false)
        {
            _isGameRunning = false;
            _audioManager.Stop("GameTheme");
            SetGameOverPhase(0);
        }
    }

    public void SetGameOverPhase(int ID)
    {
        switch (ID)
        {
            case 0:
                _animator.SetInteger(_gameOverTextPhaseParameter, 0);
                break;
            case 1:
                _animator.SetInteger(_gameOverTextPhaseParameter, 1);
                break;
            default:
                break;
        }
    }

    // Used by "ScoreAppears" and "GameOverTextDisappears" animations.
    private void SetIsGameRunningToOn()
    {
        _isGameRunning = true;
    }

    private void ScoreAnim()
    {
        if (_fakeGameUI.GetCanStartRealGameUI == true)
        {
            _animator.SetInteger(_scoreStartPhaseParameter, 0);
        }
    }

    private void UpdateScoreText()
    {
        _scoreText.text = "Score: " + _player.GetSCR.ToString("n0");
    }

    private void InvincibleAnim()
    {
        _slider.maxValue = _player.GetInvincibleDuration;
        if (_player.GetIsInvincible)
        {
            _animator.SetInteger(_invinciblePhaseParameter, 0);
            _slider.value = _player.GetInvincibleDuration - _player.GetInvincibleTimer;
            _canChangeinvinciblePhaseToZero = true;
        }
        else if (_player.GetIsInvincible == false && _canChangeinvinciblePhaseToZero)
        {
            _animator.SetInteger(_invinciblePhaseParameter, 1);
            _slider.value = 0;
        }
    }
    #endregion Custom Functions

    #region Properties
    public bool IsGameRunning
    {
        get { return _isGameRunning; }
    }
    #endregion Properties

}