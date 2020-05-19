import { InitialState } from './Store';
import { ActionTypes, GET_USER_DATA } from './Actions';

export function reducer(state = InitialState, action: ActionTypes) {  
    console.log (action);
    switch (action.type) {
      case GET_USER_DATA:
        return {
            ...state,
            userRating: state.userRating + parseInt(action.payload.message)
        }

        
        
      default:
        return state;
  
    }           
  }
  