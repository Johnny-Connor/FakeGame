using UnityEngine;

public class Player : MonoBehaviour
{

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
        GainScore();
        Movement();
    }

    public void ChangeIcon(int ID)
    {
        switch (ID)
        {
            case 0:
                _spriteRenderer.sprite = _iconsID[0];
                break;
            case 1:
                _spriteRenderer.sprite = _iconsID[1];
                break;
            case 2:
                _spriteRenderer.sprite = _iconsID[2];
                break;
            default:
                break;
        }
    }

    public void Movement()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
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

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
    }

    public int GetSCR
    {
        get { return SCR; }
    }

}
