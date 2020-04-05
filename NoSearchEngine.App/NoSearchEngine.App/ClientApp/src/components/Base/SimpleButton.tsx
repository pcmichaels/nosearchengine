import React from 'react';

interface ButtonProps {        
    buttonLabel: string;
    buttonAction: (e: React.MouseEvent<HTMLButtonElement>) => void;    
}

function SimpleButton(props: ButtonProps) {
    
    return (
        <div>
            <button onClick={props.buttonAction}>{props.buttonLabel}</button>
        </div>
    );
}
export default SimpleButton;
