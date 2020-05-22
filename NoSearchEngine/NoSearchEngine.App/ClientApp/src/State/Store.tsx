import { reducer } from '../State/Reducer';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk'
import { composeWithDevTools } from 'redux-devtools-extension';

export interface IStore {
    userRating: number;
}

export const InitialState: IStore = {
    userRating: 0
}

const store = createStore(reducer, composeWithDevTools(
    applyMiddleware(thunk)
));
export default store;
