using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class SafeArea : MonoBehaviour
{
    void Start()
    {
        var visualRoot = GetComponent<UIDocument>().rootVisualElement;

        // 取得安全區域（以像素計）
        Rect safeArea = Screen.safeArea;

        // 計算相對比例
        float topPadding = safeArea.yMax / Screen.height;
        float bottomPadding = safeArea.yMin / Screen.height;

        // 可以用 % 高度來處理 Padding
        visualRoot.style.paddingTop = new Length(topPadding * 100f, LengthUnit.Percent);
        visualRoot.style.paddingBottom = new Length((1f - bottomPadding) * 100f, LengthUnit.Percent);
    }
}
