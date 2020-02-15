import React from 'react';

interface SearchProps {    
    searchTextUpdateAction: (e: React.ChangeEvent<HTMLInputElement>) => void;
    searchAction: (e: React.MouseEvent<HTMLButtonElement>) => void;
}

function Search(props: SearchProps) {
    
    return (
        <div>
            <label>Search</label>
            <input type='text' onChange={props.searchTextUpdateAction} />
            <button onClick={props.searchAction}>Search</button>
        </div>
    );
}
export default Search;
