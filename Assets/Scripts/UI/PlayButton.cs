using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    private Button _button;
    private Color _digitalGreen;
    private ColorBlock _colorBlock;

    private void Awake()
    {
        SetupVariables();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Changing color (doesn't work due to a bug, apparently).
            _colorBlock.normalColor = _digitalGreen;
            _button.colors = _colorBlock;
            // Finding player and changing its icon.
            Player player = FindObjectOfType<Player>();
            player.ChangeIcon(1);
            if (Input.GetMouseButton(0))
            {
                FakeGameUI aux = FindObjectOfType<FakeGameUI>();
                aux.SetAnimation(0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Changing color (doesn't work due to a bug, apparently).
            _colorBlock.normalColor = Color.white;
            _button.colors = _colorBlock;
            // Finding player and changing its icon.
            Player player = FindObjectOfType<Player>();
            player.ChangeIcon(0);
        }
    }

    private void SetupVariables()
    {
        _button = GetComponent<Button>();
        _digitalGreen = new Color(12, 224, 9);
        _colorBlock = _button.colors;
    }

}
