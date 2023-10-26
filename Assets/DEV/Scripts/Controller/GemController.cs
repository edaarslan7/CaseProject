using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : Controller
{
    #region Fields
    [SerializeField] ObjectPool gemPool;
    #endregion
    #region Core
    public override void Initialize(GameplayData data)
    {
        Gem gem = gemPool.GetItem() as Gem;
        gem.SetActiveWithPosition(new Vector3(7.96f, 0, 4.39f));
    }
    #endregion
}
