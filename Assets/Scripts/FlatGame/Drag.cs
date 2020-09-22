using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector2 screenPoint;
 private Vector2 offset;

 private bool selected;

 void Update(){
     if(selected == true){
         Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         transform.position = new Vector2(cursorPos.x, cursorPos.y);
     }

     if(Input.GetMouseButtonUp(0)){
         selected = false;
     }
 }
 
 void OnMouseDown()
 {

    //  screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
 
    //  offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
 }
 
 void OnMouseDrag()
 {
//      Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
 
//  Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) ;
//  transform.position = curPosition;
 
 }

 void OnMouseOver(){
     Debug.Log("over");
     if(Input.GetMouseButton(0)){
         selected = true;
 }
}
}
