import React, { Component } from "react";
import { connect } from "react-redux";
import { AuthChecker } from "../../components/utils/AuthChecker";
import { setUser } from "../../redux/actions/userAction";

import "../../styles/common.css";

class CafeDashboard extends Component {
  render() {
    return (
      <div>
        <AuthChecker />
        CafeDashboard
      </div>
    );
  }
}
const mapDispatchToProps = () => {
  return {
    setUser,
  };
};

export default connect(mapStateToProps, mapDispatchToProps())(CafeDashboard);

function mapStateToProps(state) {
  return { User: state.User };
}
