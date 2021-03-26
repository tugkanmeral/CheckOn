import React, { Component } from "react";
import { CafeList } from "../components/cafe/CafeList";
import { SearchBar } from "../components/searchBar/SearchBar";

export class Home extends Component {
  render() {
    return (
      <div>
        <SearchBar />
        <CafeList />
      </div>
    );
  }
}