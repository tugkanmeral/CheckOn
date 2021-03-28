import React, { Component } from "react";
import { connect } from "react-redux";
import { setUser } from "../../redux/actions/userAction";

class AdminDashboard extends Component {
  render() {
    return <div className="tm-page-container"> AdminDashboard </div>;
  }
}
const mapDispatchToProps = () => {
  return {
    setUser,
  };
};

export default connect(mapStateToProps, mapDispatchToProps())(AdminDashboard);

function mapStateToProps(state) {
  return { User: state.User };
}
