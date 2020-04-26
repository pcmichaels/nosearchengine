import React, { Component } from 'react';
import ResourceList from './ResourceList';
import { IData } from './Interfaces/IData';

interface IProps {    
}

interface IState {
}
  
export class AddSiteFailure extends Component<IProps, IState> {
  
    constructor(props: IProps) {
        super(props);
        this.state = { 
        };
    }
    
    render() {
        return (

            <div>
                <div className="form-group row">
                    <h2>Site not successfully added</h2>
                    <h3>We're sorry, it looks like there was a problem with trying to add the site</h3>
                    <h3>Please try again later</h3>
                </div>

                <div className="form-group row">
                    <a href="/MySites">Go to My Sites</a>
                </div>
            </div>
        );
    }
}

