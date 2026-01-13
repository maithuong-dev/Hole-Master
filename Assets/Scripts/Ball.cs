using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public bool isSmashing;
    [SerializeField] private float smashForce = -50f;     // lực rơi khi smash
    [SerializeField] private float bounceForce = 15f;     // lực nảy khi không smash
    [SerializeField] private AudioSource bounceSource;
    [SerializeField] private AudioSource winSource;
    public TextMeshProUGUI TapToPlayText;
    public bool isWin = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isSmashing = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isSmashing = false;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject(
                PointerInputModule.kMouseLeftId))
            {
                return;
            }

            isSmashing = true;
            rb.linearVelocity = new Vector3(0, -100f * Time.fixedDeltaTime * 7, 0);

            if (TapToPlayText != null && TapToPlayText.gameObject.activeSelf)
            {
                TapToPlayText.gameObject.SetActive(false);
            }
        }

        if (rb.linearVelocity.y > 5)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 5, rb.linearVelocity.z);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (!isSmashing)
        {
            rb.linearVelocity = Vector3.up * (bounceForce * 0.6f);
            if (collision.gameObject.CompareTag("Done") && isWin == false)
            {
                Win();
            }
        }
    }

    public void Bounce()
    {
        rb.linearVelocity = Vector3.up * (bounceForce * 0.6f);
        SoundManager.Instance.PlaySFX(bounceSource);
    }

    public void Win()
    {
        isWin = true;
        SoundManager.Instance.PlaySFX(winSource);
        UiManager.Instance.ShowWinPanel();
        LevelManager.Instance.IncreaseLevel();
    }

    public void Lose()
    {
        UiManager.Instance.ShowLosePanel();
    }
}
