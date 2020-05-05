import { IAction } from './IAction';

export interface IData {    
    id: string;
    url: string;
    title: string;
    description: string;
    actions: IAction[];
}

