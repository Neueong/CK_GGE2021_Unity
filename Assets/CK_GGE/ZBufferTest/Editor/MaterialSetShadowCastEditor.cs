using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MaterialSetShadowCast))] [CanEditMultipleObjects]
public class MaterialSetShadowCastEditor : Editor
{
    private Material m_mat;

    private void OnEnable()
    {
        MaterialSetShadowCast mssc = target as MaterialSetShadowCast;
        MeshRenderer mr = mssc.GetComponent<MeshRenderer>();
        if (mr != null)
        {
            m_mat = mr.sharedMaterial;
        }
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();
        if (m_mat != null)
        {
            if (GUILayout.Button("Enable Cast Shadow"))
            {
                m_mat.SetShaderPassEnabled("ShadowCaster", true);
            }
            if (GUILayout.Button("Disable Cast Shadow"))
            {
                m_mat.SetShaderPassEnabled("ShadowCaster", false);
            }
        }
        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
}
