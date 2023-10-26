using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class Controller : MonoBehaviour
{
    #region Core
    public abstract void Initialize(GameplayData data);
    #endregion
}
