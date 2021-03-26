import React, { Component } from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";

class CustomRedirect extends Component {
  static displayName = CustomRedirect.name;

  render() {
    return <Redirect to={this.props.to} />;
  }
}

function mapStateToProps(state) {
  return { User: state.User };
}

export default connect(mapStateToProps)(CustomRedirect);
