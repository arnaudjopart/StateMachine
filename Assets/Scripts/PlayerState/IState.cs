using UnityEngine;
using System.Collections;

public interface IState {

    void UpdateState();
    void ToWalkState();
    void ToJumpState();
    void ToDuckState();
    void ToDiveState();
    void ToFallingState();
	
}
