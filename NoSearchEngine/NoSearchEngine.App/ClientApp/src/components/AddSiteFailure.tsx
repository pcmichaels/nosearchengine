import React, { Component } from 'react';
import { RouteComponentProps } from 'react-router';

interface IProps extends RouteComponentProps<IMatchParams> {    

}

interface IMatchParams {
    reason: string
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
                <div className="row">
                    <h3>We're sorry, it looks like there was a problem with trying to add the site</h3>
                </div>
                <div className="row">
                    <h3>{this.props.match.params.reason}</h3>
                </div>                    

                <div className="row">
                    <a href="/MySites">Go to My Sites</a>
                </div>
            </div>

        );
    }
}
