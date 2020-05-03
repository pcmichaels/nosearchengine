import React, { Component } from 'react';
import { IData } from './Interfaces/IData';
import ResourceList from './ResourceList';

interface IProps {    
}

interface IState {
    isLoading: boolean;
    isBusy: boolean;
    isDataAvailable: boolean;
    approvalList: IData[];
  }

export class Approval extends Component<IProps, IState> {

    constructor(props: IProps) {
        super(props);
        this.state = { 
            isLoading: true,
            isBusy: false,
            isDataAvailable: false,
            approvalList: [], 
        };
    }

    componentDidMount() {
        this.loadApprovalList();
    }

    render () {
        return (                 
            <div>
            {this.state.isDataAvailable &&
                <div>    
                    <ResourceList data={this.state.approvalList} />
                </div>
            }
            </div>
        );
    }

    async loadApprovalList() {
        this.setState({ isBusy: true });
        const response = await fetch('resource/approvalList/');
        const jsondata: IData[] = await response.json();
        if (jsondata.length !== 0) {
          this.setState({ approvalList: jsondata, isLoading: false, isBusy: false, isDataAvailable: true });
        } else {
          this.setState({ approvalList: [], isLoading: false, isBusy: false, isDataAvailable: false });
        }
      }
}