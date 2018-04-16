using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Left, Right, Unfixed};

public interface IsceneController
{
    void LoadResources();
}

public interface diskAction
{
    void Boomshakalaka(GameObject disk);
    void Drop(GameObject disk);
}