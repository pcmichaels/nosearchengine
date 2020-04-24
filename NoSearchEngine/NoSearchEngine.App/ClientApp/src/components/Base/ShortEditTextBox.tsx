import React from 'react';

interface ShortEditTextBoxProps {    
    label: string;
    editTextUpdateAction: (e: React.ChangeEvent<HTMLInputElement>) => void;
    text: string;
}

function ShortEditTextBox(props: ShortEditTextBoxProps) {
    
    return (
        <div className="container">
            <div className="row">            
                <label htmlFor="editText" style={{ fontWeight: "bold", marginTop: "10px" }}>{props.label}</label>
            </div>
            <div className="row">            
                <input id="editText" type='text' value={props.text} onChange={props.editTextUpdateAction} />            
            </div>
            
        </div>
    );
}
export default ShortEditTextBox;
