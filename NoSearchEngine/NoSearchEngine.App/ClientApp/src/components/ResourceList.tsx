import React from 'react';
import { IResourceData } from './Interfaces/IResourceData';
import SimpleButton from './Base/SimpleButton';

type ResourceListProps = {
    data: IResourceData[]

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
              {result.actions && result.actions.map(action =>
                <td>
                  <SimpleButton buttonLabel={action.actionLabel} buttonAction={() => action.action(result.id)} isBusy={false}></SimpleButton>
                </td>
              )}
            </tr>
          )}
        </tbody>
      </table>
    );
}

export default ResourceList;
