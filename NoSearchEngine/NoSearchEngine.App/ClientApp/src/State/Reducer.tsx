import { InitialState, IStore } from './Store';
import { ActionTypes, GET_USER_DATA, GetUserDataActionType } from './Types';

export function reducer(state: IStore = InitialState, action: GetUserDataActionType) : IStore {  
    console.log (action);
    switch (action.type) {
      case GET_USER_DATA:

        console.log('GET_USER_DATA Reducer; user: ' + action.payload);

        return {
          ...state,
          userRating: action.payload.userRating
        }  

      default:
        return state;
  
    }           
}
