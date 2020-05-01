import React from 'react';
import { IData } from './Interfaces/IData';

type ResourceListProps = {
    data: IData[]
}

function ResourceList(props: ResourceListProps) {
    
    return (
      <table className='table table-striped' aria-labelledby="tableLabel">
        <thead>
          <tr>
            <th>Url</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          {props.data.map(result =>
            <tr key={result.url}>
              <td><a href={result.url} target="_blank">{result.url}</a></td>
              <td>{result.description}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
}

export default ResourceList;
