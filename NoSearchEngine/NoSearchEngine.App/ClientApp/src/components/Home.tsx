import React, { Component } from 'react';
import Search from './Search';
import ResourceList from './ResourceList';
import { IResourceData } from './Interfaces/IResourceData';

interface IProps {
}

interface IState {
  searchResults: IResourceData[];
  isLoading: boolean;
  searchText: string;  
  isBusy: boolean;
  isDataAvailable: boolean;
}

export class Home extends Component<IProps, IState> {
  static displayName = Home.name;  

  constructor(props: IProps) {    
    super(props);
    this.state = { 
      searchResults: [], 
      isLoading: true,
      searchText: '',
      isBusy: false,
      isDataAvailable: false
    };

    this.updateSearchText = this.updateSearchText.bind(this);
    this.runSearch = this.runSearch.bind(this);
  }
  
  render () {
    return (                 
      <div>
        {this.state.isDataAvailable &&
          <div>
            <Search searchAction={this.runSearch}
              searchTextUpdateAction={this.updateSearchText}
              isBusy={this.state.isBusy} />

            <ResourceList data={this.state.searchResults} />
          </div>
        }

        {!this.state.isDataAvailable &&
          <div className="centreLayout">
              <Search searchAction={this.runSearch}
                searchTextUpdateAction={this.updateSearchText}
                isBusy={this.state.isBusy} />
          </div>
        }
      </div>
    );
  }

  updateSearchText(e: React.ChangeEvent<HTMLInputElement>) {
    this.setState({searchText: e.target.value});
  }

  async runSearch(e: React.MouseEvent<HTMLButtonElement>) {
    this.setState({ isBusy: true });
    const response = await fetch('resource/search/' + this.state.searchText);
    const jsondata: IResourceData[] = await response.json();
    if (jsondata.length !== 0) {
      this.setState({ searchResults: jsondata, isLoading: false, isBusy: false, isDataAvailable: true });
    } else {
      this.setState({ searchResults: [], isLoading: false, isBusy: false, isDataAvailable: false });
    }
  }
}
