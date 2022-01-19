using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public BaseInteractable[] interactableItems;
    public int currentInteractableItem = 0;
    
    public Color unactive, active;

     // Indicator icon
    public Image img;
    public Graphic imgColor;
    // The target (location, enemy, etc..)
    public Transform target;
    // UI Text to display the distance
    public Text meter;
    // To adjust the position of the icon
    public Vector3 offset;
    public Vector3 targetPosition;

    public void Start() {
        currentInteractableItem = 0;
        EnableInteractableObject();
        // imgColor = img.GetComponent<Graphic>();
        img.color = unactive;
    }

    void MoveToNextInteractableObject() {
        if( currentInteractableItem + 1 > interactableItems.Length ){
            return;
        }
        if( currentInteractableItem + 1 >= interactableItems.Length ){
            return;
        }
        interactableItems[currentInteractableItem].dialogueWindow.Disable();
        currentInteractableItem++;
        EnableInteractableObject();
    }

    void EnableInteractableObject() {
        if( interactableItems != null ){
            interactableItems[currentInteractableItem].SetPrerequisitesCompleted();
            SetDiamondPosition();
        }
    }

    void SetDiamondPosition(){
        Vector3 pos = interactableItems[currentInteractableItem].GetCenter();
        pos.y += 2.25f;
        targetPosition = pos;
    }

    public void Update() {
        if( interactableItems != null ){
            if( currentInteractableItem < interactableItems.Length ){
                if( interactableItems[currentInteractableItem].isDialogueFinished ){
                    MoveToNextInteractableObject();
                }
                if( interactableItems[currentInteractableItem].isInteractable() ){
                    if( img != null ){
                        img.color = active;
                    }
                }else {
                    if( img != null ){
                        img.color = unactive;
                    }
                }
            }
        }
        
        // Giving limits to the icon so it sticks on the screen
        // Below calculations witht the assumption that the icon anchor point is in the middle
        // Minimum X position: half of the icon width
        float minX = img.GetPixelAdjustedRect().width / 2;
        // Maximum X position: screen width - half of the icon width
        float maxX = Screen.width - minX;

        // Minimum Y position: half of the height
        float minY = img.GetPixelAdjustedRect().height / 2;
        // Maximum Y position: screen height - half of the icon height
        float maxY = Screen.height - minY;

        // Temporary variable to store the converted position from 3D world point to 2D screen point
        Vector2 pos = Camera.main.WorldToScreenPoint(targetPosition + offset);

        // Limit the X and Y positions
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // Update the marker's position
        img.transform.position = pos;
        // Change the meter text to the distance with the meter unit 'm'
        // meter.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";

    }

}