import React from 'react';

type SearchProps = {
    searchText: string    
}

function Search(props: SearchProps) {
    
    return (
        <div>
            <label>Search</label>
            <textarea>{props.searchText}</textarea>
        </div>
    );
}
export default Search;
