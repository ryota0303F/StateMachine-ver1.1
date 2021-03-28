using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState<T>
{
    //始めに呼ばれる関数
    StateTagList Enter(T t);
    //フレーム呼ばれる関数
    StateTagList Execute(T t);
    //消去時に呼ばれる関数
    StateTagList Exit(T t);
}
