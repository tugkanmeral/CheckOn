import React, { Component } from "react";
import { connect } from "react-redux";
import CustomRedirect from "./CustomRedirect";

export class AuthChecker extends Component {
  static displayName = AuthChecker.name;

  render() {
    if (!this.props.User) return <CustomRedirect to="/kafegirisi" />
    return this.props.User.token ? null : <CustomRedirect to="/kafegirisi" />;
  }
}
export default connect(mapStateToPros)(AuthChecker);

function mapStateToPros(state) {
  return { User: state.User };
}
