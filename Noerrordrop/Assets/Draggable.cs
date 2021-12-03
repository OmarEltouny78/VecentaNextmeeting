using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private GameObject getTarget;
	private bool isMouseDragging;
	private Vector3 offsetValue;
	private Vector3 positionOfScreen;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            getTarget = ReturnClickedObject(out hitInfo);
            if (getTarget != null)
            {
                isMouseDragging = true;
                //Convert world position to screen position.
                positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
            }
        }
 
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;
        }
 
        if (isMouseDragging)
        {
            //track mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);
 
            //convert screen position to world position with offset changes.
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;
 
            //It will update target gameobject's current postion.
            getTarget.transform.position = currentPosition;
        }
 
    }
	GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
}
        return target;
    }
}
