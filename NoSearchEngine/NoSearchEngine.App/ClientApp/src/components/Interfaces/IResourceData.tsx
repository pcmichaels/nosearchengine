import { IAction } from './IAction';

export interface IResourceData {    
    id: string;
    url: string;
    title: string;
    description: string;
    actions: IAction[];
}

