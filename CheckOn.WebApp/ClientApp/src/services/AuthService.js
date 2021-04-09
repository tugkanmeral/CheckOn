import { ApiCaller } from "../services/ApiCaller";

export function CafeLogin(_email, _password) {
  var body = {
    Email: _email,
    Password: _password,
  };
  // ApiCaller.Post("api/auth", body)
  // alert("AuthService -> CafeLogin")
}
