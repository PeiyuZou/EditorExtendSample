//------------------------------------------------------------
// 描述：Menu of Lu Gen
// 作者：Z.P.Y
// 时间：2024/11/30 09:42
//------------------------------------------------------------

using UnityEditor;

namespace Modules.LuGen.Editor
{
    /// <summary>
    /// Menu of Lu Gen
    /// </summary>
    public class LuGenMenu : UnityEditor.Editor
    {
        [MenuItem("LuGen/LuGenEditorWindow %#l")]
        public static void OpenLuGenEditorWindow()
        {
            var editorWindow = EditorWindow.GetWindow<LuGenEditorWindow>();
            editorWindow.Show();
        }
    }
}