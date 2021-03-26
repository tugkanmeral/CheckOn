import React, { Component } from "react";
import { connect } from "react-redux";
import { setUser } from "../../redux/actions/userAction";

class AdminLogin extends Component {
  render() {
    return <div> AdminLogin </div>;
  }
}
const mapDispatchToProps = () => {
  return {
    setUser,
  };
};

export default connect(mapStateToProps, mapDispatchToProps())(AdminLogin);

function mapStateToProps(state) {
  return { User: state.User };
}
