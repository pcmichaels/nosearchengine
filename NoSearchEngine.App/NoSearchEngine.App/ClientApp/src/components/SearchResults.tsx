import React from 'react';
import { IData } from './Interfaces';

type SearchResultsProps = {
    data: IData[]
}

function SearchResults(props: SearchResultsProps) {
    
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Url</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          {props.data.map(result =>
            <tr key={result.Url}>
              <td>{result.Url}</td>
              <td>{result.Description}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
}

export default SearchResults;
