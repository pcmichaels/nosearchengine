import React, { Component } from 'react';
import ShortEditTextBox from './Base/ShortEditTextBox';
import LongEditTextBox from './Base/LongEditTextBox';
import SimpleButton from './Base/SimpleButton';

interface IProps {
    addSiteAction: (e: React.MouseEvent<HTMLButtonElement>) => void;
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
  }

  render() {
    return (
      <div>
        <h1>Add New Site</h1>

        <ShortEditTextBox label="URL:" editTextUpdateAction={this.updateUrl} />        
        <LongEditTextBox label="Description:" editTextUpdateAction={this.updateDescription} />        

        <SimpleButton buttonAction={this.props.addSiteAction} buttonLabel="Add" />            
      </div>
    );
  }

  updateUrl(e: React.ChangeEvent<HTMLInputElement>) {
    this.setState({url: e.target.value});
  }

  updateDescription(e: React.ChangeEvent<HTMLTextAreaElement>) {
    this.setState({description: e.target.value});
  }

}
