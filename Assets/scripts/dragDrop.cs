using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragDrop : MonoBehaviour
{
    Vector3 offset;
    Vector3 initialPosition; // To store the initial position
    public string destinationTag = "DropArea";

    private void OnMouseDown()
    {
        initialPosition = transform.position; // Store the initial position
        offset = transform.position - MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
    }
    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }
    //private void OnMouseUp()
    //{
    //    var rayOrigin = Camera.main.transform.position;
    //    var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
    //    RaycastHit hitInfo;
    //    if(Physics.Raycast(rayOrigin,rayDirection, out hitInfo))
    //    {

    //        if (hitInfo.transform.tag == destinationTag)
    //        {
    //            transform.position = hitInfo.transform.position;

    //        }


    //    }
    //    transform.GetComponent <Collider>().enabled = true;
    //}
    private void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            if (hitInfo.transform.tag == destinationTag)
            {
                Transform dropArea = hitInfo.transform;

                // Check if drop area already has a child
                if (dropArea.childCount > 0)
                {
                    Transform existingItem = dropArea.GetChild(0);

                    // Swap positions
                    existingItem.position = initialPosition;
                    existingItem.SetParent(null); // Remove parent of the existing item
                }

                // Place the current item in the drop area
                transform.position = dropArea.position;
                transform.SetParent(dropArea); // Make this item a child of the drop area
            }
            else
            {
                // If not dropped on the correct area, reset position
                transform.position = initialPosition;
            }
        }
        else
        {
            // If raycast doesn't hit anything, reset position
            transform.position = initialPosition;
        }

        transform.GetComponent<Collider>().enabled = true;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);

    }
}