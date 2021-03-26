import React, { Component } from "react";

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return <div id="site-container">{this.props.children}</div>;
  }
}
