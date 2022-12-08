
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController)) return;

        playerController.IncreseCoinAmountAndUpdateText();
        gameObject.SetActive(false);
    }
}