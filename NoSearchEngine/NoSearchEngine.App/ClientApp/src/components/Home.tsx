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
  isDataAvailable: number;
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
      isDataAvailable: 0
    };

    this.updateSearchText = this.updateSearchText.bind(this);
    this.runSearch = this.runSearch.bind(this);
  }
  
  render () {
    return (                 
      <div>
        {this.state.isDataAvailable === 0 &&        
          <div className="centreLayout">
              <Search searchAction={this.runSearch}
                searchTextUpdateAction={this.updateSearchText}
                isBusy={this.state.isBusy}
                status={""} />
          </div>
        }

        {this.state.isDataAvailable === 1 &&
          <div>
            <Search searchAction={this.runSearch}
              searchTextUpdateAction={this.updateSearchText}
              isBusy={this.state.isBusy} 
              status={""} />

            <ResourceList data={this.state.searchResults} />
          </div>
        }

        {this.state.isDataAvailable === 2 &&           
            <div className="centreLayout">
                <Search searchAction={this.runSearch}
                  searchTextUpdateAction={this.updateSearchText}
                  isBusy={this.state.isBusy}
                  status={"Unable to find data"} />
            </div>          
        }
      </div>
    );
  }

  updateSearchText(e: React.ChangeEvent<HTMLInputElement>) {
    this.setState({searchText: e.target.value});
  }

  async runSearch(e: React.MouseEvent<HTMLButtonElement>) {
    debugger;
    this.setState({ isBusy: true });
    const response = await fetch('resource/search/' + this.state.searchText);
    const size = Object.keys(response).length;
    if (size === 0) {
      this.setState({ searchResults: [], isLoading: false, isBusy: false, isDataAvailable: 2 });
    } else {
      const jsondata: IResourceData[] = await response.json();
      if (jsondata.length !== 0) {
        this.setState({ searchResults: jsondata, isLoading: false, isBusy: false, isDataAvailable: 1 });
      } else {
        this.setState({ searchResults: [], isLoading: false, isBusy: false, isDataAvailable: 2 });
      }
    }
  }
}
