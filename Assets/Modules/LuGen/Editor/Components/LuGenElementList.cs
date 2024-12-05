//------------------------------------------------------------
// 描述：List View of Gen Elements
// 作者：Z.P.Y
// 时间：2024/11/30 09:56
//------------------------------------------------------------

using System.Collections.Generic;
using Modules.LuGen.Editor.Define;
using PZ.UiElements;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Modules.LuGen.Editor.Components
{
    /// <summary>
    /// List View of Gen Elements
    /// </summary>
    public class LuGenElementList
    {
        private VisualElement m_Container;

        private ListView m_ListView;

        private readonly List<string> m_List = new List<string>();

        public void CreateGUI(VisualElement parent)
        {
            for (var i = 0; i < 50; i++)
            {
                m_List.Add(i.ToString());
            }

            // style sheet
            const string ussPath = "Assets/Modules/LuGen/Editor/Uss/LuGenElementList.uss";
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(ussPath);

            // container
            m_Container = new VisualElement();
            m_Container.styleSheets.Add(styleSheet);
            m_Container.AddToClassList("container");
            parent.Add(m_Container);

            var toolbar = new Toolbar();
            var searchField = new ToolbarSearchField
            {
                style =
                {
                    flexGrow = 1,
                }
            };
            toolbar.Add(searchField);
            m_Container.Add(toolbar);

            m_ListView = new ListView(m_List, 36, MakeItem, BindItem);
            m_ListView.showBorder = true;
            m_Container.Add(m_ListView);

            var voxelFilter = new EnumField("Voxel Filter", EVoxelFilter.All);
            m_Container.Add(voxelFilter);
        }

        private void BindItem(VisualElement element, int index)
        {
            var itemIdLabel = element.Q<Label>("item-id");
            itemIdLabel.text = (index + 999).ToString();

            var itemNameLabel = element.Q<Label>("item-name");
            itemNameLabel.text = m_List[index];
        }

        private static VisualElement MakeItem()
        {
            var item = new VisualElement();
            item.AddToClassList("list-view-item");

            // item id
            var itemIdLabel = new Label()
            {
                name = "item-id",
            };
            itemIdLabel.AddToClassList("list-view-item-id");
            item.Add(itemIdLabel);

            // item name
            var itemNameLabel = new Label
            {
                name = "item-name",
            };
            itemNameLabel.AddToClassList("list-view-item-name");
            item.Add(itemNameLabel);

            var itemStatus = new Label()
            {
                name = "item-status",
            };
            itemStatus.AddToClassList("list-view-item-status");
            item.Add(itemStatus);

            var img1 = new Image()
            {
                image = EditorGUIUtility.IconContent("Transform Icon").image,
            };
            img1.AddToClassList("list-view-item-status-img");
            itemStatus.Add(img1);

            var img2 = new Image()
            {
                image = EditorGUIUtility.IconContent("MeshCollider Icon").image,
            };
            img2.AddToClassList("list-view-item-status-img");
            itemStatus.Add(img2);

            var img3 = new Image()
            {
                image = EditorGUIUtility.IconContent("d_winbtn_mac_max").image,
            };
            img3.AddToClassList("list-view-item-status-img");
            itemStatus.Add(img3);

            return item;
        }
    }
}