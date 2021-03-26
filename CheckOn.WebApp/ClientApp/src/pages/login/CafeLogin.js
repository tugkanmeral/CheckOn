import React, { Component } from "react";
import { connect } from "react-redux";
import LoginCard from "../../components/auth/LoginCard";
import { setUser } from "../../redux/actions/userAction";

import "../../styles/pages/login/cafeLogin.css";

class CafeLogin extends Component {
  render() {
    return (
      <div id="cafe-login-page">
        <LoginCard />
      </div>
    );
  }
}
const mapDispatchToProps = () => {
  return {
    setUser,
  };
};

export default connect(mapStateToProps, mapDispatchToProps())(CafeLogin);

function mapStateToProps(state) {
  return { User: state.User };
}
