using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove  {

    /*
     * This method is called by the Card that holds
     * The GameObject. Must start the Attack
     * 
     */
    void DoMove();

    /*
     * A Method that is not called, by anyone. But is there as a reminder to
     * clean up the MoveCanvas, and call the method MoveIsDone() on the Turnmanager!
     * The Move must also "clean up itself" so its ready to be called again!
     * There MUST!! Be a reference to the Turnmanager for anyone how implements it!
     * It should NOT set the canvas to inactive, that is the responsable for the Turnmanager.
     * But It should inactive any Gameobject it actived it self!
     */
    void CleanUp();

}
