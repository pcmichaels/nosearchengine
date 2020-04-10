import React, { Component } from 'react';
import ShortEditTextBox from './Base/ShortEditTextBox';
import LongEditTextBox from './Base/LongEditTextBox';
import SimpleButton from './Base/SimpleButton';

interface IProps {    
}

interface IState {
    loading: boolean;
    url: string;  
    description: string;
  }
  
export class AddSite extends Component<IProps, IState> {
  
  constructor(props: IProps) {
    super(props);
    this.state = { 
        loading: true,
        url: "",
        description: ""
    };

    this.updateUrl = this.updateUrl.bind(this);
    this.updateDescription = this.updateDescription.bind(this);    
  }

  render() {
    return (
      <div>
        <h1>Add New Site</h1>

        <ShortEditTextBox label="URL:" editTextUpdateAction={this.updateUrl} />
        <LongEditTextBox label="Description:" editTextUpdateAction={this.updateDescription} />

        <SimpleButton buttonAction={this.addSiteAction.bind(this)} buttonLabel="Add" />
      </div>
    );
  }

  updateUrl(e: React.ChangeEvent<HTMLInputElement>) {
    this.setState({url: e.target.value});
  }

  updateDescription(e: React.ChangeEvent<HTMLTextAreaElement>) {
    this.setState({description: e.target.value});
  }

  addSiteAction(e: React.MouseEvent<HTMLButtonElement>) {
    const xhr = new XMLHttpRequest();

    this.setState({ loading: true });

    xhr.open('POST', 'resource/addResource')
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify({ 
      url: this.state.url,
      description: this.state.description
    }));

    this.setState({ loading: false });
  }
}
