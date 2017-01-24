using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

class DragTransform : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    public GameObject Editor;
    Vector3 startPosition;
    Transform startParent;

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        itemBeingDragged.transform.SetParent(Editor.transform);
        itemBeingDragged.transform.localScale = new Vector3(1, 1, 0);
    }

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        /*if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }*/
    }
    #endregion
}

