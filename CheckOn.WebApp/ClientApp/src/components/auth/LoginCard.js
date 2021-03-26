import "../../styles/components/auth/loginCard.css";

import React, { Component } from "react";
import { connect } from "react-redux";
import { setUser } from "../../redux/actions/userAction";
import { InputText } from "primereact/inputtext";
import { Button } from "primereact/button";

class LoginCard extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: "",
      pass: "",
    };
  }

  render() {
    return (
      <div id="login-card" className="tm-card tm-shadow tm-xs bg-maximum-yellow-red">
        <span className="p-float-label">
          <InputText
            className="tm-input-xs"
            id="email-input"
            value={this.state.email}
            onChange={(e) => this.setState({ email: e.target.value })}
          />
          <label htmlFor="email-input">E-mail</label>
        </span>
        <span className="p-float-label">
          <InputText
            className="tm-input-xs"
            id="pass-input"
            value={this.state.pass}
            onChange={(e) => this.setState({ pass: e.target.value })}
          />
          <label htmlFor="pass-input">Şifre</label>
        </span>
        <Button
          label="Giriş yap"
          className="p-button-raised p-button-secondary"
          onClick={this.setReduxState}
        />
      </div>
    );
  }

  setReduxState = () => {
    this.props.setUser({
      email: this.state.email,
      token: this.state.pass,
    });
  };
}
const mapDispatchToProps = () => {
  return {
    setUser,
  };
};

export default connect(mapStateToProps, mapDispatchToProps())(LoginCard);

function mapStateToProps(state) {
  return { User: state.User };
}
