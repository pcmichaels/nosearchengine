import React from 'react';
import { IData } from './Interfaces/IData';

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
            <tr key={result.url}>
              <td>{result.url}</td>
              <td>{result.description}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
}

export default SearchResults;
