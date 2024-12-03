//------------------------------------------------------------
// 描述：Editor Window of Lu Gen
// 作者：Z.P.Y
// 时间：2024/11/29 06:20
//------------------------------------------------------------

using UnityEditor;
using UnityEngine.UIElements;
using System.Collections.Generic;
using Modules.LuGen.Editor.Components;
using UnityEngine;

namespace Modules.LuGen.Editor
{
    /// <summary>
    /// Editor Window of Lu Gen
    /// </summary>
    public class LuGenEditorWindow : EditorWindow
    {
        private TwoPaneSplitView m_SplitView;

        private LuGenElementList m_ElementList;

        private LuGenOverview m_Overview;

        private LuGenMenuArea m_MenuArea;

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

        private void CreateGUI()
        {
            // style sheet
            const string sharedUssPath = "Assets/Modules/LuGen/Editor/Uss/LuGenStyle.uss";
            var sharedStyleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(sharedUssPath);
            const string ussPath = "Assets/Modules/LuGen/Editor/Uss/LuGenEditorWindow.uss";
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(ussPath);

            // root
            var root = rootVisualElement;
            root.styleSheets.Add(sharedStyleSheet);
            root.styleSheets.Add(styleSheet);
            root.AddToClassList("root");

            // split view
            const int fixedPaneIndex = 0;
            const float fixedPaneInitialWidth = 328f;
            const TwoPaneSplitViewOrientation orientation = TwoPaneSplitViewOrientation.Horizontal;
            m_SplitView = new TwoPaneSplitView(fixedPaneIndex, fixedPaneInitialWidth, orientation);
            root.Add(m_SplitView);

            // list view
            m_ElementList = new LuGenElementList();
            m_ElementList.CreateGUI(m_SplitView);

            // right
            var rightView = new VisualElement();
            root.Add(rightView);
            m_SplitView.Add(rightView);

            // overview
            m_Overview = new LuGenOverview();
            m_Overview.CreateGUI(rightView);

            // menu area
            m_MenuArea = new LuGenMenuArea();
            m_MenuArea.CreateGUI(rightView);
        }
    }
}