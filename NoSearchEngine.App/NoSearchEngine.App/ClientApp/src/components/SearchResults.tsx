import React from 'react';

type SearchResultsProps = {
    data: []
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
          {data.map(result =>
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
