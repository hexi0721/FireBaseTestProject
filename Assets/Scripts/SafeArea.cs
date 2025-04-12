using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class SafeArea : MonoBehaviour
{
    void Start()
    {
        var visualRoot = GetComponent<UIDocument>().rootVisualElement;

        // ���o�w���ϰ�]�H�����p�^
        Rect safeArea = Screen.safeArea;

        // �p��۹���
        float topPadding = safeArea.yMax / Screen.height;
        float bottomPadding = safeArea.yMin / Screen.height;

        // �i�H�� % ���רӳB�z Padding
        visualRoot.style.paddingTop = new Length(topPadding * 100f, LengthUnit.Percent);
        visualRoot.style.paddingBottom = new Length((1f - bottomPadding) * 100f, LengthUnit.Percent);
    }
}
