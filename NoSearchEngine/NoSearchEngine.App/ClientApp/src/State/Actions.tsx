export const GET_USER_DATA = 'GET_USER_DATA'

export interface Message {
    user: string
    message: string
    timestamp: number
  }
  
interface GetUserDataAction {
    type: typeof GET_USER_DATA
    payload: Message
}
    
export type ActionTypes = GetUserDataAction; // || OtherAction
