using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
	 public Transform target;
		IAstarAI ai;
	//extra
	float x;
    float y;
    public float speed;
    public float timer;
    private float dur = 5;
     private Vector3 targetPos;
	 public bool move;
	 //private LDMovement sc;
	 
		
   void Start()
    {//
          InvokeRepeating("RanPos",0,3); //extra
		  move = true;
		  // sc = GetComponent<LDMovement>();
    }
		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {
			
			if (target != null && ai != null) ai.destination = target.position;
		//extra
		float step = speed * Time.deltaTime;
        target.position = Vector3.MoveTowards(transform.position, targetPos, step);  //
		
		}
		///////////extra
		void RanPos(){  
		// if(move){	
        x =  Random.Range(-48f, 48f);   //-2,29
        y = Random.Range(-59f, 23f);   //-12.8,-4
        targetPos = new Vector2(x, y);
		//}
    	}
      	void stopPos(){
        CancelInvoke ("RanPos");
    	}
	}
}
