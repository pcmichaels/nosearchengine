import { IUserData } from "../components/Interfaces/IUserData";

// Action Types
export const GET_USER_DATA = 'GET_USER_DATA'

// Common Message Type(s)
export interface Message {
    user: string
    message: string
    timestamp: number
  }
  
export interface GetUserDataActionType {
    type: typeof GET_USER_DATA
    payload: IUserData
}
    
export type ActionTypes = GetUserDataActionType; // || OtherAction
