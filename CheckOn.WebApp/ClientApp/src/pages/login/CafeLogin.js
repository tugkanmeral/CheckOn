import React, { Component } from "react";
import { connect } from "react-redux";
import { setUser } from "../../redux/actions/userAction";
import { InputText } from "primereact/inputtext";
import { Button } from "primereact/button";
import * as AuthService from "../../services/AuthService"

import "../../styles/pages/login/cafeLogin.css";
import backgroundImage from "../../assets/cafe_login.jpg";

class CafeLogin extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: "",
      pass: "",
    };
  }

  render() {
    return (
      <div id="cafe-login-page" className="tm-page-container">
        {/* <LoginCard /> */}
        <div className="content-side">
          <img className="back-image" src={backgroundImage} />
          <div className="centered-text">Kafe Girişi</div>
        </div>
        <div className="login-side">
          <span className="input-container">
            <label htmlFor="email">E-mail</label>
            <InputText
              className="login-input"
              id="email"
              value={this.state.email}
              onChange={(e) => this.setState({ email: e.target.value })}
            />
          </span>
          <span className="input-container">
            <label htmlFor="pass">Şifre</label>
            <InputText
              type="password"
              style={{ width: "100%" }}
              id="pass"
              value={this.state.pass}
              onChange={(e) => this.setState({ pass: e.target.value })}
            />
          </span>
          <Button
            className="p-button-primary p-button-outlined login-button"
            label="Giriş yap"
            onClick={this.Login}
          />
        </div>
      </div>
    );
  }

  Login = () => {
    AuthService.CafeLogin(this.state.email, this.state.pass);
  };
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
