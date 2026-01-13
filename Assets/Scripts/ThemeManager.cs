using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    public static ThemeManager Instance;

    [Header("References")]
    public Camera mainCamera;
    public Material stackMaterial;

    [Header("Settings")]
    public bool useComplementaryColors = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        ChangeTheme();
    }

    public void ChangeTheme()
    {
        // 1. Chọn một tông màu chủ đạo ngẫu nhiên (0 -> 1)
        float baseHue = Random.value; 

        // 2. Tạo màu Background:
        // - Saturation thấp (0.2 - 0.3) để màu nền pastel, dịu nhẹ
        // - Value cao (0.9 - 1.0) để nền sáng
        Color bgColor = Color.HSVToRGB(baseHue, 0.25f, 0.95f);

        // 3. Tạo màu Material:
        float matHue = baseHue;

        // (Tùy chọn) Nếu muốn màu tương phản
        if (useComplementaryColors)
        {
            matHue = (baseHue + 0.5f) % 1f; // Cộng 0.5 để lấy màu đối diện
        }

        // - Saturation cao (0.7 - 0.9) để khối trụ đậm đà, nổi bật
        // - Value vừa phải (0.7 - 0.8) để không bị chói
        Color matColor = Color.HSVToRGB(matHue, 0.8f, 0.75f);

        // 4. Áp dụng màu
        if (mainCamera != null)
        {
            mainCamera.backgroundColor = bgColor;
        }

        if (stackMaterial != null)
        {
            stackMaterial.color = matColor;
        }
    }
}