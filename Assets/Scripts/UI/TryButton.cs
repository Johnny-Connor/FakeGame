using UnityEngine;

public class TryButton : MonoBehaviour
{

    [Header("Go references")]
    [SerializeField] private RealGameUI _realGameUI;
    [SerializeField] private Player _player;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            _player.ChangeIcon(1);
            if (Input.GetMouseButton(0))
            {
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

}