using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    [Header("Go references")]
    [SerializeField] private FakeGameUI _fakeGameUI;
    [SerializeField] private Player _player;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            _player.ChangeIcon(1);
            if (Input.GetMouseButton(0))
            {
                _fakeGameUI.SetFakeTextAnimation(1);
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