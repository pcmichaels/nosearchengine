import { Action } from 'redux';
import { ThunkAction } from 'redux-thunk';
import { GET_USER_DATA } from './Types';
import { IStore } from './Store';
import { IUserData } from '../components/Interfaces/IUserData';

export const GetUserData = (): ThunkAction<void, IStore, unknown, Action<string>> => async dispatch => {
    console.log('Calling GetUserData');

    const response = await fetch('user/currentUser/');
    const jsondata: IUserData = await response.json();    

    return dispatch({
      type: GET_USER_DATA,
      payload: jsondata  
    });
}
