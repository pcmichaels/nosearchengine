import React, { Component } from 'react';
import ShortEditTextBox from './Base/ShortEditTextBox';
import LongEditTextBox from './Base/LongEditTextBox';
import SimpleButton from './Base/SimpleButton';
import debounce from 'lodash.debounce';
import { IData } from './Interfaces/IData';

interface IProps {    
}

interface IState {
    loading: boolean;
    title: string;
    url: string;  
    description: string;
    isBusy: boolean;
}
  
export class AddSite extends Component<IProps, IState> {
  
  constructor(props: IProps) {
    super(props);
    this.state = { 
        loading: true,
        title: "",
        url: "",
        description: "",
        isBusy: false
    };

    this.updateTitle = this.updateTitle.bind(this);
    this.updateUrl = this.updateUrl.bind(this);
    this.updateDescription = this.updateDescription.bind(this);    

    this.updateUrlDelayed = debounce(this.updateUrlDelayed, 2000);
  }

  componentDidMount() {
    this.setState({ loading: false });
  }

  render() {
    return (
      <div className="centreLayout">
        <div>
        <div className="form-group row">
          <h2>Add New Site</h2>
        </div>

        <div className="form-group row">
          <table>
            <tbody>
              <tr>
                <ShortEditTextBox label="URL" text={this.state.url} editTextUpdateAction={this.updateUrl} />        
              </tr>
              <tr>
                <ShortEditTextBox label="Title" text={this.state.title} editTextUpdateAction={this.updateTitle} />        
              </tr>
              <tr>
                <LongEditTextBox label="Description" text={this.state.description} editTextUpdateAction={this.updateDescription} />
              </tr>
              </tbody>
          </table>
        </div>
        <div className="form-group row">
          <SimpleButton buttonAction={this.addSiteAction.bind(this)} buttonLabel="Add"
            isBusy={this.state.isBusy} />
        </div>
        </div>
      </div>
    );
  }

  updateTitle(e: React.ChangeEvent<HTMLInputElement>) {
    this.setState({title: e.target.value});
  }

  updateUrl = (e: React.ChangeEvent<HTMLInputElement>) => {
    this.setState({
      url: e.target.value
    });

    this.updateUrlDelayed(e.target.value);
  }

  async updateUrlDelayed(url: string) {

    // Validate the URL & populate the defaults    
    const encodedUrl = encodeURI(url);

    const response = await fetch('webinfo/site/' + encodedUrl);
    if (response.status === 200) {
      const jsondata: IData = await response.json();

      // Update state
      this.setState( {
        title: jsondata.title,
        url: encodedUrl,
        description: jsondata.description
      });
    } else {
      this.setState( {        
        url: url       
      });
    }
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
      this.setState({ isBusy: false });
      if (xhr.status === 200) {
        window.location.href = '/AddSiteSuccess';
      } else {
        window.location.href = '/AddSiteFailure/' + xhr.response;
      }      
    }
    xhr.send(JSON.stringify({ 
      url: this.state.url,
      description: this.state.description
    }));    
  }
}
