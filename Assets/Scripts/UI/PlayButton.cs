using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    private Animation _anim;
    private bool _animationPlayed;
    private Button _button;

    private void Awake()
    {
        _anim = GetComponent<Animation>();
        _button = GetComponent<Button>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && _animationPlayed == false)
        {
            _anim.Play("FadeIn");
            _animationPlayed = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player player = FindObjectOfType<Player>();
            player.ChangeIcon(1);
            if (Input.GetMouseButton(0))
            {
                FakeGameUI aux = FindObjectOfType<FakeGameUI>();
                aux.SetAnimation(1);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player player = FindObjectOfType<Player>();
            player.ChangeIcon(0);
        }
    }

}