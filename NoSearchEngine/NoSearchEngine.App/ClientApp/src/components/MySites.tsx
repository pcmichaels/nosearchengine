import React, { Component } from 'react';
import ResourceList from './ResourceList';
import { IData } from './Interfaces/IData';

interface IProps {    
}

interface IState {
    isLoading: boolean;
    resources: IData[];
    isDataAvailable: boolean;
}
  
export class MySites extends Component<IProps, IState> {
  
    constructor(props: IProps) {
        super(props);
        this.state = { 
            isLoading: true,
            resources: [],
            isDataAvailable: false
        };
    }
    
    componentDidMount() {
        this.loadMySites();
      }

    render() {
        let contents = this.state.isLoading
            ? <p><em>Loading...</em></p>
            : <ResourceList data={this.state.resources} />;
  
        return (

            <div className="centreLayout">
                <div className="form-group row">
                    <h2>My Sites</h2>
                </div>

                <div className="form-group row">
                    {contents}
                </div>
            </div>
        );
    }

    async loadMySites() {
        this.setState({ isLoading: true });
        const response = await fetch('resource/mySites');
        const jsondata: IData[] = await response.json();
        if (jsondata.length != 0) {
          this.setState({ resources: jsondata, isLoading: false, isDataAvailable: true });
        } else {
          this.setState({ resources: [], isLoading: false, isDataAvailable: false });
        }
    
    }
}

