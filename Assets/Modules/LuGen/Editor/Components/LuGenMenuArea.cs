//------------------------------------------------------------
// 描述：Menu Area of Lu Gen
// 作者：Z.P.Y
// 时间：2024/12/03 09:46
//------------------------------------------------------------

using UnityEditor;
using UnityEngine.UIElements;

namespace Modules.LuGen.Editor.Components
{
    /// <summary>
    /// Menu Area of Lu Gen
    /// </summary>
    public class LuGenMenuArea
    {
        private VisualElement m_Container;

        public void CreateGUI(VisualElement parent)
        {
            // style sheet
            const string ussPath = "Assets/Modules/LuGen/Editor/Uss/LuGenMenuArea.uss";
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(ussPath);

            // container
            m_Container = new VisualElement();
            m_Container.styleSheets.Add(styleSheet);
            m_Container.AddToClassList("container");
            parent.Add(m_Container);
        }
    }
}