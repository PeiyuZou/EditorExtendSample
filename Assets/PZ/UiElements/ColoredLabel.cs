//------------------------------------------------------------
// 描述：colored label extend from Label
// 作者：Z.P.Y
// 时间：2024/12/03 04:05
//------------------------------------------------------------

using UnityEditor;
using UnityEngine.UIElements;

namespace PZ.UiElements
{
    /// <summary>
    /// colored label extend from Label
    /// </summary>
    public class ColoredLabel : Label
    {
        public ColoredLabel(string text) : base(text)
        {
            const string ussPath = "Assets/PZ/UiElements/Uss/ColoredLabel.uss";
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(ussPath);
            styleSheets.Add(styleSheet);
            AddToClassList("colored-label");
        }
    }
}