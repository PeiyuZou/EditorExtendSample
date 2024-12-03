//------------------------------------------------------------
// 描述：Inspector of Lu Gen
// 作者：Z.P.Y
// 时间：2024/11/30 10:05
//------------------------------------------------------------

using System.Collections.Generic;
using PZ.UiElements;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Modules.LuGen.Editor.Components
{
    /// <summary>
    /// Inspector of Lu Gen
    /// </summary>
    public class LuGenOverview
    {
        private VisualElement m_Container;

        public void CreateGUI(VisualElement parent)
        {
            // style sheet
            const string ussPath = "Assets/Modules/LuGen/Editor/Uss/LuGenOverview.uss";
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(ussPath);

            // container
            m_Container = new VisualElement();
            m_Container.styleSheets.Add(styleSheet);
            m_Container.AddToClassList("container");
            parent.Add(m_Container);

            // toolbar test
            var toolbar = new Toolbar();
            toolbar.style.justifyContent = Justify.FlexEnd;
            // 1.toolbar button
            var button = new ToolbarButton(() => { Debug.Log("Button clicked"); }) { text = "Click me" };
            toolbar.Add(button);
            // 2.toolbar spacer
            var toolbarSpacer = new ToolbarSpacer();
            toolbar.Add(toolbarSpacer);
            // 3.toolbar toggle
            toolbar.Add(new ToolbarToggle() { text = "Toggle me" });
            // 4.toolbar menu
            var toolbarMenu = new ToolbarMenu() { text = "Menu Text" };
            toolbarMenu.menu.AppendAction("Menu item 1", (a) => { Debug.Log("Menu item 1 clicked"); });
            toolbarMenu.menu.AppendAction("Menu item 2", (a) => { Debug.Log("Menu item 2 clicked"); });
            toolbarMenu.menu.AppendAction("Menu item 3", (a) => { Debug.Log("Menu item 3 clicked"); });
            toolbar.Add(toolbarMenu);
            // 5.toolbar search
            var toolbarSearchField = new ToolbarSearchField();
            toolbarSearchField.value = "Search me";
            toolbarSearchField.RegisterValueChangedCallback(evt => Debug.Log("New search value: " + evt.newValue));
            toolbar.Add(toolbarSearchField);

            m_Container.Add(toolbar);

            // test
            var coloredLabel = new ColoredLabel("LuGen Overview");
            m_Container.Add(coloredLabel);

            var radioButtonGroup = new RadioButtonGroup("Options", new List<string> { "Option 1", "Option 2", "Option 3", "Option 4" });
            radioButtonGroup.RegisterValueChangedCallback(evt => Debug.Log(evt.newValue));
            m_Container.Add(radioButtonGroup);

            var maskField = new MaskField();
            maskField.choices = new List<string> { "1", "2", "3" };
            maskField.value = 2;
            maskField.label = "Mask";
            m_Container.Add(maskField);

            var imguiContainer = new IMGUIContainer(OnGUIHandler);
            m_Container.Add(imguiContainer);

            var cSharpFoldout = new Foldout {text = "Elements"};
            cSharpFoldout.Add(new Label("Indented Label"));
            cSharpFoldout.Add(new Slider("Indented Slider", 0, 100));
            m_Container.Add(cSharpFoldout);

            var collapsibleGroup1 = new CollapsibleGroup("Collapsible Group 1");
            var contentField1 = new Vector3Field("Field 1");
            collapsibleGroup1.Add(contentField1);
            m_Container.Add(collapsibleGroup1);

            var collapsibleGroup2 = new CollapsibleGroup("Collapsible Group 2");
            var contentField2 = new Slider("Field 2");
            collapsibleGroup2.Add(contentField2);
            m_Container.Add(collapsibleGroup2);

            var collapsibleGroup3 = new CollapsibleGroup("Collapsible Group 3");
            var contentField3 = new LongField("Field 3");
            collapsibleGroup3.Add(contentField3);
            m_Container.Add(collapsibleGroup3);
        }

        private void OnGUIHandler()
        {
            GUILayout.Toolbar(0, new[]
            {
                "显示全部",
                "仅有体素",
                "仅无体素",
            }, GUILayout.Height(24));
        }
    }
}