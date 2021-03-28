using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    private IState<T> state = null;

    private StateList<T> stateList = new StateList<T>();

    public StateList<T> GetStateList() { return stateList; }

    public IState<T> GetState() { return state; }

    StateTagList nowState = StateTagList.none;

    //Stateを変更する際に通す関数
    //自動でEnterとExitに通るようになっている
    public void ChangeState(StateTagList _tag,T _t)
    {
        nowState = _tag;
        IState<T> _state = stateList.Getstate(_tag);

        state?.Exit(_t);
        state = _state;
        state?.Enter(_t);
    }

    //StateMachineを持たせているscriptのUpdateでこの関数を回してやる
    //引数に自分のGameObjectを持たせてやる
    public bool Update(T _t)
    {
        if(state != null)
        {
            StateTagList _tag = state.Execute(_t);
            if (_tag == StateTagList.delete) { return false; }
            if (_tag != StateTagList.none)  
            {
                ChangeState(_tag, _t);
            }
        }
        return true;
    }

    public StateTagList GetNowState()
    {
        return nowState;
    }

}
