using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("UI Variables")] [SerializeField]
    private TextMeshProUGUI coinAmountText;
    // private Slider healthSlider;
    // [SerializeField] private Slider abilitySlider;
    // [Header("Health Variables")] [SerializeField]
    // private int startingHealth = 10;
    // private float _currentHealth;

    [Header("Movement Variables")] private Rigidbody2D _rb;
    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private float speed = 10;

    [Header("Ground Collision Variables")] [SerializeField]
    private LayerMask groundLayer;

    private float _groundRaycastLength = .7f;

    [SerializeField] private Vector3 groundRaycastOffset;

    private int _coinAmount;

    // [Header("Shooting Variables")] [SerializeField]
    // private int ammoAmount = 30;
    // private int _currentAmmoAmount;
    // [SerializeField] private GameObject bullet;
    // [SerializeField] private GameObject abilityBullet;
    // [SerializeField] private Text ammoAmountText;
    //
    // [Header("Ability Variables")] [SerializeField]
    // private int chargeNeededForAbility;
    //
    // private float _currentChargeForAbility;
    private void Start()
    {
        _coinAmount = 0;
        coinAmountText.text = $"{_coinAmount}";
        // _currentChargeForAbility = 0;
        // _currentHealth = startingHealth;
        // _currentAmmoAmount = ammoAmount;
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void IncreseCoinAmountAndUpdateText()
    {
        _coinAmount++;
        coinAmountText.text = $"{_coinAmount}";
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     _currentAmmoAmount = ammoAmount;
        // }
        if (CanJump())
        {
            _rb.AddForce(new Vector2(0, jumpForce));
        }
        // if (CanUseAbility() )
        // {
        //     UseAbility();
        // }
        // ammoAmountText.text = $"{_currentAmmoAmount}";
        // if (CanShoot())
        // {
        //     Shoot();
        // }

        // abilitySlider.value = _currentChargeForAbility / chargeNeededForAbility;
        // healthSlider.value = _currentHealth / startingHealth;
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var rbVelocity = _rb.velocity;
        var velocity = new Vector2(horizontal * speed, rbVelocity.y);
        _rb.velocity = velocity;
    }

    private bool CanJump()
    {
        return Physics2D.Raycast(transform.position + groundRaycastOffset,
            Vector2.down,
            _groundRaycastLength,
            groundLayer) && Input.GetButtonDown("Jump");
    }

    // private bool CanUseAbility()
    // {
    //     var a = _currentChargeForAbility >= chargeNeededForAbility && Input.GetKeyDown(KeyCode.E);
    //     return a;
    // }

    // private void UseAbility()
    // {
    //     _currentChargeForAbility = 0;
    //     Instantiate(abilityBullet,transform.position, Quaternion.identity);
    // }
    // private bool CanShoot()
    // {
    //     return _currentAmmoAmount > 0 && Input.GetButtonDown("Fire1");
    // }
    // private void Shoot()
    // {
    //     _currentChargeForAbility++;
    //     _currentAmmoAmount--;
    //     Instantiate(bullet,transform.position, Quaternion.identity);
    // }
    // private void TakeDamage()
    // {
    //     _currentHealth--;
    // }
    //
    // private void OnCollisionEnter2D(Collision2D col)
    // {
    //     if (col.gameObject.layer != 6) return;
    //     TakeDamage();
    // }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Ground check
        var position = transform.position;
        Gizmos.DrawLine(position + groundRaycastOffset,
            position + groundRaycastOffset + Vector3.down * _groundRaycastLength);
    }
}