import React from 'react';

interface ShortEditTextBoxProps {    
    label: string;
    editTextUpdateAction: (e: React.ChangeEvent<HTMLInputElement>) => void;    
}

function ShortEditTextBox(props: ShortEditTextBoxProps) {
    
    return (
        <div>
            <label>{props.label}</label>
            <input type='text' onChange={props.editTextUpdateAction} />            
        </div>
    );
}
export default ShortEditTextBox;
