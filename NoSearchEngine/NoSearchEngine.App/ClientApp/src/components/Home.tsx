import React, { Component } from 'react';
import Search from './Search';
import SearchResults from './SearchResults';
import { IData } from './Interfaces/IData';

interface IProps {
}

interface IState {
  searchResults: IData[];
  isLoading: boolean;
  searchText: string;  
  isSearching: boolean;
  isSearchCompleted: boolean;
}

export class Home extends Component<IProps, IState> {
  static displayName = Home.name;  

  constructor(props: IProps) {    
    super(props);
    this.state = { 
      searchResults: [], 
      isLoading: true,
      searchText: '',
      isSearching: false,
      isSearchCompleted: false
    };

    this.updateSearchText = this.updateSearchText.bind(this);
    this.runSearch = this.runSearch.bind(this);
  }
  
  render () {
    return (
      <div>        
        <Search searchAction={this.runSearch}
          searchTextUpdateAction={this.updateSearchText}
          isBusy={this.state.isSearching} />

        {this.state.isSearchCompleted &&
          <SearchResults data={this.state.searchResults} />
        }
      </div>
    );
  }

  updateSearchText(e: React.ChangeEvent<HTMLInputElement>) {
    this.setState({searchText: e.target.value});
  }

  async runSearch(e: React.MouseEvent<HTMLButtonElement>) {
    this.setState({ isSearching: true });
    const response = await fetch('resource/search/' + this.state.searchText);
    const jsondata: IData[] = await response.json();
    this.setState({ searchResults: jsondata, isLoading: false, isSearching: false });
  }
}
