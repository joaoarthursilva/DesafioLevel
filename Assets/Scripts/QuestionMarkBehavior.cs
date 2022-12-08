using UnityEngine;

public class QuestionMarkBehavior : MonoBehaviour
{
    private bool _canGiveItem;
    [SerializeField] private GameObject coin;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController)) return;
        playerController.IncreseCoinAmountAndUpdateText();
        CreateCoin();
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    private void CreateCoin()
    {
        var position = transform.position;
        var a = Instantiate(coin, new Vector3(position.x, (position.y + .4f), position.z),
            Quaternion.identity);
        Destroy(a, .3f);
    }
}