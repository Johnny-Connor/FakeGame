using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Sprite[] _iconsID = new Sprite[3];
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        Cursor.visible = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
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
        }
    }

    public void Movement()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }

}
