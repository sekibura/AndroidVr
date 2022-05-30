using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    //public bool IsMultiple { get; }
    public bool IsInteractable { get; }

    public void OnInteract();
}
