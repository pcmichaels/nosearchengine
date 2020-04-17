import React from 'react';

interface LongEditTextBoxProps {    
    label: string;
    editTextUpdateAction: (e: React.ChangeEvent<HTMLTextAreaElement>) => void;    
}

function LongEditTextBox(props: LongEditTextBoxProps) {
    
    return (
        <div className="container">
            <div className="row">            
                <label htmlFor="longEditText" style={{ fontWeight: "bold" }}>{props.label}</label>
            </div>
            <div className="row">            
                <textarea id="longEditText" onChange={props.editTextUpdateAction} rows={5} cols={50} />            
            </div>
        </div>
    );
}
export default LongEditTextBox;
