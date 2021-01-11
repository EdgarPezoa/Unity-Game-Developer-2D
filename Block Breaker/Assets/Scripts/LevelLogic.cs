using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    [SerializeField] private int breakableBlocks;

    private SceneLoader sceneLoader;

    private void Start() {
        Cursor.visible = false;
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBrekableBlocks(){
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0){
            sceneLoader.LoadNextScene();
        }
    }

}
