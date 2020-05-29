import React from 'react';
import SimpleButton from './Base/SimpleButton';
import 'bootstrap/dist/css/bootstrap.css';

interface SearchProps {    
    searchTextUpdateAction: (e: React.ChangeEvent<HTMLInputElement>) => void;
    searchAction: (e: React.MouseEvent<HTMLButtonElement>) => void;
    isBusy: boolean;
    status: string;
}

function Search(props: SearchProps) {
    
    return (  
        <div className="form-group row" style={{ width: '100%' }}> 
            <div className="form-group row" style={{ width: '100%' }}> 
                <div className="col-sm-8">
                    {props.status}
                </div>
            </div>
            <div className="form-group row" style={{ width: '100%' }}> 
                
                <div className="col-sm-8">
                    <input id="searchText" className="form-control" type='text' onChange={props.searchTextUpdateAction}
                        placeholder="e.g. Goats" />
                </div>
                <div className="col-sm-2">
                    <SimpleButton buttonAction={props.searchAction} buttonLabel="Search" 
                        isBusy={props.isBusy} />            
                </div>
            </div>        
        </div>
    );
}
export default Search;
