import React, { Component } from 'react';
import Search from './Search';
import SearchResults from './SearchResults';
import { IData } from './Interfaces/IData';

interface IProps {
}

interface IState {
  searchResults: IData[];
  loading: boolean;
  searchText: string;  
}

export class Home extends Component<IProps, IState> {
  static displayName = Home.name;  

  constructor(props: IProps) {    
    super(props);
    this.state = { 
      searchResults: [], 
      loading: true,
      searchText: ''
    };

    this.updateSearchText = this.updateSearchText.bind(this);
    this.runSearch = this.runSearch.bind(this);
  }
  
  render () {
    return (
      <div>
        <Search searchAction={this.runSearch}
          searchTextUpdateAction={this.updateSearchText} />

        <SearchResults data={this.state.searchResults} />
      </div>
    );
  }

  updateSearchText(e: React.ChangeEvent<HTMLInputElement>) {
    this.setState({searchText: e.target.value});
  }

  async runSearch(e: React.MouseEvent<HTMLButtonElement>) {
    const response = await fetch('search/' + this.state.searchText);
    const jsondata: IData[] = await response.json();
    this.setState({ searchResults: jsondata, loading: false });
  }
}
