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
    isBusy: boolean;
  }
  
export class AddSite extends Component<IProps, IState> {
  
  constructor(props: IProps) {
    super(props);
    this.state = { 
        loading: true,
        url: "",
        description: "",
        isBusy: false
    };

    this.updateUrl = this.updateUrl.bind(this);
    this.updateDescription = this.updateDescription.bind(this);    
  }

  componentDidMount() {
    this.setState({ loading:false });
  }

  render() {
    return (
      <div>
        <div className="form-group row">
          <h2>Add New Site</h2>
        </div>

        <div className="form-group row">
          <table>
            <tbody>
              <tr>
                <ShortEditTextBox label="URL" editTextUpdateAction={this.updateUrl} />        
              </tr>
              <tr>
                <LongEditTextBox label="Description" editTextUpdateAction={this.updateDescription} />
              </tr>
              </tbody>
          </table>
        </div>
        <div className="form-group row">
          <SimpleButton buttonAction={this.addSiteAction.bind(this)} buttonLabel="Add"
            isBusy={this.state.isBusy} />
        </div>
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

    this.setState({ isBusy: true });

    xhr.open('POST', 'resource/addResource')
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.onload = () => {      
      window.location.href = '/';      
    }
    xhr.send(JSON.stringify({ 
      url: this.state.url,
      description: this.state.description
    }));

    this.setState({ isBusy: false });
  }
}
