using UnityEngine;

public class PlayButton : MonoBehaviour
{

    [Header("Aux")]
    private bool _hasButtonBeenPressed;
    private float _buttonDelayTotalTime = 1.5f;
    private float _buttonDelayTimer;

    [Header("Go references")]
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private FakeGameUI _fakeGameUI;
    [SerializeField] private Player _player;

    private void Update()
    {
        ButtonDelayCheck();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && _hasButtonBeenPressed == false)
        {
            _player.ChangeIcon(1);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetMouseButton(0) && _hasButtonBeenPressed == false)
            {
                _audioManager.Play("GameTheme");
                _audioManager.Play("ButtonPress");
                _fakeGameUI.SetFakeTextAnimation(1);
                _hasButtonBeenPressed = true;
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

    private void ButtonDelayCheck()
    {
        if (_hasButtonBeenPressed == true)
        {
            _buttonDelayTimer += Time.deltaTime;
            if (_buttonDelayTimer > _buttonDelayTotalTime)
            {
                _hasButtonBeenPressed = false;
                _buttonDelayTimer -= _buttonDelayTotalTime;
            }
        }
    }

}