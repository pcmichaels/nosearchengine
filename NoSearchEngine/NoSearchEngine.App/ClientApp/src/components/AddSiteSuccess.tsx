import React, { Component } from 'react';
import ResourceList from './ResourceList';
import { IData } from './Interfaces/IData';

interface IProps {    
}

interface IState {
}
  
export class AddSiteSuccess extends Component<IProps, IState> {
  
    constructor(props: IProps) {
        super(props);
        this.state = { 
        };
    }
    
    render() {
        return (

            <div>
                <div className="row">
                    <h2>Site successfully added</h2>
                </div>
                <div className="row">                    
                    <h3>The site will appear in searches once it has been approved</h3>
                </div>
                <div className="row">
                    <a href="/MySites">Go to My Sites</a>
                </div>
            </div>
        );
    }
}

