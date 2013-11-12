using UnityEngine;
using System.Collections;
 
public class ForwardAllMouseEvents : MonoBehaviour
{
    public GameObject target;
 
    void OnMouseEnter()
    {
        target.SendMessage("OnMouseEnter", null, SendMessageOptions.DontRequireReceiver);
    }
 
    void OnMouseOver()
    {
        target.SendMessage("OnMouseOver", null, SendMessageOptions.DontRequireReceiver);
    }
 
    void OnMouseExit()
    {
        target.SendMessage("OnMouseExit", null, SendMessageOptions.DontRequireReceiver);
    }
 
    void OnMouseDown()
    {
        target.SendMessage("OnMouseDown", null, SendMessageOptions.DontRequireReceiver);
    }
 
    void OnMouseUp()
    {
        target.SendMessage("OnMouseUp", null, SendMessageOptions.DontRequireReceiver);
    }
 
    void OnMouseDrag()
    {
        target.SendMessage("OnMouseDrag", null, SendMessageOptions.DontRequireReceiver);
    }
}