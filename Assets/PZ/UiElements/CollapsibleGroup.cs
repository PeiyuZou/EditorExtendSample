//------------------------------------------------------------
// 描述：a collapsible group
// 作者：Z.P.Y
// 时间：2024/12/03 05:19
//------------------------------------------------------------

using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace PZ.UiElements
{
    /// <summary>
    /// a collapsible group
    /// </summary>
    public class CollapsibleGroup : VisualElement
    {
        private VisualElement m_Header;

        private VisualElement m_Content;

        private Texture m_ExpandedIcon;

        private Texture m_CollapsedIcon;

        private Image m_ArrowImg;

        private bool m_Expanded;

        public CollapsibleGroup(string title)
        {
            const string ussPath = "Assets/PZ/UiElements/Uss/CollapsibleGroup.uss";
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(ussPath);
            styleSheets.Add(styleSheet);
            AddToClassList("collapsible-group");

            m_Header = new VisualElement();
            m_Header.AddToClassList("header");
            base.Add(m_Header);
            m_Header.RegisterCallback<ClickEvent>(OnHeaderClick);

            m_ExpandedIcon = EditorGUIUtility.IconContent("Toolbar Minus").image;
            m_CollapsedIcon = EditorGUIUtility.IconContent("Toolbar Plus").image;
            m_ArrowImg = new Image();
            m_ArrowImg.AddToClassList("arrow");
            m_Header.Add(m_ArrowImg);

            var headTitle = new Label(title);
            m_Header.Add(headTitle);

            m_Content = new VisualElement();
            m_Content.AddToClassList("content");
            base.Add(m_Content);

            UpdateExpanded();
        }

        private void OnHeaderClick(ClickEvent evt)
        {
            m_Expanded = !m_Expanded;
            UpdateExpanded();
        }

        private void UpdateExpanded()
        {
            m_ArrowImg.image = m_Expanded ? m_ExpandedIcon : m_CollapsedIcon;
            m_Content.style.display = m_Expanded ? DisplayStyle.Flex : DisplayStyle.None;
        }

        public new void Add(VisualElement visualElement)
        {
            m_Content.Add(visualElement);
        }
    }
}