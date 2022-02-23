using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    private Button _button;
    private Color _digitalGreen;
    private ColorBlock _colorBlock;

    private void Start()
    {
        _button = GetComponent<Button>();
        _digitalGreen = new Color(12,224,9);
        _colorBlock = _button.colors;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("enter");
        _colorBlock.normalColor = _digitalGreen;
        _button.colors = _colorBlock;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("exit");
        _colorBlock.normalColor = Color.white;
        _button.colors = _colorBlock;
    }

}
