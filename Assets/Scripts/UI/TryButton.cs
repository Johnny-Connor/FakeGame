using UnityEngine;

public class TryButton : MonoBehaviour
{
    [Header("Aux")]
    private bool _hasButtonBeenPressed;
    private float _buttonDelayTotalTime = 1.5f;
    private float _buttonDelayTimer;

    [Header("Go references")]
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private RealGameUI _realGameUI;
    [SerializeField] private Player _player;

    private void Update()
    {
        ButtonDelayCheck();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
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
                _hasButtonBeenPressed = true;
                _audioManager.Play("GameTheme");
                _audioManager.Play("ButtonPress");
                _player.Revive();
                _realGameUI.SetGameOverPhase(1);
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