import React, { Component } from "react";
import { CafeList } from "../components/cafe/CafeList";

import "../styles/pages/home/home.css";

export class Home extends Component {
  render() {
    return (
      <div id="home-page-container" className="tm-page-container">
        <div className="tm-col-8">
          <CafeList />
        </div>
      </div>
    );
  }
}
