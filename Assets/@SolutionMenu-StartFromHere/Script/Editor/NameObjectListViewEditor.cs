#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace SolutionMenu {

    [CustomEditor(typeof(NameObjectListView))]
    public class NameObjectListViewEditor : Editor {

        #region 內部變數區

        //本體
        private NameObjectListView self;

        #endregion
        #region OnInspectorGUI

        public override void OnInspectorGUI() {

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("請點兩下你要檢視的目錄物件來進到該物件 ▼");
            GUILayout.EndHorizontal();
            EditorGUILayout.Space(10);

            self = target as NameObjectListView;
            SerializedProperty propertyEnableEdit = serializedObject.FindProperty(nameof(self.enableEdit));
            bool enableEdit = propertyEnableEdit.boolValue;
            SerializedProperty propertyList = serializedObject.FindProperty(nameof(self.list));
            SerializedProperty propertyItem;

            if (self.list != null) {
                if (enableEdit) {
                    base.OnInspectorGUI();
                    if (GUILayout.Button("結束編輯", GUILayout.Width(100))) {
                        propertyEnableEdit.boolValue = false;
                    }
                } else {
                    for (int i = 0; i < self.list.Count; i++) {
                        GUILayout.BeginHorizontal();
                        propertyItem = propertyList.GetArrayElementAtIndex(i).FindPropertyRelative(nameof(NameObjectPair.name));
                        EditorGUILayout.PrefixLabel(propertyItem.stringValue);
                        propertyItem = propertyList.GetArrayElementAtIndex(i).FindPropertyRelative(nameof(NameObjectPair.value));
                        EditorGUILayout.ObjectField(propertyItem.objectReferenceValue, typeof(UnityEngine.Object), true);
                        GUILayout.EndHorizontal();
                    }

                    EditorGUILayout.Space(20);

                    if (GUILayout.Button("編輯列表", GUILayout.Width(100))) {
                        propertyEnableEdit.boolValue = true;
                    }
                }
            }

            serializedObject.ApplyModifiedProperties();

        }

        #endregion

    }
}

#endif