using UnityEngine;

public class Player : MonoBehaviour
{

    private bool _isInvincible;
    private int HP = 1;
    private int SCR;
    [SerializeField] private Sprite[] _iconsID = new Sprite[3];
    private SpriteRenderer _spriteRenderer;
    private float _canScore = -1;
    private float _scoreFreq = 0.01f;

    private void Awake()
    {
        Cursor.visible = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Death();
        GainScore();
        InvincibilityCheck();
        Movement();
    }

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
        if (HP <= 0)
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
                SCR++;
                _canScore = Time.time + _scoreFreq;
            }
        }
        else
        {
            SCR = 0;
        }
    }

    private void InvincibilityCheck()
    {
        // add timer and rainbow animation
        if (_isInvincible)
        {
            ChangeIcon(2);
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
            HP -= dmg;
        }
    }

    public int GetSCR
    {
        get { return SCR; }
    }

}
