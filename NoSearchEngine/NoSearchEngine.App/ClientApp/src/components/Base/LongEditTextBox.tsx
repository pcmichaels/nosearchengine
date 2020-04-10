import React from 'react';

interface LongEditTextBoxProps {    
    label: string;
    editTextUpdateAction: (e: React.ChangeEvent<HTMLTextAreaElement>) => void;    
}

function LongEditTextBox(props: LongEditTextBoxProps) {
    
    return (
        <div>
            <label>{props.label}</label>
            <textarea onChange={props.editTextUpdateAction} rows={5} cols={50} />            
        </div>
    );
}
export default LongEditTextBox;
