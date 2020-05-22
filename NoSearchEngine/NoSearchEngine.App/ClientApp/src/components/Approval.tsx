import React, { Component } from 'react';
import { IResourceData } from './Interfaces/IResourceData';
import { IAction } from './Interfaces/IAction';
import ResourceList from './ResourceList';

interface IProps {    
}

interface IState {
    isLoading: boolean;
    isBusy: boolean;
    isDataAvailable: boolean;
    approvalList: IResourceData[];
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

        this.approve = this.approve.bind(this);
        this.delete = this.delete.bind(this);
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
        const jsondata: IResourceData[] = await response.json();

        const approveAction: IAction = {
            action: this.approve,
            actionLabel: 'Approve'
        };

        const deleteAction: IAction = {
            action: this.delete,
            actionLabel: 'Delete'
        };

        if (jsondata.length !== 0) {
            for (var d of jsondata) {
                d.actions = [approveAction, deleteAction];
            }            
            this.setState({ approvalList: jsondata, isLoading: false, isBusy: false, isDataAvailable: true });
        } else {
            this.setState({ approvalList: [], isLoading: false, isBusy: false, isDataAvailable: false });
        }
    }

    async approve(id: string) {
        this.setState({ isBusy: true });
        await fetch('resource/approveResource/' + id, {
            method: 'POST'
        });
        window.location.reload();
    }

    async delete(id:string) {
        this.setState({ isBusy: true });
        await fetch('resource/deleteResource/' + id, {
            method: 'POST'
        });
        window.location.reload();
        
    }
}