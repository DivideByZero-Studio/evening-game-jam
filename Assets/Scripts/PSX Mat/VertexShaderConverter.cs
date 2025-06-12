using System;
using UnityEngine;

public class VertexShaderConverter : MonoBehaviour
{
    [SerializeField] private Color _color = Color.white;
    [SerializeField] private Texture2D _texture;
    [SerializeField, Range(0, 1)] private float _metallic;
    [SerializeField, Range(0, 1)] private float _smoothness;

    private Material _material;
    
    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        _material.SetColor("_Color", _color);
        _material.SetTexture("_Base_Texture", _texture);
        _material.SetFloat("_Metallic", _metallic);
        _material.SetFloat("_Smoothness", _smoothness);
    }
}
