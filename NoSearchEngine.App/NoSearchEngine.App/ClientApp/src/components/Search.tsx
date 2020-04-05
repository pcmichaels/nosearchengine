import React from 'react';
import SimpleButton from './Base/SimpleButton';

interface SearchProps {    
    searchTextUpdateAction: (e: React.ChangeEvent<HTMLInputElement>) => void;
    searchAction: (e: React.MouseEvent<HTMLButtonElement>) => void;
}

function Search(props: SearchProps) {
    
    return (
        <div className="Row">
            <label>Search</label>
            <input type='text' onChange={props.searchTextUpdateAction} />
            <SimpleButton buttonAction={props.searchAction} buttonLabel="Search" />            
        </div>
    );
}
export default Search;
