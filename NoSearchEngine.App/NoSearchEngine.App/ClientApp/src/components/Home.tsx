import React, { Component } from 'react';
import Search from './Search';
import SearchResults from './SearchResults';
import { IData } from './Interfaces';

interface IProps {
}

interface IState {
  searchResults: IData[];
  loading: boolean;
}

export class Home extends Component<IProps, IState> {
  static displayName = Home.name;
  searchText: string = '';
  loading: boolean;

  constructor(props: IProps) {    
    super(props);
    this.state = { 
      searchResults: [], 
      loading: true 
    };
  }
  
  render () {
    return (
      <div>
        <Search searchText={this.searchText} />

        <SearchResults data={this.state.searchResults} />
      </div>
    );
  }

  async runSearch() {
    const response = await fetch('search/' + this.searchText);
    const jsondata : string = await response.json();
    const data : IData[] = JSON.parse(jsondata)
    this.setState({ searchResults: data, loading: false });
  }
}
