import React from 'react';

interface ShortEditTextBoxProps {    
    label: string;
    editTextUpdateAction: (e: React.ChangeEvent<HTMLInputElement>) => void;    
}

function ShortEditTextBox(props: ShortEditTextBoxProps) {
    
    return (
        <div className="container">
            <div className="row">            
                <label htmlFor="editText" style={{ fontWeight: "bold" }}>{props.label}</label>
            </div>
            <div className="row">            
                <input id="editText" type='text' onChange={props.editTextUpdateAction} />            
            </div>
            
        </div>
    );
}
export default ShortEditTextBox;
