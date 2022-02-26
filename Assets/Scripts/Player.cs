using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Stats")]
    private bool _isAlive = true;
    private bool _isInvincible;
    private int _hp;
    private int _maxHp = 1;
    private int _scr;

    [Header("Animator variables")]
    private Animator _animator;
    private int _buffIdParameter;

    [Header("Components")]
    [SerializeField] private Sprite[] _iconsID = new Sprite[3];
    private SpriteRenderer _spriteRenderer;

    [Header("Aux")]
    private bool _hasDeathSoundPlayed;
    private float _canScore = -1;
    private float _scoreFreq = 0.01f;
    private float _invincibleTimer;
    private float _invincibleDuration = 5f;

    [Header("Go references")]
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private RealGameUI _realGameUI;

    private void Awake()
    {
        _hp = _maxHp;
        Cursor.visible = false;
        _animator = GetComponent<Animator>();
        _buffIdParameter = Animator.StringToHash("BuffId");
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Death();
        GainScore();
        InvincibilityCheck();
        Movement();
    }

    #region Custom Functions
    public void ChangeIcon(int ID)
    {
        if (_isInvincible == false)
        {
            // 1 - Normal | 2 - Click Available | 3 - Rock n roll
            switch (ID)
            {
                case 0:
                    _spriteRenderer.sprite = _iconsID[0];
                    break;
                case 1:
                    _spriteRenderer.sprite = _iconsID[1];
                    break;
                default:
                    break;
            }
        }
        else
        {
            _spriteRenderer.sprite = _iconsID[2];
        }
    }

    private void Death()
    {
        if (_hp <= 0)
        {

            _isAlive = false;
            _animator.SetInteger(_buffIdParameter, 2);
            if (_hasDeathSoundPlayed == false)
            {
                _audioManager.Play("Death");
                _hasDeathSoundPlayed = true;
            }
        }
    }

    private void GainScore()
    {
        if (_realGameUI.IsGameRunning)
        {
            if (Time.time > _canScore)
            {
                _scr++;
                _canScore = Time.time + _scoreFreq;
            }
        }
    }

    // Timer algorithm from https://docs.unity3d.com/ScriptReference/Time-deltaTime.html.
    private void InvincibilityCheck()
    {
        if (_isInvincible)
        {
            _invincibleTimer += Time.deltaTime;
            ChangeIcon(2);
            _animator.SetInteger(_buffIdParameter, 1);
            if (_invincibleTimer > _invincibleDuration)
            {
                _isInvincible = false;
                _invincibleTimer -= _invincibleDuration;
                ChangeIcon(0);
                _animator.SetInteger(_buffIdParameter, 0);
            }
        }
    }

    public void Movement()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (cursorPos.x < 8)
        {
            cursorPos.x = 8;
        }
        else if (cursorPos.x > 1912)
        {
            cursorPos.x = 1912;
        }
        if (cursorPos.y < 20)
        {
            cursorPos.y = 20;
        }
        else if (cursorPos.y > 1060)
        {
            cursorPos.y = 1060;
        }
        transform.position = cursorPos;
    }

    public void Revive()
    {
        _isAlive = true;
        _hp = _maxHp;
        _hasDeathSoundPlayed = false;
        _scr = 0;
        _animator.SetInteger(_buffIdParameter, 0);
    }

    public void TakeBuff()
    {
        _audioManager.Play("GetBuff");
        _isInvincible = true;
        if (_invincibleTimer != 0)
        {
            _invincibleTimer = 0;
        }
    }

    public void TakeDamage(int dmg)
    {
        if (_isInvincible == false)
        {
            _hp -= dmg;
        }
    }
    #endregion Custom Functions

    #region Properties
    public float GetInvincibleDuration
    {
        get { return _invincibleDuration; }
    }

    public float GetInvincibleTimer
    {
        get { return _invincibleTimer; }
    }

    public bool GetIsAlive
    {
        get { return _isAlive; }
    }

    public bool GetIsInvincible
    {
        get { return _isInvincible; }
    }

    public int GetSCR
    {
        get { return _scr; }
    }
    #endregion Properties
}