import { reducer } from '../State/Reducer';
import { createStore } from 'redux';

export interface IStore {
    userRating: number;
}

export const InitialState: IStore = {
    userRating: 0
}

const store = createStore(reducer);
export default store;
