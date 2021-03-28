using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateList<T>
{
    //Dictionaryクラスのオブジェクト生成
    private Dictionary<StateTagList, IState<T>> statelist = new Dictionary<StateTagList, IState<T>>();

    public StateList()
    {

    }

    //この関数でStateリストの追加
    public void AddState(StateTagList _tag,IState<T> _state)
    {
        statelist.Add(_tag, _state);
    }

    //ここにタグを引数として入れればそのStateがかえってくる
    public IState<T> Getstate(StateTagList _tag)
    {
        return statelist[_tag];
    }

}
