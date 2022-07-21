using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(Collider))]
//������� ������� ����� ���������� � ����������, � ����� ��� �������������� ��������� ����������.
public class InspectableObject :  LeanLocalizedBehaviour
{

    private void Start()
    {
        var outline = GetComponent<Outline>();
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 10;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.enabled = false;

        int LayerIgnoreRaycast = LayerMask.NameToLayer("Inspectable");
        gameObject.layer = LayerIgnoreRaycast;
    }

    [SerializeField]
    private string _message;


    public string Message
    {
        get { return _message; }
        private set { _message = value; }
    }


    public void DoSmth()
    {

    }

    public override void UpdateTranslation(LeanTranslation translation)
    {

        // Use translation?
        if (translation != null && translation.Data is string)
        {
            Message = LeanTranslation.FormatText((string)translation.Data);
        }
    }
}
