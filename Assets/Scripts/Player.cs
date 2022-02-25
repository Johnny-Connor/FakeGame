using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Stats")]
    private bool _isInvincible;
    private int _hp = 1;
    private int _scr;

    [Header("Animator variables")]
    private Animator _animator;
    private int _buffIdParameter;

    [Header("Components")]
    [SerializeField] private Sprite[] _iconsID = new Sprite[3];
    private SpriteRenderer _spriteRenderer;

    [Header("Aux")]
    private float _canScore = -1;
    private float _scoreFreq = 0.01f;
    private float _invincibleTimer;
    private float _invincibleDuration = 7.5f;

    private void Awake()
    {
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
            Debug.Log("dead");
        }
    }

    private void GainScore()
    {
        RealGameUI aux = FindObjectOfType<RealGameUI>();
        if (aux.GetIsGameRunning)
        {
            if (Time.time > _canScore)
            {
                _scr++;
                _canScore = Time.time + _scoreFreq;
            }
        }
        else
        {
            _scr = 0;
        }
    }

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

    public void TakeBuff()
    {
        _isInvincible = true;
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
    public int GetSCR
    {
        get { return _scr; }
    }

    public float GetInvincibleTimer
    {
        get { return _invincibleTimer; }
    }
    #endregion Properties
}
