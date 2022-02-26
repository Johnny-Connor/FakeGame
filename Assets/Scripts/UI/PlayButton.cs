using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    private Animation _anim;
    private bool _animationPlayed;
    private Button _button;

    [Header("Go references")]
    [SerializeField] private FakeGameUI _fakeGameUI;
    [SerializeField] private Player _player;

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
            _player.ChangeIcon(1);
            if (Input.GetMouseButton(0))
            {
                _fakeGameUI.SetAnimation(1);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            _player.ChangeIcon(0);
        }
    }

}