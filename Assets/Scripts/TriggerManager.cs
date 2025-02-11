using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public GameManager _gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TargetObject")
            _gameManager.TargetFalling();
        else if (collision.tag == "BallObject")
            _gameManager.BallFalling();
    }
}
