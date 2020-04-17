import React from 'react';

interface ButtonProps {        
    buttonLabel: string;
    buttonAction: (e: React.MouseEvent<HTMLButtonElement>) => void; 
    isBusy: boolean;
}

function SimpleButton(props: ButtonProps) {
    
    return (
        <div>            
            { props.isBusy &&                    
                <button className="btn btn-primary btn-block" type="button" disabled>
                    <span className="spinner-grow spinner-grow-sm" role="status" aria-hidden="true"></span>                    
                </button>                    
            }
            { !props.isBusy &&
                <button className="btn btn-primary btn-block" type="button" onClick={props.buttonAction}>                
                    {props.buttonLabel}
                </button>
            }            
        </div>
    );
}
export default SimpleButton;
